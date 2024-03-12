using System.Text;
using ShopConsoleApp.Models.ProductModels;
using ShopConsoleApp.Services;

namespace ShopConsoleApp.Models;

public class CartModel(Guid userId)
{
    private readonly UserService _userService = UserService.Instance;

    public Guid Id { get; } = Guid.NewGuid();
    public Guid UserId => userId;

    // public List<(ProductModel,int)> Products { get; } = [];
    public List<CartItem> CartItems { get; } = [];
    private decimal TotalPrice
    {
        get
        {
            decimal total = 0m;

            //foreach (var product in Products)
            //{
            //    total += product.Item1.Price * product.Item2;
            //}

            foreach (var cartItem in CartItems)
            {
                total += cartItem.Product.Price * cartItem.Count;
            }

            return total;
        }
    }
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
            sbCart.Append($"{count++}) {cartItem.Product} {cartItem.Count} pcs.\n");
        }

        sbCart.Append($"Total price: {TotalPrice}\n");
        return sbCart.ToString();
    }
}