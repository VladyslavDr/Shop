using log4net;
using ShopConsoleApp.Models;
using ShopConsoleApp.Models.ProductModels;

namespace ShopConsoleApp.Dao;

public class MemoryCartDao : ICartDao
{
    private static MemoryCartDao _instance = null;

    private readonly Dictionary<Guid, CartModel> _carts = [];
    private readonly ILog _log = LogManager.GetLogger(typeof(MemoryCartDao));

    private MemoryCartDao()
    {
    }
    public static MemoryCartDao Instance => _instance ??= new MemoryCartDao();
    public void CreateCart(CartModel cart)
    {
        _carts.Add(cart.Id, cart);

        _log.Info($"Cart for user has been successfully inserted.");
    }

    public void CreateCartItem(CartModel cart, ProductModel product, int count)
    {
        var productItem = new CartItem(product.Id, count);
        cart.CartItems.Add(productItem);
    }

    public CartModel GetCart(Guid userId)
    {
        foreach (var cart in _carts.Values)
        {
            if (cart.UserId == userId)
            {
                return cart;
            }
        }

        throw new ArgumentException("dsgdsfhdsdfhhdshdshdhds");
    }
}