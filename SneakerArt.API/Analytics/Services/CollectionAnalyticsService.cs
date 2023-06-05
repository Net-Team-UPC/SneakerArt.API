using SneakerArt.API.Analytics.Domain.Services;
using SneakerArt.API.Collection.Interfaces.Internal;

namespace SneakerArt.API.Analytics.Services;

public class CollectionAnalyticsService : ICollectionAnalyticsService
{
    private readonly ICollectionContextFacade _collectionContext;

    public CollectionAnalyticsService(ICollectionContextFacade collectionContext)
    {
        _collectionContext = collectionContext;
    }

    public int TotalCollectionShoesCount()
    {
        return _collectionContext.TotalShoes();
    }
}