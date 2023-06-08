using AutoMapper;
using SneakerArt.API.User.Domain.Models;
using SneakerArt.API.User.Resources;

namespace SneakerArt.API.User.Mapping;

public class ResourceToModelProfile : Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<SaveProfileResource, Profile>();
    }
}