namespace StronglyTypedIdsExample.Models;

public class Product
{
    public Guid Id { get; } = Guid.NewGuid();

    public string Name { get; set; } = default!;
}
