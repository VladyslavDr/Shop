using ShopConsoleApp.Enums;

namespace ShopConsoleApp.Models.ProductModels;

public class ShirtProductModel(string title, decimal price) : ProductModel(title, price)
{
    public string Brand { get; set; } = "unidentified";
    public ClothingSizes Size { get; set; }
    public string Material { get; set; } = "unidentified";
}