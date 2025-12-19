# ChatroomClient.py by Ben Ebadinia

import sys
import argparse
import socket
import tkinter
from threading import Thread
from queue import Queue

# Command line arguments
parser = argparse.ArgumentParser(description='Chat Room Client')
parser.add_argument('--version', action='version', version='ChatRoomClient.py 1.0')
parser.add_argument('--target', default='localhost', help='IP or hostname of the server (default: localhost)')
parser.add_argument('--port', type=int, default=8765, help='Port number of the server (default: 8765)')
parser.add_argument('--username', required=True, help='Username for the client (required)')
args = parser.parse_args()

# Setup queue
messageQueue = Queue()

# Setup Client GUI
clientUI = tkinter.Tk()
clientUI.title(f"Chat Room - {args.username}")

chatWindow = tkinter.Text(clientUI, height=20, width=50)
chatWindow.grid(row=0, column=0, padx=10, pady=10)

# Configure text tags for different message types
chatWindow.tag_configure("Join", foreground="blue")
chatWindow.tag_configure("Leave", foreground="red")
chatWindow.tag_configure("Message", foreground="green")


# Function to add message to queue
def queueMessage():
    message = messageEntry.get()
    if message:
        # Queue formatted message to be broadcast to other users
        formattedMessage = f"CHAT/1.0 TEXT\r\nUsername: {args.username}\r\nMsg-len: {len(message)}\r\n\r\n{message}"
        messageQueue.put(formattedMessage.encode())
        
        # Update client chat window with own message
        updateChatWindow(f"{args.username}: {message}")
        
        # Clear input field
        messageEntry.delete(0, tkinter.END)

messageEntry = tkinter.Entry(clientUI, width=50)
messageEntry.grid(row=1, column=0, padx=10, pady=10)
messageEntry.bind("<Return>", lambda _: queueMessage())

sendButton = tkinter.Button(clientUI, text="Send", command=queueMessage)
sendButton.grid(row=1, column=1, padx=10, pady=10)


# Create a client TCP socket
clientSocket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)

# Connect client socket to sertver socket
clientSocket.connect((args.target, args.port))

# Send formatted message to join server
joinMessage = f"CHAT/1.0 JOIN\r\nUsername: {args.username}\r\n\r\n"
clientSocket.send(joinMessage.encode())


# Function to update window
def updateChatWindow(message, tag=None):
    if tag:
        chatWindow.insert(tkinter.END, message + "\n", tag)
    else:
        chatWindow.insert(tkinter.END, message + "\n")
    chatWindow.see(tkinter.END)
    clientUI.update_idletasks()

# Update client chat window with entry message
updateChatWindow(f"{args.username} has joined the chat!")


# Function to recieve messages to server
def receiveMessages():
    while True:
        try:
            message = clientSocket.recv(1024)
            if not message:
                break
            handleMessage(message)
        except:
            break

# Recieve thread set up
receiveThread = Thread(target=receiveMessages)
receiveThread.start()


# Function to send message to server
def sendMessage():
    while True:
        message = messageQueue.get()
        if message:
            clientSocket.send(message)

# Send thread set up
sendThread = Thread(target=sendMessage)
sendThread.start()

# Print readable message based on data recieved from server
def handleMessage(data):
    decodedData = data.decode()
    
    # Print user join message
    if decodedData.startswith("CHAT/1.0 JOIN"):
        username = decodedData.split("\r\n")[1].split(": ")[1]
        updateChatWindow(f"{username} has joined the chat!", "Join")
        
    # Print user left message   
    elif decodedData.startswith("CHAT/1.0 LEAVE"):
        username = decodedData.split("\r\n")[1].split(": ")[1]
        updateChatWindow(f"{username} has left the chat!", "Leave")
        
    # Print user message with username
    elif decodedData.startswith("CHAT/1.0 TEXT"):
        username = decodedData.split("\r\n")[1].split(": ")[1]
        message = decodedData.split("\r\n\r\n")[1]
        updateChatWindow(f"{username}: {message}", "Message")
        
# Send formatted message to leave server and close GUI
def sendLeaveMessage():
    leaveMessage = f"CHAT/1.0 LEAVE\r\nUsername: {args.username}\r\n\r\n"
    clientSocket.send(leaveMessage.encode())
    clientSocket.close()
    clientUI.destroy()
    sys.exit()


# Run the GUI
def main():
    clientUI.protocol("WM_DELETE_WINDOW", sendLeaveMessage)
    clientUI.mainloop()

if __name__ == "__main__":
    main()