using ShopConsoleApp.Models.ProductModels;

namespace ShopConsoleApp.Dao;

public interface IProductDao
{
    public void CreateProduct(ProductModel product);
    public Dictionary<Guid, ProductModel> GetAllProduct();
    public ProductModel GetProductById(Guid id);
}