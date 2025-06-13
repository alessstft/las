public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public decimal Price { get; set; }

    public int CategoryId { get; set; }
    public Category Category { get; set; } = null!;

    public List<OrderItem> OrderItems { get; set; } = new();
    public List<ProductTag> ProductTags { get; set; } = new();
}
