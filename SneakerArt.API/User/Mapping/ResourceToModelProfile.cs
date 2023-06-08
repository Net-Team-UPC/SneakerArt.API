using AutoMapper;
using SneakerArt.API.User.Resources;

namespace SneakerArt.API.User.Mapping;

public class ResourceToModelProfile : Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<SaveProfileResource, Domain.Models.Profile>();
    }
}