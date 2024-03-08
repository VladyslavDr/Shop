using ShopConsoleApp.Models;

namespace ShopConsoleApp.Dao;

public interface IUserDao
{
    //public void Register(string email, string password);
    public void AddUser(UserModel user);

    public bool Exists(Guid id);
    public bool Exists(string email);

    public UserModel GetById(Guid id);
    public UserModel GetByEmail(string email);
    public IEnumerable<UserModel> GetAllUsers();

    // public IEnumerable<UserAction> GetUserActions(Guid id);

    public void UpdatePassword(Guid id, string newPassword);
    public void UpdatePassword(string email, string newPassword);

    public void DeleteById(Guid id);
    public void DeleteByEmail(string email);
}