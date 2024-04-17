using Microsoft.AspNetCore.SignalR;

namespace wss.SignalHubs;

public class DefaultHub : Hub<ITopicManager>
{
    public async Task ListenTo(string topic)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, topic);

        Console.WriteLine($"Connection {Context.ConnectionId} added to topic {topic}");
    }

    public async Task SendEventToTopic(string eventBody, string topic)
    {
        await Clients.Group(topic).ReceiveEvent(eventBody);

        Console.WriteLine($"Event {eventBody} sent to topic {topic}");
    }
}
