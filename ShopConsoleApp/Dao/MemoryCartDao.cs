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

    public void AddProduct(CartModel cart, ProductModel product, int count)  
    {
        // Перевірка чи продукт вже є в корзині
        int existingIndex = -1;

        for (int i = 0; i < cart.CartItems.Count; i++)
        {
            //if (cart.Products[i].Item1.Equals(product))
            //{
            //    existingIndex = i;
            //    break;
            //}

            if (cart.CartItems[i].Product.Id.Equals(product.Id))
            {
                existingIndex = i;
                break;
            }
        }

        if (existingIndex != -1)
        {
            // Оновлення кількості, якщо продукт вже існує
            var existingProduct = cart.CartItems[existingIndex];
            // cart.Products[existingIndex] = (existingProduct.Item1, existingProduct.Item2 + count);
            existingProduct.Count = count;
        }
        else
        {
            // Додавання нового продукту, якщо його немає в корзині

            // _carts[cart.Id].Products.Add((product, count));
            // cart.Products.Add((product, count));

            var cartItem = new CartItem(product, count);

            _carts[cart.Id].CartItems.Add(cartItem);
        }
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