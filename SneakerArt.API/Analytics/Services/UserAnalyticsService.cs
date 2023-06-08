using SneakerArt.API.Analytics.Domain.Services;

namespace SneakerArt.API.Analytics.Services;

public class UserAnalyticsService : IUserAnalyticsService
{
    private readonly IUserAnalyticsService _userContext;

    public UserAnalyticsService(IUserAnalyticsService userContext)
    {
        _userContext = userContext;
    }
    public int TotalUserProfilesCount()
    {
        return _userContext.TotalUserProfilesCount();
    }
}