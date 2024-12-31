namespace xuanthulab.linq;

public class Product
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public int BrandId { get; set; }
    public required string[] Colors { get; set; }
    public double Price { get; set; }

    public override string ToString()
    {
        return $"Id: {Id}, Name: {Name}, BrandId: {BrandId}, Colors: {string.Join(",", Colors)}, Price: {Price}";
    }
}