using log4net;
using ShopConsoleApp.Exceptions;
using ShopConsoleApp.Models;
using ShopConsoleApp.Services;

namespace ShopConsoleApp.Dao;

public class MemoryUserDao : IUserDao // Data Access object pattern 
{
    private static MemoryUserDao _instance = null;
    private readonly Dictionary<Guid, UserModel> _users = [];

    private static readonly ILog Log = LogManager.GetLogger(typeof(MemoryUserDao));

    private MemoryUserDao()
    {
    }
    public static MemoryUserDao Instance => _instance ??= new MemoryUserDao();

    public void AddUser(UserModel user)
    {
        _users.Add(user.Id, user);

        Log.Info($"User with email {user.Email} has been successfully inserted.");
    }
    public bool IsExists(Guid id) => _users.ContainsKey(id);
    public bool IsExists(string email)
    {
        foreach (var user in _users.Values)
        {
            if (user.Email == email)
            {
                return true;
            }
        }

        return false;
    }
    public UserModel GetById(Guid id) => _users[id];
    public UserModel GetByEmail(string email)
    {
        foreach (var user in _users.Values)
        {
            if (user.Email == email)
            {
                return user;
            }
        }

        var ex = new UserNotFoundException(email);

        Log.Error($"User with email '{email}' not found.", ex);

        throw ex;
    }
    public IEnumerable<UserModel> GetAllUsers() => _users.Values;
    public void UpdatePassword(Guid id, string newPassword) => _users[id].Password = newPassword;
    public void UpdatePassword(string email, string newPassword)
    {
        foreach (var user in _users.Values)
        {
            if (user.Email == email)
            {
                user.Password = newPassword;

                Log.Info("Password has been updated successfully.");
            }
        }
    }
    public void DeleteById(Guid id) => _users.Remove(id);
    public void DeleteByEmail(string email)
    {
        foreach (var user in _users.Values)
        {
            if (user.Email == email)
            {
                _users.Remove(user.Id);

                Log.Info($"User with email '{email}' has been deleted.");
            }
        }
    }
}