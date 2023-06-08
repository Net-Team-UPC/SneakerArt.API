using Microsoft.AspNetCore.Mvc;
using SneakerArt.API.Analytics.Domain.Services;

namespace SneakerArt.API.Analytics.Interfaces.Rest;

[ApiController]
[Route("/api/v1/analytics/user")]
public class UserAnalyticsController : ControllerBase
{
    private readonly IUserAnalyticsService _userAnalyticsService;

    public UserAnalyticsController(IUserAnalyticsService userAnalyticsService)
    {
        _userAnalyticsService = userAnalyticsService;
    }


    [HttpGet("profiles/total")]
    public int GetProfilesCount()
    {
        return _userAnalyticsService.TotalUserProfilesCount();
    }
}