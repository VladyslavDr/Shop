using ShopConsoleApp.Dao;
using ShopConsoleApp.Exceptions;
using ShopConsoleApp.Models;
namespace ShopConsoleApp.Services;
using log4net;

// Singleton
public class UserService
{
    private static UserService _instance = null;

    private readonly ILog _log = LogManager.GetLogger(typeof(UserService));
    private readonly CartService _cartService = CartService.Instance;

    // Dao pattern
    private static readonly IUserDao UserDao = MemoryUserDao.Instance;

    private UserService()
    {
    }

    public static UserService Instance => _instance ??= new UserService(); //todo ??=
    public UserModel Register(string email, string password)
    {
        var listExceptionsUsers = UserValidator.ValidateUserExceptions(email, password);

        foreach (var exception in listExceptionsUsers)
        {
            _log.Error(exception.Message);
            throw exception;
        }

        if (UserDao.Exists(email))
        {
            var ex = new UserAlreadyExistsException();

            _log.Error(ex.Message);

            throw ex;
        }

        UserModel user = new(email, password);

        UserDao.AddUser(user);
        _cartService.CreateCart(user.Id);

        return user;
    }
    public UserModel Login(string email, string password)
    {
        var listExceptionsUsers = UserValidator.ValidateUserExceptions(email, password);

        foreach (var exception in listExceptionsUsers)
        {
            _log.Error(exception.Message);
            throw exception;
        }

        if (!UserDao.Exists(email))
        {
            var appEx = new UserNotFoundException(email);

            _log.Error(appEx.Message);

            throw appEx;
        }

        var user = UserDao.GetByEmail(email);

        if (string.Equals(user.Password, password))
        {
            _log.Info($"The user with {email} is login");
            return user;
        }

        var argEx = new ArgumentException("wrong password");

        _log.Error(argEx.Message);

        throw argEx;
    }

    public UserModel GetUserByEmail(string email) => UserDao.GetByEmail(email);
}