namespace xuanthulab.classobject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Animal dog = new Dog("Dog", 2, "Black");
            dog.Speak();
            Animal cat = new Cat("Cat", 3, "White");
            cat.Speak();
            Swap<Animal>(ref dog, ref cat);
            Console.WriteLine("After swap");
            dog.Speak();
            cat.Speak();

            dynamic student = new
            {
                Name = "Nguyen Van A",
                Address = "Ha Noi"
            };
            Console.WriteLine($"Student: {student.Name}, {student.Age}, {student.Address}");

        }

        public static void Swap<T>(ref T a, ref T b) => (a, b) = (b, a);

    }
}
