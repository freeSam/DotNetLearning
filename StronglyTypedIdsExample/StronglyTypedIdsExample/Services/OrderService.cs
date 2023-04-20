using StronglyTypedIdsExample.Models;

namespace StronglyTypedIdsExample.Services;

public class OrderService
{
    private readonly List<Order> _orders = new();
    private readonly BasketService _basketService;

    public OrderService(BasketService basketService)
    {
        _basketService = basketService;
    }

    public Order? CreateFromBasket(BasketId basketId)
    {
        var basket = _basketService.GetById(basketId);

        if (basket is null)
        {
            return null;
        }

        var order = new Order
        {
            UserId = basket.UserId,
            BasketId = basket.Id
        };

        _orders.Add(order);
        return order;
    }

    public Order? GetById(OrderId orderId)
    {
        return _orders.SingleOrDefault(x => x.Id == orderId);
    }
}
