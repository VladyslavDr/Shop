namespace ShopConsoleApp.Models.ProductModels;

public abstract class ProductModel(string title, decimal price)
{
    public Guid Id { get; } = Guid.NewGuid();
    public string Title { get; } = title;
    public string Description { get; set; } = "unidentified";
    public decimal Price { get; set; } = price;

    public override int GetHashCode() => Id.GetHashCode();

    public override string ToString()
    {
        return $"{Title} : {Price}UAH";
    }
}