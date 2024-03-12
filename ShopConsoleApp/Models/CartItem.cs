using ShopConsoleApp.Models.ProductModels;

namespace ShopConsoleApp.Models;

public class CartItem (Guid productId, int count)
{
    public Guid Id { get; } = Guid.NewGuid();
    public Guid ProductId { get; } = productId;
    public int Count { get; set; } = count;
}