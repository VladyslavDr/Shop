using log4net;
using ShopConsoleApp.Models;

namespace ShopConsoleApp.Dao;

public class MemoryCartDao : ICartDao
{
    private static MemoryCartDao _instance = null;

    private readonly Dictionary<Guid, CartModel> _carts = [];
    private static readonly ILog Log = LogManager.GetLogger(typeof(MemoryCartDao));

    private MemoryCartDao()
    {
    }
    public static MemoryCartDao Instance => _instance ??= new MemoryCartDao();
    public void AddCart(CartModel cart)
    {
        _carts.Add(cart.Id, cart);

        Log.Info($"Cart for user has been successfully inserted.");
    }

    // todo розібрати і можливо переписати AddProduct() від gpt
    public void AddProduct(CartModel cart, ProductModel product, int count)  
    {
        // Перевірка чи продукт вже є в корзині
        int existingIndex = -1;

        for (int i = 0; i < cart.Products.Count; i++)
        {
            if (cart.Products[i].Item1.Equals(product))
            {
                existingIndex = i;
                break;
            }
        }

        if (existingIndex != -1)
        {
            // Оновлення кількості, якщо продукт вже існує
            var existingProduct = cart.Products[existingIndex];
            cart.Products[existingIndex] = (existingProduct.Item1, existingProduct.Item2 + count);
        }
        else
        {
            // Додавання нового продукту, якщо його немає в корзині

            // _carts[cart.Id].Products.Add((product, count)); 
            // todo навіщо так якщо можна так
            cart.Products.Add((product, count));
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