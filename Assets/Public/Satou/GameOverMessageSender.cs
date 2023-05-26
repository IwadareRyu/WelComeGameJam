using UniRx;

public struct GameOverMessage
{
}

public static class GameOverMessageSender
{
    public static void SendMessage()
    {
        MessageBroker.Default.Publish(new GameOverMessage());
    }
}
