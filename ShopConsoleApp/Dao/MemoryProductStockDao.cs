using log4net;
using ShopConsoleApp.Models;
using ShopConsoleApp.Models.ProductModels;

namespace ShopConsoleApp.Dao;

public class MemoryProductStockDao : IProductStockDao
{
    private static MemoryProductStockDao _instance = null;

    private readonly Dictionary<Guid, ProductStock> _productStocks = [];
    private readonly ILog _log = LogManager.GetLogger(typeof(MemoryCartDao));

    private MemoryProductStockDao()
    {
    }

    public static MemoryProductStockDao Instance => _instance ??= new MemoryProductStockDao();
    public void CreateProductStock(ProductStock productStock) => _productStocks.Add(productStock.Id, productStock);
    public Dictionary<Guid, ProductStock> GetAllProductStocks() => _productStocks;
}