using ShopConsoleApp.Dao;
using ShopConsoleApp.Exceptions;
using ShopConsoleApp.Models;

namespace ShopConsoleApp.Services;

using log4net;
using System.Text.RegularExpressions;

// Singleton
public class UserService
{
    private static UserService _instance = null;
    private const string EmailRegex = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"; // розібратись
    private static readonly ILog Log = LogManager.GetLogger(typeof(UserService));
    private static readonly CartService CartService = Services.CartService.Instance;

    // Dao pattern
    private static readonly IUserDao UserDao = MemoryUserDao.Instance;

    private UserService()
    {
    }

    public static UserService Instance => _instance ??= new UserService(); //todo ??=
    private static bool IsCorrectEmail(string email) => Regex.IsMatch(email, EmailRegex);
    private static bool IsCorrectPassword(string password) => !string.IsNullOrEmpty(password);
    public UserModel Register(string? email, string? password)
    {
        if (UserDao.IsExists(email)) // del is
        {
            var ex = new UserAlreadyExistsException();

            Log.Error($"Email: {email}", ex);

            throw ex;
        }

        // validateUser()
        if (!IsCorrectEmail(email))
        {
            var ex = new InvalidEmailException(email);

            Log.Error($"Invalid email: {email}", ex);

            throw ex;
        }

        if (!IsCorrectPassword(password))
        {
            var ex = new InvalidPasswordException();

            // логування у тому методі де ...
            Log.Error($"invalid password", ex);

            throw ex;
        }

        UserModel user = new(email, password);

        UserDao.AddUser(user);
        CartService.CreateCart(user.Id);

        return user;
    }
}