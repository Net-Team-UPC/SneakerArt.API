using SneakerArt.API.User.Interfaces.Internal;
namespace SneakerArt.API.User.Services;

public class UserContextFacade : IUserContextFacade
{
    private readonly ProfileService _profileService;

    public UserContextFacade(ProfileService profileService)
    {
        _profileService = profileService;
    }

    public int TotalProfiles()
    {
        return _profileService.ListAsync().Result.Count();
    }
}