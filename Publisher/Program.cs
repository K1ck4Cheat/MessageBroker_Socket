using System;
using System.Text;
using Common;
using Newtonsoft.Json;

namespace Publisher
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Publisher");

			var pubSocket = new PubSocket();
			pubSocket.Connect(Settings.BROKER_IP, Settings.BROKER_PORT);

			if (pubSocket.IsConnected)
			{
				var payload = new Payload();

				Console.Write("topik: ");
				payload.Topic = Console.ReadLine().ToLower();

				Console.Write("Message: ");
				payload.Message = Console.ReadLine();

				var payloadString = JsonConvert.SerializeObject(payload);
				byte[] data = Encoding.UTF8.GetBytes(payloadString);

				pubSocket.Send(data);

			}
			
			Console.ReadLine();
		}
	}
}