﻿using log4net;
using ShopConsoleApp.Models;
using ShopConsoleApp.Models.ProductModels;
using ShopConsoleApp.Services;

namespace ShopConsoleApp.Dao;

public class MemoryProductDao : IProductDao
{
    private static MemoryProductDao _instance = null;
    
    private readonly Dictionary<Guid, ProductModel> _products = [];
    private readonly ILog _log = LogManager.GetLogger(typeof(MemoryCartDao));

    private MemoryProductDao()
    {
    }

    public static MemoryProductDao Instance => _instance ??= new MemoryProductDao();
    public Dictionary<Guid, ProductModel> GetAllProduct() => _products;
    public void CreateProduct(ProductModel product) => _products.Add(product.Id, product);
}