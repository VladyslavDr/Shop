using log4net;
using ShopConsoleApp.Dao;
using ShopConsoleApp.Models.ProductModels;

namespace ShopConsoleApp.Services;

public class ProductService
{
    private static ProductService _instance = null;
    private readonly ILog _log = LogManager.GetLogger(typeof(ProductService));

    private readonly IProductDao _productDao = MemoryProductDao.Instance;

    private ProductService()
    {
    }

    public static ProductService Instance => _instance ??= new ProductService();

    public void CreateProduct(ProductModel product)
    {
        _productDao.CreateProduct(product);
    }
    public Dictionary<Guid, ProductModel> GetAllProduct() => _productDao.GetAllProduct();

    public ProductModel GetProductById(Guid productId) => _productDao.GetProductById(productId);
}