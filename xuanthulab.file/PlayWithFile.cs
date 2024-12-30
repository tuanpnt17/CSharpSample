namespace xuanthulab.file
{
    public static class PlayWithFile
    {
        public static void DirectoryExample()
        {
            Console.WriteLine("Directory Example");
            var documentDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var files = Directory.GetFiles(documentDirectory);
            var directories = Directory.GetDirectories(documentDirectory);
            foreach (var file in files)
            {
                Console.WriteLine("File: " + file);
            }
            foreach (var directory in directories)
            {
                Console.WriteLine("Directory: " + directory);
            }
            Console.WriteLine("List all file in directory recursively");
            ListAllFiles(documentDirectory);
        }

        private static void ListAllFiles(string path)
        {
            var files = Directory.GetFiles(path);
            foreach (var file in files)
            {
                Console.WriteLine("File: " + file);
            }
            var directories = Directory.GetDirectories(path);
            foreach (var directory in directories)
            {
                Console.WriteLine("Directory: " + directory);
                ListAllFiles(directory);
            }
        }
        public static async Task PathExample()
        {
            Console.WriteLine("Path Example");
            Directory.CreateDirectory("test");
            var path = Path.Combine(Directory.GetCurrentDirectory(), "test", "test.txt");
            await File.AppendAllTextAsync(path, "Hello World");

            Console.WriteLine("File Path: " + path);
            //Read file
            var content = await File.ReadAllTextAsync(path);
            Console.WriteLine(content);

        }

        public static void DriveInfoExample()
        {
            Console.WriteLine("Drive Info");
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in drives)
            {
                Console.WriteLine("Drive Name: " + drive.Name);
                Console.WriteLine("Drive Type: " + drive.DriveType);
                Console.WriteLine("Drive Format: " + drive.DriveFormat);
                Console.WriteLine("Total Size: " + drive.TotalSize);
                Console.WriteLine("Total Free Space: " + drive.TotalFreeSpace);
                Console.WriteLine("Available Free Space: " + drive.AvailableFreeSpace);
                Console.WriteLine();
            }
        }
    }
}
