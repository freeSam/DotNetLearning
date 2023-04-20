using StronglyTypedIds;

namespace StronglyTypedIdsExample.Models;

[StronglyTypedId(converters: StronglyTypedIdConverter.SystemTextJson)]
public partial struct BasketId{}

public class Basket
{
    public BasketId Id { get; } = BasketId.New();

    public Guid UserId { get; init; }

    public List<Guid> ProductIds { get; set; } = new();
}
