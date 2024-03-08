namespace ShopConsoleApp.Exceptions;

public class InvalidEmailException(string email) : ApplicationException($"Invalid email: {email}");