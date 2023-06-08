using SneakerArt.API.User.Domain.Models;
using SneakerArt.API.Shared.Domain.Services.Communication;


namespace SneakerArt.API.User.Domain.Services.Communication;

public class ProfileResponse : BaseResponse<Profile>
{
    public ProfileResponse(string message) : base(message)
    {
    }

    public ProfileResponse(Profile resource) : base(resource)
    {
    }
}