using log4net;
using ShopConsoleApp.Dao;
using ShopConsoleApp.Exceptions;
using ShopConsoleApp.Models;

namespace ShopConsoleApp.Services;

public class CartService
{
    private static CartService _instance = null;
    private readonly ILog _log = LogManager.GetLogger(typeof(Solution));

    // Dao pattern
    private readonly ICartDao _cartDao = MemoryCartDao.Instance; //todo static?

    private CartService()
    {
    }
    public static CartService Instance => _instance ??= new CartService();

    public void CreateCart(Guid userId)
    {
        CartModel cart = new(userId);
        _cartDao.AddCart(cart);
    }

    public void AddProduct(CartModel cart, ProductModel product, int count)
    {
        _cartDao.AddProduct(cart, product, count);
    }

    public CartModel GetCartByUserId(Guid userId)
    {
        return _cartDao.GetCart(userId);
    }
}