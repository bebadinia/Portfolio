# ChatroomServer.py by Ben Ebadinia

import argparse
import socket
import threading


# Command line arguments
parser = argparse.ArgumentParser(description='Chat Room Server')
parser.add_argument('--version', action='version', version='ChatroomServer.py 1.0')
parser.add_argument('--port', type=int, default=8765, help='Port number to listen on (default: 8765)')
args = parser.parse_args()

# List of connected chatroom clients
chatroomClients = []

# Create a TCP server socket
serverSocket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
serverSocket.bind(('localhost', args.port))
serverSocket.listen(5)
print(f'Server listening on port {args.port}...')


# Broadcast message to clients other than senders
def broadcast(message, senderSocket):
    for clientSocket in chatroomClients.copy():
        if clientSocket != senderSocket:
            try:
                clientSocket.send(message)
            except:
                clientSocket.close()
                chatroomClients.remove(clientSocket)


# Used for recieving messages
def handleClient(clientSocket, clientAddress):
    try:
        # Receive the client message
        while True:
            message = clientSocket.recv(1024)
        
            if not message:
                break
            
            print(f'Received message from {clientAddress}: {message.decode()}')
           
            # Send broadcast to be sent to other clients in server
            broadcast(message, clientSocket)
    
    except Exception as e:
        print(f'Error handling client {clientAddress}: {e}')
        
    # If user disconnects, remove from client list and broadcast this to remaining users
    finally:
        print(f'Client {clientAddress} disconnected.')
            
        if clientSocket in chatroomClients:
            chatroomClients.remove(clientSocket)
        
        clientSocket.close()


# Establishing connection
while True:
    clientSocket, clientAddress = serverSocket.accept()
    print(f'New connection from {clientAddress}')
    
    # Add client socket to list of connected chatroom clients
    chatroomClients.append(clientSocket)
    
    # Creating a thread for the server socket
    clientThread = threading.Thread(target=handleClient, args=(clientSocket, clientAddress))
    clientThread.start()

