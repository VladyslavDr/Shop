namespace ShopConsoleApp.Models;

public class TableProductModel(string title, decimal price) : ProductModel
{
    public override string Title => title;
    public override decimal Price { get; set; } = price;

    public string Brand { get; set; } = "unidentified";
    public string Type { get; set; } = "unidentified";
    public (double, double, double) Dimensions { get; set; } = (0, 0, 0);
    public string Material { get; set; } = "unidentified";
}