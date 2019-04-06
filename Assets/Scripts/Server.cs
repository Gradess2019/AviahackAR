using System;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Net;
using System.Diagnostics;
using System.Text;
using System.IO;


namespace samplenamespace
{

	public class SampleClass
	{

		private System.Threading.Thread  SocketThread;
		public volatile bool keepReading = false;

		public void Start()
		{
			Application.runInBackground = true;
			startServer();
		}

		private void startServer()
		{
			SocketThread = new System.Threading.Thread(networkCode);
			SocketThread.IsBackground = true;
			SocketThread.Start();
		}

		private string getIPAddres()
		{
			IPHostEntry host;
			string localIP = "";
			host = Dns.GetHostEntry(Dns.GetHostName());
			foreach (IPAddress ip in host.AddressList)
			{
				localIP = ip.ToString();
			}
		}

		public Socket listner;
		public Socket handler;

		private void networkCode()
		{
			string data;

			byte[] bytes = new Byte[1024];

			Debug.Log("IP" + getIPAddres().ToString());
			IPAddress[] ipArray = Dns.GetHostAddresses(getIPAddres());
			IPEndPoint localEndPiont = new IPEndPoint(ipArray[0], 1755);

			listner = new Socket(ipArray[0].AddressFamily, SocketType.Stream, ProtocolType.Tcp);

			try
			{
				keepReading = true;

				Debug.Log("Waiting for conntection!");

				handler = listner.Accept();
				Debug.Log("Client Connected");
				data = null;

				while (keepReading)
				{
					bytes = new byte[1024];
					int bytesRec = handler.Receive(bytes);
					Debug.Log("Received from Server");

					if (bytesRec <= 0)
					{
						keepReading = false;
						handler.Disconnect(true);
						break;
					}

					data += Encoding.ASCII.GetString(bytes, 0, bytesRec);
					if (data.IndexOf("<EOF>") > -1)
					{
						break;
					}

					System.Threading.Thread.Sleep(1);
				}

				System.Threading.Thread.Sleep(1);

			}
			catch (Execution e)
			{
				Debug.Log(e.ToString());
			}
		}

		public void StopServer()
		{
			keepReading = false;

			if(SocketThread != null)
			{
				SocketThread.Abort();
			}

			if (handler != null && handler.Connected)
			{
				handler.Disconnect(false);
				Debug.Log("Disconntected!");
			}

		}

		public void OnDisable()
		{
			StopServer();
		}
	}
}


namespace TcpListnerApp
{
	public class Programm
	{
		const int port = 8888;
		static void Main(string args[])
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


					stream.Close();

					client.Close();
				}
			}
			catch(Exception e)
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
}