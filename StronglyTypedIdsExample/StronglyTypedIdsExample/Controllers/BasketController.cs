using Microsoft.AspNetCore.Mvc;
using StronglyTypedIdsExample.Services;

namespace StronglyTypedIdsExample.Controllers;

[ApiController]
public class BasketsController : ControllerBase
{
    private readonly BasketService _basketService;

    public BasketsController(BasketService basketService)
    {
        _basketService = basketService;
    }

    [HttpGet("baskets/{userId}")]
    public IActionResult GetAllForUser([FromRoute]Guid userId)
    {
        var baskets = _basketService.GetAllForUser(userId);
        return Ok(baskets);
    }
}
