using ShopConsoleApp.Models.ProductModels;

namespace ShopConsoleApp.Models;

public class CartItem (ProductModel product, int count)
{
    public Guid Id { get; } = Guid.NewGuid();
    public ProductModel Product { get; set; } = product;
    public int Count { get; set; } = count;
}