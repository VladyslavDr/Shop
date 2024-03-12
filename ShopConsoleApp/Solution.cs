using log4net;
using ShopConsoleApp.Dao;
using ShopConsoleApp.Enums;
using ShopConsoleApp.Exceptions;
using ShopConsoleApp.Models;
using ShopConsoleApp.Models.ProductModels;
using ShopConsoleApp.Services;

namespace ShopConsoleApp;

public static class Solution
{
    public static void Run()
    {
        var shop = new ShopController();

        string email = "vlad@gmail.com";
        string password = "123456";

        shop.Register(email, password);
        Console.WriteLine();

        shop.Login(email, password);
        Console.WriteLine();

        var products = shop.GetAssortmentProducts().Values;

        foreach (var product in products)
        {
            if (product.Title == "Harry Potter and Philosopher's Stone"
                || product.Title == "Classic Fit Striped Poplin Fun Shirt")
            {
                shop.AddProductToCart(email, product, 1);
                shop.ShowCartUser(email);
            }
        }
    }
}