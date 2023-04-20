using StronglyTypedIds;

namespace StronglyTypedIdsExample.Models;

[StronglyTypedId(converters: StronglyTypedIdConverter.SystemTextJson)]
public partial struct OrderId{}

public class Order
{
    public OrderId Id { get; } = OrderId.New();

    public Guid UserId { get; init; }

    public BasketId BasketId { get; init; }
}
