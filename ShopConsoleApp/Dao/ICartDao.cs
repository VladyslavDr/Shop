using ShopConsoleApp.Models;
using ShopConsoleApp.Models.ProductModels;

namespace ShopConsoleApp.Dao;

public interface ICartDao
{
    public void CreateCart(CartModel cart);
    public void AddProduct(CartModel cart, ProductModel product, int count);
    public CartModel GetCart(Guid userId);
}