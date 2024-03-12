namespace ShopConsoleApp.Models.ProductModels;

public class TableProductModel(string title, decimal price) : ProductModel(title, price)
{
    public string Brand { get; set; } = "unidentified";
    public string Type { get; set; } = "unidentified";
    public (double, double, double) Dimensions { get; set; } = (0, 0, 0);
    public string Material { get; set; } = "unidentified";
}