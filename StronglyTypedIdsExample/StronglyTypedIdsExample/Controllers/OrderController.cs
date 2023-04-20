using Microsoft.AspNetCore.Mvc;
using StronglyTypedIdsExample.Models;
using StronglyTypedIdsExample.Services;

namespace StronglyTypedIdsExample.Controllers;

[ApiController]
public class OrdersController : ControllerBase
{
    private readonly OrderService _orderService;

    public OrdersController(OrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpPost("orders/{basketId:guid}")]
    public IActionResult Create([FromRoute] Guid basketId)
    {
        var order = _orderService.CreateFromBasket(new BasketId(basketId));
        if (order is null)
        {
            return NotFound();
        }

        return CreatedAtAction(nameof(Get), new { orderId = order.Id }, order);
    }

    [HttpGet("orders/{orderId}")]
    public IActionResult Get([FromRoute] Guid orderId)
    {
        var order = _orderService.GetById(new OrderId(orderId));
        if (order is null)
        {
            return NotFound();
        }

        return Ok(order);
    }
}
