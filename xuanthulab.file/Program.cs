namespace xuanthulab.file
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            //PlayWithFile.DriveInfoExample();

            await PlayWithFile.PathExample();
            Console.WriteLine("Done");
            PlayWithFile.DirectoryExample();
        }


    }
}
