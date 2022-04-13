using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace SignalR_Hub
{
	[HubName("chatHub")]
	public class ChatHub : Hub
	{
		public override Task OnConnected()
		{
			ConnectedUser.connections.Add(Context.ConnectionId);
			return base.OnConnected();
		}
		public override Task OnDisconnected(bool stopCalled)
		{
			ConnectedUser.connections.Remove(Context.ConnectionId);
			return base.OnDisconnected(stopCalled);
		}

		public void SendToWinForm(string eventName, object data)
		{
			Clients.All.SendMessageToWinForm(eventName, data);
		}

		public void SendToWebApp(string eventName, object data)
		{
			Clients.All.SendMessageToWebApp(eventName, data);
		}
	}

	public static class ConnectedUser
	{
		public static List<string> connections = new List<string>();
	}

	
}