using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System;
using System.Threading;

public class TCPServer : MonoBehaviour
{
    // Start is called before the first frame update

    private TcpListener server;
    private TcpClient client;
    private Thread serverThread;

    private ICommandReceiver commandReceiver;

    private const string FILE_NAME = "abd.txt";
    void Start()
    {
        serverThread = new Thread( new ThreadStart(WaitingForRequest));
        serverThread.IsBackground = true;
    }
     
    public bool IsRUnfdsd = false;

    public void StartTCPServer()
    {
        serverThread.Start();
    }

    public void SetCommandReceiver(ICommandReceiver newReceiver)
    {
        commandReceiver = newReceiver;
    }

    public void WaitingForRequest()
    {
        try
        {
            server = new TcpListener(IPAddress.Parse("127.0.0.1"), 2565);
            server.Start();

            Debug.Log(IsRUnfdsd);


            while (true)
            {
                Debug.Log("Waiting for connection");
                IsRUnfdsd = true;

                Debug.Log(IsRUnfdsd);


                client = server.AcceptTcpClient();
                Debug.Log("Client connected");

                NetworkStream stream = client.GetStream();

                var buffer = new byte[1024];
                int bytesRead;
                while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    File.WriteAllBytes(FILE_NAME, buffer);
                }
                Debug.Log("Yeah!!!");

                string input = File.ReadAllText(FILE_NAME);

                // Parser parser = new Parser();
                // Command command = parser.ParseToCommand(Int32.Parse(input));
                commandReceiver.DoAction(Int32.Parse(input));
            }
        }
        catch (Exception e)
        {
            Debug.Log(e.ToString());
        }
    }

}
