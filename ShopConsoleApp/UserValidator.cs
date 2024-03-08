using ShopConsoleApp.Services;

namespace ShopConsoleApp;

//todo create class Validator
public class UserValidator
{
    private static UserValidator _instance = null;
    private UserValidator()
    {
    }

    public static UserValidator Instance => _instance ??= new UserValidator();
}