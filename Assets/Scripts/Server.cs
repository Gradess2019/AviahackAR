using System;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Net;
using System.Diagnostics;
using System.Text;
using System.IO;

public class Programm : MonoBehavior
{
    const int port = 8888;
    static void Main(string[] args)
    {
        TcpListener server = null;
        try
        {
            IPAddress localhost = IPAddress.Parse("127.0.0.1");
            server = new TcpListener(localhost, port);

            server.Start();

            while (true)
            {
                Debug.Log("Waiting for connection");

                TcpClient client = server.AcceptTcpClient();
                Debug.Log("Client connected");

                NetworkStream stream = client.GetStream();

                var buffer = new byte[1024];
                int bytesRead;
                while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    File.WriteAllBytes("abd.json", buffer);
                }
                Debug.Log("Yeah!!!");

                stream.Close();

                client.Close();
            }
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }
        finally
        {
            if (server != null)
                server.Stop();
        }
    }
}
