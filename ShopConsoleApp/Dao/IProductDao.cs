using ShopConsoleApp.Models.ProductModels;

namespace ShopConsoleApp.Dao;

public interface IProductDao
{
    public void CreateProduct(ProductModel product);
    public Dictionary<Guid, ProductModel> GetAllProduct();
}