using System.ComponentModel.DataAnnotations;

namespace xuanthulab.attribute;

[Desc("This class represents a product.")]
public class Product
{
    [Required]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "Invalid Name")]
    [Desc("The name of the product.")]
    public required string Name { get; set; }

    [Range(minimum: 0, maximum: 100, ErrorMessage = "Price must be between 0 and 100")]
    [DataType(DataType.Currency)]
    [Desc("The price of the product.")]
    public int Price { get; set; }

    [Obsolete("This method is obsolete, use WriteProduct() instead.")]
    public void PrintProduct()
    {
        Console.WriteLine($"Name: {Name}, Price: {Price}");
    }

    [Desc("Write the product to the console.")]
    public void WriteProduct()
    {
        Console.WriteLine($"Name: {Name}, Price: {Price}");
    }
}
