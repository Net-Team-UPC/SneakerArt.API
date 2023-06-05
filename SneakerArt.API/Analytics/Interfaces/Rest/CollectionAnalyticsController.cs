using Microsoft.AspNetCore.Mvc;
using SneakerArt.API.Analytics.Domain.Services;

namespace SneakerArt.API.Analytics.Interfaces.Rest;


[ApiController]
[Route("/api/v1/analytics/collection")]
public class CollectionAnalyticsController : ControllerBase
{
    private readonly ICollectionAnalyticsService _collectionAnalyticsService;

    public CollectionAnalyticsController(ICollectionAnalyticsService collectionAnalyticsService)
    {
        _collectionAnalyticsService = collectionAnalyticsService;
    }

    [HttpGet("shoes/total")]
    public int GetShoesCount()
    {
        return _collectionAnalyticsService.TotalCollectionShoesCount();
    }
}