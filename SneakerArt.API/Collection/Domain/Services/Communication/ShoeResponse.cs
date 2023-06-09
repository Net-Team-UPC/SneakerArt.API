using SneakerArt.API.Collection.Domain.Models;
using SneakerArt.API.Shared.Domain.Services.Communication;

namespace SneakerArt.API.Collection.Domain.Services.Communication;

public class ShoeResponse : BaseResponse<Shoe>
{
    public ShoeResponse(string message) : base(message)
    {
    }

    public ShoeResponse(Shoe resource) : base(resource)
    {
    }
}