using System;
using Common;
using System.Text;
using Newtonsoft.Json;
using System.Linq;

namespace Broker
{
	class PayloadHandler
	{
		public static void Handle(byte[] PayloadBytes,ConnectionInfo connectionInfo)
		{
			var payloadString = Encoding.UTF8.GetString(PayloadBytes);

			if (payloadString.StartsWith("subscribe#"))
			{
				connectionInfo.Topic = payloadString.Split("subscribe#").LastOrDefault();
                    ConnectionsStorage.Add(connectionInfo);

			}
			else
			{
				Payload payload = JsonConvert.DeserializeObject<Payload>(payloadString);

				PayloadStorage.Add(payload);
			}

			
		}
	}
}