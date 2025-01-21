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

## Setup
1. Download the source code files
2. Run the Server (Details in "Running the Server" down below)
3. Run the Client(s) (Details in "Running the Client" down below)
4. Use the Chatroom (Details in "Using the Client GUI Window" down below)
5. To close the client and leave the chat room, simply close the client window. The client will automatically send a leave message to the server and terminate.

### Running the Server
```bash
1. Open command prompt/terminal and navigate to the project directory
	2. Run the following command to start the server: 'python ChatroomServer.py'
		+ '--port PORT': Optional argument to specify the port number on which the server should listen. Default is 8765. Example: 'python ChatroomServer.py --port 8500'
		+ '--version': Optional argument to view version of server. Example: 'python ChatroomServer.py --version'
		+ '--help': Optional argument to view description of server and optional arguments. Example: 'python ChatroomServer.py --help'
	3. The server will start running and listening for client connections on default (8765) or specified port.
