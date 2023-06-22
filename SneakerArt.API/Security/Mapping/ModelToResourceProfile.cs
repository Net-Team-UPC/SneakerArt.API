using AutoMapper;
using SneakerArt.API.Security.Domain.Models;
using SneakerArt.API.Security.Domain.Services.Communication;
using SneakerArt.API.Security.Resources;

namespace SneakerArt.API.Security.Mapping;

public class ModelToResourceProfile : Profile
{
    protected ModelToResourceProfile()
    {
        CreateMap<User, AuthenticateResponse>();
        CreateMap<User, UserResource>();
    }
}