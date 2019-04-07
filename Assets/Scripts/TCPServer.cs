using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System;

public class TCPServer : MonoBehaviour
{
    // Start is called before the first frame update

    private const int port = 8888;
    void Start()
    {
        Main();
    }

    private static void Main()
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
