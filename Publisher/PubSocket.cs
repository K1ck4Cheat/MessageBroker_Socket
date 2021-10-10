using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace Publisher
{
	class PubSocket
	{
		private Socket _socket;
		public bool IsConnected;

		public PubSocket()
		{
			_socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

		}

		public void Connect(String ipAdress, int port)
		{
			_socket.BeginConnect(new IPEndPoint(IPAddress.Parse(ipAdress),port),ConnectedCallback,null);
			Thread.Sleep(2000);

		}

		public void Send(byte[] data)		
		{
			try 
			{
				_socket.Send(data);
			}
			catch(Exception e)
			{
				Console.WriteLine($"could not send data. {e.Message}");
			}

		}

		private void ConnectedCallback(IAsyncResult asyncResult)
		{
			if (_socket.Connected)
			{
				Console.WriteLine("Sender connected to Broker");
			}
			else
			{
				Console.WriteLine("Error");
			}

			IsConnected = _socket.Connected;
		}
	}
}