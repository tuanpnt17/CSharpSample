namespace xuanthulab.events;

public class SubscriberOne
{
    public void Sub(Publisher publisher)
    {
        publisher.Notify += ReceiveFromPublisher;
    }

    public void UnSub(Publisher publisher)
    {
        publisher.Notify -= ReceiveFromPublisher;
    }

    private void ReceiveFromPublisher(object? sender, MyEventArgs eventArgs)
    {
        System.Console.WriteLine("SubscriberOne: " + eventArgs.Data);
    }
}