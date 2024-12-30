namespace xuanthulab.classobject;

public class Animal(string name, int age, string color)
{
    public string Name { get; set; } = name;
    public int Age { get; set; } = age;
    public string Color { get; set; } = color;

    public virtual void Speak()
    {
        Console.WriteLine("Hello, I'm an animal");
    }
}