namespace ShopConsoleApp.Models;

public class UserModel(string email, string password)
{
    public Guid Id { get; } = Guid.NewGuid();
    public string Email => email;
    public string Password { get; set; } = password;
    public override string ToString() => $"[{Id}] : [{Email}]";
}