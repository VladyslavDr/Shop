using log4net;
using ShopConsoleApp.Dao;
using ShopConsoleApp.Exceptions;
using ShopConsoleApp.Models;
using ShopConsoleApp.Models.ProductModels;

namespace ShopConsoleApp.Services;

public class CartService
{
    private static CartService _instance = null;
    private readonly ILog _log = LogManager.GetLogger(typeof(CartService));

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
        foreach (var cartItem in cart.CartItems)
        {
            if (cartItem.ProductId == product.Id)
            {
                cartItem.Count += count;
                cart.TotalPrice += product.Price * count;
                return;
            }
        }

        _cartDao.CreateCartItem(cart, product, count);
        cart.TotalPrice += product.Price * count;
    }

    public CartModel GetCartByUserId(Guid userId)
    {
        return _cartDao.GetCart(userId);
    }
    public void ClearCartByUserId(Guid userId)
    {
        var cart = _cartDao.GetCart(userId);
        _cartDao.ClearCart(cart);
    }
}