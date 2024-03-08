namespace ShopConsoleApp;

public class Test
{
    public Guid Id1 => Guid.NewGuid();
    public Guid Id2 { get; } = Guid.NewGuid();
}