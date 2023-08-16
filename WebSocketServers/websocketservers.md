---
layout: default
title: Web Socket Servers
nav_order: 2
---

# WebSocketServers

The Echo Arena client is using WebSockets to gather information like the main menu, logging, game servers IPs and other stuff.
Here you can find multiple scripts / project that emulates those WebSocket servers.

The majority of these servers will listen on:
- `127.0.0.1:8000` for Login
- `127.0.0.1:8001` for Matchmaking
- `127.0.0.1:8002` for Transaction
- `127.0.0.1:8003` for Config

In order for your game to send data to these locally hosted servers, you have to create a `config.json` file in the `[...]\ready-at-dawn-echo-arena\_local` folder.
You can find this `config.json` file right there : [config.json]

- **C# WebSocket Server**
    - Simply create a .NET6 C# project, add the `Fleck` NuGet Package and replace the default `Program.cs` with this one: [Program.cs]
    - You can choose which server(s) you want to start by calling `StartConfigServer()`, `StartLoginServer()`, `StartMatchmakerServer()` or `StartTransactionServer`
- **NodeJS WebSocket Server**
    - Download [server.js] and [package.json]
    - Run `npm i package.json`
    - Run `node server.js`
    - Default port is 8080, you can change it in the `server.js` file
- **Python3 WebSocket Server**
    - Download [WS.py]
    - Run `pip install simple-websocket-server`
    - Run `py WS.py desiredPort`
    - You can choose the port to run the WS on by passing it as an argument

[config.json]: https://github.com/NotBlue-Dev/NotBlue-Dev.github.io/blob/main/Files/WebSocketServers/config.json
[Program.cs]: https://github.com/NotBlue-Dev/NotBlue-Dev.github.io/blob/main/Files/WebSocketServers/CSharpWebSocket/Program.cs
[server.js]: https://github.com/NotBlue-Dev/NotBlue-Dev.github.io/blob/main/Files/WebSocketServers/NodeJSWebsocket/server.js
[package.json]: https://github.com/NotBlue-Dev/NotBlue-Dev.github.io/blob/main/Files/WebSocketServers/NodeJSWebsocket/package.json
[WS.py]: https://github.com/NotBlue-Dev/NotBlue-Dev.github.io/blob/main/Files/WebSocketServers/PythonWebSocket/WS.py