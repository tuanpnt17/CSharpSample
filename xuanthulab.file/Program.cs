namespace xuanthulab.file
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            //PlayWithFile.DriveInfoExample();

            //await PlayWithFile.PathExample();
            //Console.WriteLine("Done");
            //PlayWithFile.DirectoryExample();

            //PlayWithStream.StreamExample();
            //PlayWithStream.WriteFileStreamExample();
            //Console.WriteLine(@"-------------");
            //PlayWithStream.ReadFileStreamExample();

            var student = new Student
            {
                Id = 1,
                Name = "Nguyen Van A",
                Birthday = new DateTime(2000, 1, 1),
                Gpa = 3.5
            };
            PlayWithStream.WriteFileBinary("student.json", student);
        }


    }
}
