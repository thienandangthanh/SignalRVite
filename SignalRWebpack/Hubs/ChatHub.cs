using Microsoft.AspNetCore.SignalR;

namespace SignalRWebpack.Hubs;

public class ChatHub : Hub<IChatClient>
{
    [HubMethodName("newMessage")]
    public async Task NewMessageAsync(long username, string message)
    {
        if (message == "THROW_ME_ERROR")
        {
            throw new HubException("Here's your error");
        }
        await Clients.Caller.MessageReceivedAsync(username, message);
    }
}