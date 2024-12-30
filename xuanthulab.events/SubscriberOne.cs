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

    void ReceiveFromPublisher(object data)
    {
        System.Console.WriteLine("SubscriberOne: " + data);
    }
}