namespace xuanthulab.events;

public class Publisher
{
    // Thay vì sử dụng một delegate tự định nghĩa, ta có thể sử dụng sẵn có delegate EventHandler
    public event EventHandler<MyEventArgs>? Notify;

    public void SendNews()
    {
        Notify?.Invoke(this, new MyEventArgs("My name is Tuan"));
    }
}