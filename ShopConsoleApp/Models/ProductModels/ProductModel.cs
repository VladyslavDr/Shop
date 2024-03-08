namespace ShopConsoleApp.Models.ProductModels;

public abstract class ProductModel
{
    public Guid Id { get; } = Guid.NewGuid();
    public abstract string Title { get; }
    public string Description { get; set; } = "unidentified";
    public abstract decimal Price { get; set; }

    public override int GetHashCode() => Id.GetHashCode();

    public override string ToString()
    {
        return $"{Title} : {Price}UAH";
    }
}