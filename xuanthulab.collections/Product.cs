namespace xuanthulab.collections;

public class Product : IComparable<Product>, IFormattable
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public double Price { get; set; }
    public required string Origin { get; set; }

    public string ToString(string? format, IFormatProvider? formatProvider)
    {
        format ??= "O";

        return format.ToUpper() switch
        {
            "O" => $"Xuất xứ: {Origin} - Tên: {Name} - Giá: {Price} - ID: {Id}",
            "N" => $"Tên: {Name} - Xuất xứ: {Origin} - Giá: {Price} - ID: {Id}",
            _ => throw new FormatException("Không hỗ trợ format này")
        };
    }

    public int CompareTo(Product? other)
    {
        if (other == null) return 1;
        var delta = this.Price - other.Price;
        return delta switch
        {
            > 0 => 1,
            < 0 => -1,
            _ => 0
        };
    }

    public string ToString(string? format)
    {
        return ToString(format, null);
    }

}