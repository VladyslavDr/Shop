using ShopConsoleApp.Models;

namespace ShopConsoleApp.Dao;

public interface IOrderDao
{
    public void CreateOrder(OrderModel order);
    public List<OrderModel> GetOrdersByUserId(Guid userId);
}