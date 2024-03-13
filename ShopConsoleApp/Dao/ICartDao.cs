using ShopConsoleApp.Models;
using ShopConsoleApp.Models.ProductModels;

namespace ShopConsoleApp.Dao;

public interface ICartDao
{
    public void CreateCart(CartModel cart);
    public void CreateCartItem(CartModel cart, ProductModel product, int count);
    public CartModel GetCart(Guid userId);
    public void ClearCart(CartModel cart);
}