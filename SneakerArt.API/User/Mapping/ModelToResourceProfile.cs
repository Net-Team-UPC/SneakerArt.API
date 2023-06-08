using AutoMapper;
using SneakerArt.API.User.Resources;

namespace SneakerArt.API.User.Mapping;

public class ModelToResourceProfile : Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<Domain.Models.Profile, ProfileResource>();
    }
}