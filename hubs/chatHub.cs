using Microsoft.AspNetCore.SignalR;

#pragma warning disable CA1050 // Declare types in namespaces
public class ChatHub : Hub
#pragma warning restore CA1050 // Declare types in namespaces
{
    public async Task SendMessage(string user, string message)
    {
        await Clients.All.SendAsync("ReceiveMessage", user, message);
    }

    public async Task JoinRoom(string roomName)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, roomName);
    }

    public async Task LeaveRoom(string roomName)
    {
        await Groups.RemoveFromGroupAsync(Context.ConnectionId, roomName);
    }

    public async Task SendMessageToRoom(string user, string roomName, string message)
    {
        await Clients.Group(roomName).SendAsync("ReceiveMessage", user, message);
    }
}