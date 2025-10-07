using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using Assignment3;

namespace Assignment3
{
    public class TcpServer
    {
        private readonly int port = 5000;
        private readonly RequestValidator validator = new RequestValidator();
        private readonly UrlParser parser = new UrlParser();
        private readonly CategoryService categoryService = new CategoryService();

        public void Start()
        {
            var listener = new TcpListener(IPAddress.Any, port);
            listener.Start();
            Console.WriteLine($"TCP Server started on port {port}...");

            while (true)
            {
                var client = listener.AcceptTcpClient();
                var stream = client.GetStream();

                byte[] buffer = new byte[1024];
                int bytesRead = stream.Read(buffer, 0, buffer.Length);
                string requestText = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                Console.WriteLine($"Received: {requestText}");

                Request req = parser.ParseUrl(requestText);
                Response res = validator.ValidateRequest(req);

                string responseText = $"{res.StatusCode} {res.Status} {res.Message}";
                byte[] responseBytes = Encoding.UTF8.GetBytes(responseText);
                stream.Write(responseBytes, 0, responseBytes.Length);

                client.Close();
            }
        }
    }
}