using AutoMapper;
using SneakerArt.API.Collection.Domain.Models;
using SneakerArt.API.Collection.Resources;

namespace SneakerArt.API.Collection.Mapping;

public class ModelToResourceProfile : Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<Shoe, ShoeResource>();
        CreateMap<Design, DesignResource>();
    }
}