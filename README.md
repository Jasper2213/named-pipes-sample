# Named Pipes Sample

This sample demonstrates how to use named pipes to communicate between two processes. The sample consists of two projects: a server and a client. The server creates a named pipe and waits for a client to connect to it. When the client is connected, the server can send a message to it. When the client receives the message, it displays it.

## Build and Run

To build and run the sample, follow these steps:

1. Open the solution file `pipes-sample.sln` in Visual Studio.
2. Right-click the solution in Solution Explorer and select **Restore NuGet Packages**.
3. Right-click the solution in Solution Explorer and select **Build Solution**.

This will open two applications, the server and the client. The server will create a named pipe and wait for the client to connect. The client will connect to the server and display the message sent by the server.

## Key Features

This sample demonstrates how to:

- Create a named pipe server.
- Create a named pipe client.
- Connect the client to the server.
- Send a message from the server to the client.
- Receive a message from the server in the client.
- Display the message received by the client.
