namespace ShopConsoleApp.Models.ProductModels;

public class BookProductModel(string title, decimal price) : ProductModel
{
    public override string Title => title;
    public override decimal Price { get; set; } = price;

    public string Author { get; set; } = "unidentified";
    public string Publisher { get; set; } = "unidentified";
    public string Language { get; set; } = "unidentified";
}