namespace xuanthulab.events;

public class SubscriberTwo
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
        System.Console.WriteLine("SubscriberTwo: " + data);
    }
}