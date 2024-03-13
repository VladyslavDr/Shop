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
            if (product.Title == "Harry Potter and Philosopher's Stone")
            {
                shop.AddProductToCart(email, product, 1);
                shop.ViewCartUser(email);
                Console.WriteLine();
            }
        }

        foreach (var product in products)
        {
            if (product.Title == "Harry Potter and Philosopher's Stone")
            {
                shop.AddProductToCart(email, product, 2);
                shop.ViewCartUser(email);
                Console.WriteLine();
            }
        }

        shop.CreateOrder(email);
        shop.ViewCartUser(email);
        shop.ViewOrdersUser(email);

        foreach (var product in products)
        {
            if (product.Title == "Harry Potter and Philosopher's Stone")
            {
                shop.AddProductToCart(email, product, 5);
                shop.ViewCartUser(email);
                Console.WriteLine();
            }
        }

        shop.CreateOrder(email);
        shop.ViewOrdersUser(email);
    }
}