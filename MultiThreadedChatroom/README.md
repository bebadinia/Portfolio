# Multi-threaded Chat Room (Python / Tkinter)

This project implements a simple chat room server and GUI client application using Python. It consists of a server program (`ChatroomServer.py`) and a client program (`ChatroomClient.py`) with a graphical user interface (GUI) built with *Tkinter*. The application was developed in Anaconda Spyder and is run from Command Prompt/Terminal.

## Features
- Multi-threaded server supporting multiple clients
- *Tkinter* GUI client
- Color-coded message types
- Command-line configuration
---

## Requirements
- Python 3.x
- Tkinter (usually included with Python)
- Command Prompt/Terminal

---

## Project Layout

MultiThreadedChatroom/
- `docs/`
  - `assignments/`
  - `documentation/`
  - `screenshots/`
- `src/`
  - `ChatroomServer.py`
  - `ChatroomClient.py`

---

## Setup and Running
1. Download or clone this repository.
2. Run the server (details in “Running the Server” below).
3. Run one or more clients (details in “Running the Client” below).
4. Use the chatroom (details in “Using the Client GUI Window” below).
5. To close the client and leave the chat room, close the client window. The client will automatically send a leave message to the server and terminate.

> **Note:** The scripts are located in `src/`. The simplest workflow is to run everything from inside the `src/` directory.


### Running the Server
1. Open Command Prompt/Terminal and navigate to the project `src/` directory.
2. Start the server:
```bash
    python ChatroomServer.py [--port PORT] [--version] [--help]
	    + [--port PORT]: Optional argument to specify the port number on which the server should listen. Default is 8765. Example: 'python ChatroomServer.py --port 8500'
	    + [--version]: Optional argument to view version of server. Example: 'python ChatroomServer.py --version'
	    + [--help]: Optional argument to view description of server and optional arguments. Example: 'python ChatroomServer.py --help'
```
3. The server will start running and listen for client connections on port `8765` (default) or the specified port.


### Running the Client
1. Open Command Prompt/Terminal and navigate to the project `src/` directory.
2. Start the client:
```bash
    python ChatroomClient.py --username USERNAME [--port PORT] [--target TARGET] [--version] [--help]
		+ --username USERNAME: Required argument to specify the username for the client. Example: 'python ChatroomClient.py --username Ben'
		+ [--port PORT]: Optional argument to specify the port number of the server. Default is 8765. Example: 'python ChatroomClient.py --username Ben --port 8500'
		+ [--target TARGET]: Optional argument to specify the IP or hostname of the server. Default is 'localhost'. Example: 'python ChatroomClient.py --username Ben --target 127.0.0.1'
		+ [--version]: Optional argument to view version of client. Example: 'python ChatroomClient.py --version]'
		+ [--help]: Optional argument to view description of client and optional arguments. Example: 'python ChatroomClient.py [--help]'
```
3. The client GUI window will open, and you will see a message indicating that you have joined the chat room.

### Using the Client GUI Window
- To send a message, type your message in the input field at the bottom of the client window and press Enter or click **Send**.
- Your sent messages will appear in the chat window with your username (black text).
- Messages received from other clients will be displayed in the chat window with their respective usernames (green text).
- Join and leave messages will be displayed in the chat window when clients join or leave the chat room (blue for join, red for leave).

---

## Troubleshooting
- If the client fails to connect to the server, ensure the server is running and the `--target` and `--port` values are correct.
- If messages are not being sent or received, check the server and client console output for error messages.

---

## Demo / Screenshots
- **Client UI:** 
  ![Chatroom client screenshot](docs/screenshots/SampleScreenShot.png)

- **Message Flow Diagram:**  
  ![Message flow diagram](docs/documentation/message-flow-diagram.png)