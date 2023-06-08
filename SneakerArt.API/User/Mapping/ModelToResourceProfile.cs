using AutoMapper;
using SneakerArt.API.User.Domain.Models;
using SneakerArt.API.User.Resources;

namespace SneakerArt.API.User.Mapping;

public class ModelToResourceProfile : Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<Profile, ProfileResource>();
    }
}