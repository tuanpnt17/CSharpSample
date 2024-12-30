namespace xuanthulab.events
{
    /// <summary>
    /// Đây là class chứa thông tin của sự kiện, sẽ được gửi đi cùng với sự kiện cho các subscriber
    /// </summary>
    public class MyEventArgs(string data) : EventArgs
    {
        /// <summary>
        /// Dữ liệu của sự kiện ở đây chỉ có thể đọc mà sẽ không được thay đổi bởi các subscriber
        /// </summary>
        public string Data { get; } = data;
    }
}
