namespace SignalRVite.Hubs;

public class ReceivedMessage
{
    public string Message { get; set; }
    public long Time { get; set; }

    public ReceivedMessage(string message)
    {
        Message = message;
        Time = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
    }
}