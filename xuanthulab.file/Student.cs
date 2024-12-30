namespace xuanthulab.file
{
    [Serializable]
    public class Student
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public DateTime Birthday { get; set; }
        public string? Title { get; set; }
        public double Gpa { get; set; }

    }
}
