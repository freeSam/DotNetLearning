using JetBrains.Annotations;

namespace NullGuarding;

public class ItemService
{
    private readonly ItemRepository _itemRepository;

    public ItemService(ItemRepository itemRepository)
    {
        _itemRepository = itemRepository;
    }

    // Methods here

    public string Test()
    {
        return null;
    }
}

public class ItemRepository
{

}
