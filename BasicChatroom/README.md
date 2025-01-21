# Basic Chatroom

This project implements a simple chat room server and GUI client application using Python. It consists of a server program (`ChatroomServer.py`) and a client program (`ChatroomClient.py`) with a graphical user interface (GUI) using TKinter. The application was coded in Anaconda Spyder and is run on command prompt or terminal.

## Features
- Multi-threaded server supporting multiple clients
- TKinter GUI interface
- Color-coded message types
- Command-line configuration

## Requirements
- Python 3.x
- Tkinter (usually included with Python)
- Comamand Prompt/Terminal

## Setup and Running
1. Download the source code files
2. Run the Server (Details in "Running the Server" down below)
3. Run the Client(s) (Details in "Running the Client" down below)
4. Use the Chatroom (Details in "Using the Client GUI Window" down below)
5. To close the client and leave the chat room, simply close the client window. The client will automatically send a leave message to the server and terminate

### Running the Server
1. Open command prompt/terminal and navigate to the project directory
2. Run the following command to start the server: 
```bash
    python ChatroomServer.py [--port PORT] [--version] [--help]
	    + [--port PORT]: Optional argument to specify the port number on which the server should listen. Default is 8765. Example: 'python ChatroomServer.py --port 8500'
	    + [--version]: Optional argument to view version of server. Example: 'python ChatroomServer.py --version'
	    + [--help]: Optional argument to view description of server and optional arguments. Example: 'python ChatroomServer.py --help'
```
3. The server will start running and listening for client connections on default (8765) or specified port


### Running the Client
1. Open command prompt/terminal and navigate to the project directory
2. Run the following command to start the client: 
```bash
    python ChatroomClient.py --username USERNAME [--port PORT] [--target TARGET] [--version] [--help]
		+ --username USERNAME: Required argument to specify the username for the client. Example: 'python ChatroomClient.py --username Ben'
		+ [--port PORT]: Optional argument to specify the port number of the server. Default is 8765. Example: 'python ChatroomClient.py --username Ben --port 8500'
		+ [--target TARGET]: Optional argument to specify the IP or hostname of the server. Default is 'localhost'. Example: 'python ChatroomClient.py --username Ben --target 127.0.0.1'
		+ [--version]: Optional argument to view version of client. Example: 'python ChatroomClient.py --version]'
		+ [--help]: Optional argument to view description of client and optional arguments. Example: 'python ChatroomClient.py [--help]'
```
3. The client GUI window will open, and you will see a message indicating that you have joined the chat room

### Using the Client GUI Window
+ To send a message, type your message in the input field at the bottom of the client window and press Enter or click the "Send" button.
+ Your sent messages will appear in the chat window with your username (Black Text).
+ Messages received from other clients will be displayed in the chat window with their respective usernames (Green Text).
+ Join and leave messages will be displayed in the chat window when clients join or leave the chat room (Blue Text for Join) (Red Text for Leave).

## Troubleshooting
+ If the client fails to connect to the server, ensure that the server is running and the specified IP address and port number are correct.
+ If messages are not being sent or received, check the server and client console output for any error messages.