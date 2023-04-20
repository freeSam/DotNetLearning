using StronglyTypedIdsExample.Models;

namespace StronglyTypedIdsExample.Services;

public class BasketService
{
    private readonly List<Basket> _baskets = new()
    {
        new()
        {
            UserId = Guid.Parse("26EA8CC6-28D7-4BB8-9425-D498BA8A24FD"),
            ProductIds = new List<Guid>
            {
                Guid.Parse("06F1D06C-6EAA-4590-ABDE-5366DFAB20D5")
            }
        }
    };

    public Basket Create(Guid userId)
    {
        var basket = new Basket
        {
            UserId = userId
        };
        _baskets.Add(basket);
        return basket;
    }

    public IEnumerable<Basket> GetAllForUser(Guid userId)
    {
        return _baskets.Where(x => x.UserId == userId);
    }

    public Basket? GetById(BasketId basketId)
    {
        return _baskets.SingleOrDefault(x => x.Id == basketId);
    }
}
