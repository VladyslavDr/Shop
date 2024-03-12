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
    private decimal TotalPrice { get; set; } = 0m;

    public override string ToString()
    {
        var sbCart = new StringBuilder();
        int count = 1;

        if (CartItems.Count == 0)
        {
            return "Cart is empty";
        }

        foreach (var cartItem in CartItems)
        {
            // todo ProductId -> Title
            sbCart.Append($"{count++}) {cartItem.ProductId} {cartItem.Count} pcs.\n");
        }

        sbCart.Append($"Total price: {TotalPrice}\n");
        return sbCart.ToString();
    }
}