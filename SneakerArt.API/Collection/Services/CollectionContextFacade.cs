using SneakerArt.API.Collection.Interfaces.Internal;

namespace SneakerArt.API.Collection.Services;

public class CollectionContextFacade : ICollectionContextFacade
{
    private readonly ShoeService _shoeService;

    public CollectionContextFacade(ShoeService shoeService)
    {
        _shoeService = shoeService;
    }

    public int TotalShoes()
    {
        return _shoeService.ListAsync().Result.Count();
    }
}