using Microsoft.AspNetCore.SignalR;

namespace SignalRVite.Hubs;

public interface IChatClient
{
    [HubMethodName("messageReceived")]
    Task MessageReceivedAsync(long user, ReceivedMessage message);
}