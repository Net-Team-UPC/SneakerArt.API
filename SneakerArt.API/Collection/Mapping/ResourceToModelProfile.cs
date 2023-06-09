﻿using AutoMapper;
using SneakerArt.API.Collection.Domain.Models;
using SneakerArt.API.Collection.Resources;

namespace SneakerArt.API.Collection.Mapping;

public class ResourceToModelProfile : Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<SaveShoeResource, Shoe>();
        CreateMap<SaveDesignResource, Design>();
        CreateMap<SaveCommentResource, Comment>();
    }
}