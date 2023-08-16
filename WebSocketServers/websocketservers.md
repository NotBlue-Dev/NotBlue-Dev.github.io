---
layout: default
title: Web Socket Servers
nav_order: 2
has_children: true
---

# WebSocketServers

The Echo Arena client is using WebSockets to gather information like the main menu, logging, game servers IPs and other stuff.
Here you can find multiple scripts / project that emulates those WebSocket servers.

- **C# WebSocket Server**
    - Simply create a .NET6 C# project, add the `Fleck` NuGet Package and replace the default `Program.cs` with this one: [Program.cs]
    - 
- **NodeJS WebSocket Server**
    - Download [server.js] and [package.json]
    - npm i package.json
    - node server.js
- **Python3 WebSocket Server**
    - fffff

[Program.cs]: https://github.com/NotBlue-Dev/NotBlue-Dev.github.io/blob/main/Files/WebSocketServers/CSharpWebSocket/Program.cs
[server.js]: https://github.com/NotBlue-Dev/NotBlue-Dev.github.io/blob/main/Files/WebSocketServers/NodeJSWebsocket/server.js
[package.json]: https://github.com/NotBlue-Dev/NotBlue-Dev.github.io/blob/main/Files/WebSocketServers/NodeJSWebsocket/package.json