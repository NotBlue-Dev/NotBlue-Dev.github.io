using System.Text;
using Fleck;

namespace Ouais_WS_Ouais;

public static class Program {
    private const string CONFIG_PAYLOAD = @"{""news"":{""offseason"":{""link"":""https://www.youtube.com/watch?v=dQw4w9WgXcQ"",""texture"":null},""sentiment"":{""link"":""https://www.youtube.com/watch?v=dQw4w9WgXcQ"",""texture"":""ui_mnu_news_latest""}},""_ts"":1675189870550,""id"":""main_menu"",""splash"":{""offseason"":{""link"":""http://bit.ly/3XRCIhD"",""texture"":""ui_menu_splash_screen_poster_a_shutdown_clr""},""season_07"":{""link"":""https://www.youtube.com/watch?v=dQw4w9WgXcQ"",""texture"":""ui_menu_splash_screen_poster_a_s7_clr""}},""splash_version"":8,""discord_link"":""https://didddscord.gg/ymAYmnZ"",""help_link"":""https://readyatdawn.zendesk.com/hc/en-us"",""news_link"":""https://www.youtube.com/watch?v=dQw4w9WgXcQ"",""type"":""main_menu""}";
    private const string SEND1 = "F640BB78A2E78CBB12D07B6F58AFCDB948010000000000007B1D0E4427EE09157B1D0E4427EE09155902000028B52FFD60590155090046923922306DF3A0AC673B5B96A1709345BA1A46672853C54B4C034B2644DF0A1C2C0C0CD60130002E003000292967FEDFAA85348C8B62ACAD96697D08FE8DA8EDE98CFDF1981B51EB0DF7220583A1501A038D05431158A8F55F1B0991F145CFB309F33504827DE7677179C3BD6ACB05EB7EB384DFEC8B9E5D6674249C255B12F3354E72B64456E858060F6B1B32B96A1D5414C5EAE9ECE029182C30042427260F1D29291ADBEA66BAAFCF175B94DF27B39A99365FAB363F6701000F33CE2F5A87960D05D249CB92383A9B43B768BD269A537B1067D71C9174C3DC33C731A68B89FC1635D4F6844E39180070E684CECC4A45C73003BCCB00AD086CEF9C927B052CDBEDDA486C719DD63A98D90EC4F00E0D4C006F1E6D58ED413AA64862B46065CC035B70C130CC1CC10C";
    private const string SEND1_5 = "F640BB78A2E78CBBE4EE6BC73A96E643010000000000000010";

    public static void Main(string[] args) {
        StartConfigServer();
//         StartLoginServer();
        StartMatchmakerServer();
//         StartTransactionServer();

        Console.ReadKey(true);
    }

    private static void StartConfigServer() {
        WebSocketServer server = new WebSocketServer("ws://127.0.0.1:8003");

        server.Start(socket => {
            socket.OnOpen = () => {
                Console.WriteLine("[CONFIG] Open!");
            };

            socket.OnClose = () => {
                Console.WriteLine("[CONFIG] Close!");
            };

            socket.OnMessage = message => {
                Console.WriteLine($"[CONFIG] MESSAGE RECEIVED: {message}");
                socket.Send("Ok");
            };

            socket.OnBinary = bytes => {
                Console.WriteLine($"[CONFIG] DATA RECEIVED: {Convert.ToHexString(bytes)}");

                socket.Send(Convert.FromHexString(SEND1));
                socket.Send(Convert.FromHexString(SEND1_5));

                Console.WriteLine("[CONFIG] Data Sent");
            };

            socket.OnError = ex => {
                Console.WriteLine($"[CONFIG] Exception: {ex.Message}");
                socket.Send("Ok");
            };
        });
    }

    private static void StartLoginServer() {
        WebSocketServer server = new WebSocketServer("ws://127.0.0.1:8000");

        server.Start(socket => {
            socket.OnOpen = () => {
                Console.WriteLine("[LOGIN] Open!");
            };

            socket.OnClose = () => {
                Console.WriteLine("[LOGIN] Close!");
            };

            socket.OnMessage = message => {
                Console.WriteLine($"[LOGIN] MESSAGE RECEIVED: {message}");
                socket.Send("Ok");
            };

            socket.OnBinary = bytes => {
                Console.WriteLine($"[LOGIN] DATA RECEIVED: {Encoding.UTF8.GetString(bytes)}");


                socket.Send("Ok");

                Console.WriteLine("[LOGIN] Data Sent");
            };

            socket.OnError = ex => {
                Console.WriteLine($"[LOGIN] Exception: {ex.Message}");
                socket.Send("Ok");
            };
        });
    }

    private static void StartMatchmakerServer() {
        // 6794
        WebSocketServer server = new WebSocketServer("ws://127.0.0.1:8001");

        server.Start(socket => {
            socket.OnOpen = () => {
                Console.WriteLine("[MATCHMAKER] Open!");
            };

            socket.OnClose = () => {
                Console.WriteLine("[MATCHMAKER] Close!");
            };

            socket.OnMessage = message => {
                Console.WriteLine($"[MATCHMAKER] MESSAGE RECEIVED: {message}");
                socket.Send("Ok");
            };

            socket.OnBinary = bytes => {
                Console.WriteLine($"[MATCHMAKER] DATA RECEIVED: {Encoding.UTF8.GetString(bytes)}");

                string aa = "F640BB78A2E78CBBCBBEBFDA33CF288F040000000000000000000000";
                // Packet containing IP to 127.0.0.1:6794
                string bb = "F640BB78A2E78CBBF3EBBF19875FBFFA700100000000000000000400E80300000ACBCD4D" + "7F0000011A8A" + "00000AF74E430346EC7A1A8900000AF7450C034BBF9F1A8D00000AF75E6C365D374B1A8A00000AF55ED80DD6C1FF1A8A00000A4A8E19030987F11A8D00000A4A855D0309B1791A8B00000A4A97CB23B08B511A8800000A4A8B841285E4C21A8A00000AF2C27C365F26C21A8D00000A2BDC6F0D38E6EA1A8900000A2BD54F036556431A8800000A2BCC5736B7DE2E1A8C00000A2BD8E60365BE031A8A00000A01697F36A6E4681A8B00000A0147832CCC071B1A8800000A01561212D7A22C1A8B00000A014EA12CCA43FC1A8A00000AA040F70FB5C7331A8D00000AA040F60FB5C7831A8900000AA049E20FB5C7D41A8800000AA046B00FB5C9551A8800000A64CD650FB5B2111A8800000A64C0DC0FB5B1CF1A8A00000A64C80A0FB5B1641A8B00000A64C1AA0FB5B5AF1A8800000A9404EC482900331A8B00000A940657482900AA1A8C00000A94064B482900871A8D00000A94032D482900C11A8A0000";
                // Original length = 2482
                string cc = "F640BB78A2E78CBB6C6C16F2C4D35A8DC10400000000000000000400E80300007B22726567696F6E735B305D7C726567696F6E6964223A22307838453841384141433831453737314237222C22726567696F6E735B305D7C656E64706F696E74223A22334DC02D22726567696F6E735B315D7C726567696F6E6964223A22307838453841384141433831464137314234222C22726567696F6E735B315D7C656E64706F696E74223A22" + "3132372E302E302E31" + "222C22726567696F6E735B325D7C726567696F6E6964223A22307838453841384141433831464137314237222C22726567696F6E735B325D7C656E64706F696E74223A2267616D656C6966742E61702D736F757468656173742D312E616D617A6F6E6177732E636F6D222C22726567696F6E735B335D7C726567696F6E6964223A22307836464239413131353237464141304631222C22726567696F6E735B335D7C656E64706F696E74223A2267616D656C6966742E75732D656173742D312E616D617A6F6E6177732E636F6D222C22726567696F6E735B345D7C726567696F6E6964223A22307836464239413131353237464141304632222C22726567696F6E735B345D7C656E64706F696E74223A2267616D656C6966742E75732D656173742D322E616D617A6F6E6177732E636F6D222C22726567696F6E735B355D7C726567696F6E6964223A22307836464239413131353237464141364631222C22726567696F6E735B355D7C656E64706F696E74223A227261642D6368696361676F2D656E64706F696E742D6C622D313639313736343934332E75732D656173742D312E656C622E616D617A6F6E6177732E636F6D222C22726567696F6E735B365D7C726567696F6E6964223A22307836464239413131353237464141364632222C22726567696F6E735B365D7C656E64706F696E74223A227261642D64616C6C61732D656E64706F696E742D6C622D313639313736343934332E75732D656173742D312E656C622E616D617A6F6E6177732E63AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA6F6D222C22726567696F6E735B375D7C726567696F6E6964223A22307836464239413131353237464141364633222C22726567696F6E735B375D7C656E64706F696E74223A227261642D686F7573746F6E2D656E64706F696E742D6C622D3132333435363738392E75732D656173742D312E656C622E616D617A6F6E6177732E636F6D222C22726567696F6E735B385D7C726567696F6E6964223A22307836464239413131353237464142324631222C22726567696F6E735B385D7C656E64706F696E74223A2267616D656C6966742E75732D776573742D312E616D617A6F6E6177732E636F6D222C22726567696F6E735B395D7C726567696F6E6964223A22307836464239413131353337464341364631222C22726567696F6E735B395D7C656E64706F696E74223A2267616D656C6966742E65752D63656E7472616C2D312E616D617A6F6E6177732E636F6D222C22726567696F6E735B31305D7C726567696F6E6964223A22307836464239413131353337464342324632222C22726567696F6E735B31305D7C656E64706F696E74223A2267616D656C6966742E65752D776573742D322E616D617A6F6E6177732E636F6D6D6D6D6D6D6D6D6D6D6D6D6D6D6D6D6D6D6D6D6D6D6D6D6D6D6D6D6D6D6D6D6D6D6D6D227D";

                socket.Send(Convert.FromHexString(aa));
                socket.Send(Convert.FromHexString(bb));
                socket.Send(Convert.FromHexString(cc));

                Console.WriteLine("[MATCHMAKER] Data Sent");
            };

            socket.OnError = ex => {
                Console.WriteLine($"[MATCHMAKER] Exception: {ex.Message}");
                socket.Send("Ok");
            };
        });
    }

    private static void StartTransactionServer() {
        WebSocketServer server = new WebSocketServer("ws://127.0.0.1:8002");

        server.Start(socket => {
            socket.OnOpen = () => {
                Console.WriteLine("[TRANSACTION] Open!");
            };

            socket.OnClose = () => {
                Console.WriteLine("[TRANSACTION] Close!");
            };

            socket.OnMessage = message => {
                Console.WriteLine($"[TRANSACTION] MESSAGE RECEIVED: {message}");
                socket.Send("Ok");
            };

            socket.OnBinary = bytes => {
                Console.WriteLine($"[TRANSACTION] DATA RECEIVED: {Encoding.UTF8.GetString(bytes)}");

                socket.Send("Ok");

                Console.WriteLine("[TRANSACTION] Data Sent");
            };

            socket.OnError = ex => {
                Console.WriteLine($"[TRANSACTION] Exception: {ex.Message}");
                socket.Send("Ok");
            };
        });
    }
}