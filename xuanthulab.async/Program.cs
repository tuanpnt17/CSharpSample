using static System.Threading.Thread;

namespace xuanthulab.async
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine($"Main thread {Environment.CurrentManagedThreadId, 3}");
            var t1 = GetAsyncWithTaskFunc("Tuan", 20);
            var t2 = GetAsyncWithNoReturn();
            Console.WriteLine("Do something when 2 task is running");
            t1.Wait();
            var result = t1.Result;
            Print(result, ConsoleColor.Red);

            Console.ReadKey();
        }

        public static void Print(string message, ConsoleColor color = ConsoleColor.Cyan)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
        }

        public static Task<string> GetAsyncWithTaskFunc(string name, int age)
        {
            Console.WriteLine($"Async1: Start Task with {Environment.CurrentManagedThreadId}");
            var task = new Task<string>(MyFunc, new { x = name, y = age });
            Console.WriteLine($"Async1: assign task {Environment.CurrentManagedThreadId}");
            task.Start();
            Console.WriteLine(
                $"Task started! Doing something else {Environment.CurrentManagedThreadId}"
            );
            return task;

            string MyFunc(object? state)
            {
                dynamic? ts = state;
                for (var i = 0; i < 10; i++)
                {
                    Print(
                        $"{i, 5} - {Environment.CurrentManagedThreadId, 3} - Parameter {ts?.x} - {ts?.y}"
                    );
                    Sleep(500);
                }

                return $"Finish Async1! {ts?.x}";
            }
        }

        public static Task GetAsyncWithNoReturn()
        {
            var task = new Task(MyAction);
            task.Start();

            // Làm gì đó sau khi chạy Task ở đây
            Console.WriteLine("Async2: Làm gì đó sau khi task chạy");

            return task;

            void MyAction()
            {
                for (var i = 1; i <= 10; i++)
                {
                    Print($"{i, 5} {Environment.CurrentManagedThreadId, 3}", ConsoleColor.Yellow);
                    Thread.Sleep(2000);
                }
            }
        }
    }
}
