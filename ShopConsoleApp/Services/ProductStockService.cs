using log4net;
using ShopConsoleApp.Dao;
using ShopConsoleApp.Models;
using ShopConsoleApp.Models.ProductModels;

namespace ShopConsoleApp.Services;

public class ProductStockService
{
    private static ProductStockService _instance = null;
    private readonly ILog _log = LogManager.GetLogger(typeof(ProductStockService));

    private readonly IProductStockDao _productStockDao = MemoryProductStockDao.Instance;

    private ProductStockService()
    {
    }

    public static ProductStockService Instance => _instance ??= new ProductStockService();

    public void CreateProductStock(ProductStock productStock) => _productStockDao.CreateProductStock(productStock);

    public Dictionary<Guid, ProductStock> GetAllProductStocks() => _productStockDao.GetAllProductStocks();
}