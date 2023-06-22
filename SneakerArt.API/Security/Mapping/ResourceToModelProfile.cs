using AutoMapper;
using SneakerArt.API.Security.Domain.Models;
using SneakerArt.API.Security.Domain.Services.Communication;

namespace SneakerArt.API.Security.Mapping;

public class ResourceToModelProfile : Profile
{
    protected ResourceToModelProfile()
    {
        CreateMap<RegisterRequest, User>();
        CreateMap<UpdateRequest, User>()
            .ForAllMembers(options => options.Condition(
                (source, target, property) =>
                {
                    if (property == null) return false;
                    if (property.GetType() == typeof(string) &&
                        string.IsNullOrEmpty((string)property))
                        return false;
                    return true;
                }));
    }
}