namespace ShopConsoleApp.Models;

public class OrderModel(Guid userId)
{
    public Guid Id { get; } = Guid.NewGuid();
    public Guid UserId => userId;
    public List<CartItem> CartItems { get; } = [];
    public decimal TotalPrice { get; set; } = 0m;

    public bool Status { get; set; }
}