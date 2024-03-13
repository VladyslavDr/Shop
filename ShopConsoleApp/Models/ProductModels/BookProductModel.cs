namespace ShopConsoleApp.Models.ProductModels;

public class BookProductModel(string title, decimal price) : ProductModel(title, price)
{
    public string Author { get; set; } = "unidentified";
    public string Publisher { get; set; } = "unidentified";
    public string Language { get; set; } = "unidentified";


}