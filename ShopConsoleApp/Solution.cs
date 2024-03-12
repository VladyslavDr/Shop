using log4net;
using ShopConsoleApp.Dao;
using ShopConsoleApp.Enums;
using ShopConsoleApp.Exceptions;
using ShopConsoleApp.Models;
using ShopConsoleApp.Services;

namespace ShopConsoleApp;

public static class Solution
{
    public static void Run()
    {
        var shop = new ShopController();

        shop.Register();
        Console.WriteLine();

        shop.Login();
        Console.WriteLine();
    }
}