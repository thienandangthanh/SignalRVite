using Microsoft.AspNetCore.SignalR;

namespace SignalRWebpack.Hubs;

public class ChatHub : Hub<IChatClient>
{
    [HubMethodName("newMessage")]
    public async Task NewMessageAsync(long username, string message)
    {
        await Clients.Caller.MessageReceivedAsync(username, message);
    }
}