using System;
using System.Linq;
using Common;
using System.Text;
using System.Collections.Generic;

namespace Broker
{
	class ConnectionStorage
	{
		private static List<ConnectionInfo> _connections;
		private static object _locker;
	

	public ConnectionStorage()
	{
		_connections = new List<ConnectionInfo>();
		_locker = new object();
	}

	public static void Add(ConnectionInfo connection)
	{
		lock(_locker)
		{
			_connections.Add(connection);
		}
	}
	public static void Remove(string address)
	{
		lock(_locker)
		{
			_connections.RemoveAll(x => x.Address == address);
		}
	}
	public static List<ConnectionInfo> GetConnectionByTopic(string topic)
	{
		List<ConnectionInfo> selectedConnections;

		lock(_locker)
		{
			selectedConnections = _connections.Where(x => x.Topic == topic).ToList();

		}
		return selectedConnections;
	}
	}
}