namespace ShopConsoleApp.Exceptions;

public class UserAlreadyExistsException() : ApplicationException("User with this login already exists.");