namespace ShopConsoleApp.Exceptions;

public class UserNotFoundException : ApplicationException
{
    public UserNotFoundException() : base($"User not found")
    {
    }

    public UserNotFoundException(string email) :base($"User width {email} not found")
    {
    }
}