using SneakerArt.API.Collection.Domain.Models;
using SneakerArt.API.Shared.Domain.Services.Communication;

namespace SneakerArt.API.Collection.Domain.Services.Communication;

public class DesignResponse : BaseResponse<Design>
{
    public DesignResponse(string message) : base(message)
    {
    }

    public DesignResponse(Design resource) : base(resource)
    {
    }
}