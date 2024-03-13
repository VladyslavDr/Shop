using log4net;
using ShopConsoleApp.Dao;
using ShopConsoleApp.Models;

namespace ShopConsoleApp.Services;

public class OrderService
{
    private static OrderService _instance = null;
    private readonly ILog _log = LogManager.GetLogger(typeof(OrderService));

    private readonly CartService _cartService = CartService.Instance;

    // Dao pattern
    private readonly IOrderDao _orderDao = MemoryOrderDao.Instance;

    private OrderService()
    {
    }
    public static OrderService Instance => _instance ??= new OrderService();

    public void CreateOrder(Guid userId)
    {
        var cart = _cartService.GetCartByUserId(userId);
        var order = new OrderModel(userId);

        foreach (var cartItem in cart.CartItems)
        {
            order.CartItems.Add(cartItem);
        }
        
        order.TotalPrice = cart.TotalPrice;

        _orderDao.CreateOrder(order);

        _cartService.ClearCartByUserId(userId);
        cart.TotalPrice = 0m;
    }

    public List<OrderModel> GetOrdersByUserId(Guid userId) => _orderDao.GetOrdersByUserId(userId);
}