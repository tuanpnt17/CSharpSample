namespace xuanthulab.events
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var publisher = new Publisher();
            var sub1 = new SubscriberOne();
            var sub2 = new SubscriberTwo();
            sub1.Sub(publisher);
            sub2.Sub(publisher);
            publisher.SendNews("Hello, World!");
            sub1.UnSub(publisher);
            publisher.SendNews("Goodbye, World!");
        }
    }
}