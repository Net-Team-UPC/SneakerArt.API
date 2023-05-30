﻿using AutoMapper;
using SneakerArt.API.Collection.Domain.Models;
using SneakerArt.API.Collection.Resources;

namespace SneakerArt.API.Collection.Mapping;

public class ResourceToModelProfile : Profile
{
    protected ResourceToModelProfile()
    {
        CreateMap<SaveShoeResource, Shoe>();
    }
}