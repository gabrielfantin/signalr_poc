namespace wss.SignalHubs;

public interface ITopicManager
{
    Task ListenTo(string topic);
    Task SendEventToTopic(string eventBody, string topic);
    Task ReceiveEvent(string eventBody);
}
