namespace ShopConsoleApp.Models;

public class ProductStock(Guid productId, int count)
{
    public Guid Id { get; } = Guid.NewGuid();
    public Guid ProductId { get; set; } = productId;
    public int Count { get; set; } = count;
}