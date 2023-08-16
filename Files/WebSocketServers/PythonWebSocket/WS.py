from simple_websocket_server import WebSocketServer, WebSocket
import sys

# By newtonDad
# Requires : pip install simple-websocket-server
# Usage : py WS.py port
# Exemple : py WS.py 8000

class SimpleChat(WebSocket):
    def handle(self):
        print(self.data)
        # Respond with "OK" to the client
        self.send_message("OK")
        self.send_message("OK")
        self.send_message("OK")

    def connected(self):
        print(self.address, 'connected')
        for client in clients:
            client.send_message(self.address[0] + u' - connected')
        clients.append(self)

    def handle_close(self):
        clients.remove(self)
        print(self.address, 'closed')
        for client in clients:
            client.send_message(self.address[0] + u' - disconnected')

clients = []

server = WebSocketServer('', sys.argv[1], SimpleChat)
server.serve_forever()