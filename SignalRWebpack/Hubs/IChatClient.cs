using Microsoft.AspNetCore.SignalR;

namespace SignalRWebpack.Hubs;

public interface IChatClient
{
    [HubMethodName("messageReceived")]
    Task MessageReceivedAsync(long user, ReceivedMessage message);
}