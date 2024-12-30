namespace xuanthulab.classobject;

public class Cat(string name, int age, string color) : Animal(name, age, color)
{

    public sealed override void Speak()
    {
        Console.WriteLine("Meow meow");
    }
    public void Meow()
    {
        Console.WriteLine("Meow meow");
    }
}