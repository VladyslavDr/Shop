using log4net;
using ShopConsoleApp.Dao;
using ShopConsoleApp.Exceptions;
using ShopConsoleApp.Models;
using ShopConsoleApp.Models.ProductModels;

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
        _cartDao.CreateCart(cart);
    }

    public void AddProduct(CartModel cart, ProductModel product, int count)
    {
        _cartDao.CreateCartItem(cart, product, count);
    }

    // todo зробити одним методом
    public void AddQuantityToProduct(CartModel cart, ProductModel product, int count)
    {
        foreach (var cartItem in cart.CartItems)
        {
            if (cartItem.ProductId == product.Id)
            {
                cartItem.Count += count;
            }
        }
    }

    public CartModel GetCartByUserId(Guid userId)
    {
        return _cartDao.GetCart(userId);
    }
}