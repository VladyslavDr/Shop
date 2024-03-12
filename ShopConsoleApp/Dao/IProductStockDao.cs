using ShopConsoleApp.Models;
using ShopConsoleApp.Models.ProductModels;

namespace ShopConsoleApp.Dao;

public interface IProductStockDao
{
    public void CreateProductStock(ProductStock productStock);
    Dictionary<Guid, ProductStock> GetAllProductStocks();
}