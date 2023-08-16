import { WebSocketServer } from 'ws';

// by Notblue
// most basic WS server

const wss = new WebSocketServer({ port: 8080 });

wss.on('connection', function connection(ws) {
  ws.on('message', function message(data) {
    console.log('received: %s', data);
  });

  ws.send('hex stream');
});