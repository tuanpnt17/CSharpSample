namespace xuanthulab.events;

public class Publisher
{
    public delegate void NotifyNews(object data);
    // Thay vì sử dụng một delegate tự định nghĩa, ta có thể sử dụng sẵn có delegate EventHandler
    // public event EventHandler<string> Notify;
        

    public event NotifyNews? Notify;
    public void SendNews(string news)
    {
        Notify?.Invoke(news);
    }
}