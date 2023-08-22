---
layout: default
title: Custom Matchmaker WS
parent: Use Case
nav_order: 1
---

## Use case

### Listen to the game client trying to start a game session with the game server 
You can follow these steps to check if your Matchmaker WebSocket server if working and start analysing what the game client is sending to the game server.

##### Get your game client ready
1. Get a fresh install of the game (pre-farewell version) (see [Echo Versions]).
2. Add this [config.json] file inside the `\_local` folder of the game.
It will tell the game that the Matchmaker WebSocket is listening on `127.0.0.1:8001`.
3. Add the [dbgcore.dll] inside the `\bin\win10` folder of the game.
It will bypass the Login WebSocket sequence, so you don't have to worry about it.

##### Set up the required local servers
1. Set up a local UDP server of you choice.
Here, we will use the C# one:
   1. Simply create a .NET6 C# project and replace the generated `Program.cs` with this one: [Program.cs (UDP server)]
   2. By default, this UDP server is listening on `127.0.0.1:8090`. You can change the port with the one you want.
2. Set up the local Matchmaking WebSocket server of your choice.
Here, we will use the C# one:
   1. Simply create a .NET6 C# project, add the `Fleck` NuGet Package and replace the default `Program.cs` with this one: [Program.cs (WS server)]
   2. In the `Main()` method, just start the matchmaking local server by calling `StartMatchmakerServer();`
   3. By default, this matchmaking server will tell the client that the game server is listening on `127.0.0.1:8090`.
   You can change this by specifying the IP:Port of your choice when starting the Matchmaker server: `StartMatchmakerServer("127.0.0.1", 8090)`.

##### Run everything
1. Start the local Matchmaker WebSocker Server
2. Start the local UDP Server
3. Start the game

By default, the C# Matchmaking WebSocket server will only respond once to the game client.
You can disable it when starting the Matchmaker server: `StartMatchmakerServer("127.0.0.1", 8090, false)`.

If you are using the C# version of the Matchmaker and UDP server, you can see in the consoles the information that is being received from the game client.

If everything is working properly, you should see this information in the UDP server console:

```
Message received from 127.0.0.1:6794:
B0035A06DE7972990000000000000000
Message received from 127.0.0.1:6794:
9178B7E056E57A4F0000000000000000
Message received from 127.0.0.1:6794:
B0035A06DE7972993C00000000000000
Message received from 127.0.0.1:6794:
9178B7E056E57A4F3C00000000000000
Message received from 127.0.0.1:6794:
B0035A06DE7972993D00000000000000
Message received from 127.0.0.1:6794:
9178B7E056E57A4F3D00000000000000
Message received from 127.0.0.1:6794:
B0035A06DE7972993E00000000000000
Message received from 127.0.0.1:6794:
9178B7E056E57A4F3E00000000000000
```
We can see here that the game is sending 4 batches of similar data.

Between each batch, only 1 byte is changing:
```
B0035A06DE797299[00]00000000000000
B0035A06DE797299[3C]00000000000000
B0035A06DE797299[3D]00000000000000
B0035A06DE797299[3E]00000000000000

9178B7E056E57A4F[00]00000000000000
9178B7E056E57A4F[3C]00000000000000
9178B7E056E57A4F[3D]00000000000000
9178B7E056E57A4F[3E]00000000000000
```

To be continued...

[Echo Versions]: https://notblue-dev.github.io/EchoVersions/echoversions.html
[config.json]: https://github.com/NotBlue-Dev/NotBlue-Dev.github.io/blob/main/Files/WebSocketServers/config.json
[dbgcore.dll]: https://github.com/NotBlue-Dev/NotBlue-Dev.github.io/blob/main/Files/Patches/BypassLogin/dbgcore.dll
[Program.cs (UDP server)]: https://github.com/NotBlue-Dev/NotBlue-Dev.github.io/blob/main/Files/UDPServers/CSharpUDPServer/Program.cs
[Program.cs (WS server)]: https://github.com/NotBlue-Dev/NotBlue-Dev.github.io/blob/main/Files/WebSocketServers/CSharpWebSocket/Program.cs
