using System.Text;
using ShopConsoleApp.Models.ProductModels;
using ShopConsoleApp.Services;

namespace ShopConsoleApp.Models;

public class CartModel(Guid userId)
{
    private readonly UserService _userService = UserService.Instance;

    public Guid Id { get; } = Guid.NewGuid();
    public Guid UserId => userId;
    public List<CartItem> CartItems { get; } = [];
    public decimal TotalPrice { get; set; } = 0m;
}