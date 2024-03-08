using System.Text;

namespace ShopConsoleApp.Models;

public class CartModel(Guid userId)
{
    public Guid Id { get; } = Guid.NewGuid();
    public Guid UserId => userId;
    public List<(ProductModel,int)> Products { get; } = [];

    public decimal TotalPrice
    {
        get
        {
            decimal total = 0m;

            foreach (var product in Products)
            {
                total += product.Item1.Price * product.Item2;
            }

            return total;
        }
    }

    public override string ToString()
    {
        var sbCart = new StringBuilder();
        int count = 1;

        if (Products.Count == 0)
        {
            return "Cart is empty";
        }

        foreach (var product in Products)
        {
            sbCart.Append($"{count++}) {product.Item1} {product.Item2} pcs.\n");
        }

        sbCart.Append($"Total price: {TotalPrice}\n");
        return sbCart.ToString();
    }
}