using log4net;
using ShopConsoleApp.Models;

namespace ShopConsoleApp.Dao;

public class MemoryOrderDao : IOrderDao
{
    private static MemoryOrderDao _instance = null;

    private readonly Dictionary<Guid, OrderModel> _orders = [];
    private readonly ILog _log = LogManager.GetLogger(typeof(MemoryOrderDao));

    private MemoryOrderDao()
    {
    }
    public static MemoryOrderDao Instance => _instance ??= new MemoryOrderDao();

    public void CreateOrder(OrderModel order) => _orders.Add(order.Id, order);

    public List<OrderModel> GetOrdersByUserId(Guid userId)
    {
        var orders = new List<OrderModel>();

        foreach (var order in _orders.Values)
        {
            if (userId == order.UserId)
            {
                orders.Add(order);
            }
        }

        return orders;
    }
}