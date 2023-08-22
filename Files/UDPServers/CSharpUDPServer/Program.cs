using System.Net;
using System.Net.Sockets;

public class Program {
    public static void Main() {
        IPEndPoint receiver = new IPEndPoint(IPAddress.Any, 8090);
        IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);

        UdpClient newSock = new UdpClient(receiver);

        Console.WriteLine("Waiting for a client...");

        while (true) {
            var data = newSock.Receive(ref sender);
            Console.WriteLine($"Message received from {sender}:");

            Console.WriteLine(Convert.ToHexString(data, 0, data.Length));
            newSock.Send(data, data.Length, sender);
        }
    }
}
