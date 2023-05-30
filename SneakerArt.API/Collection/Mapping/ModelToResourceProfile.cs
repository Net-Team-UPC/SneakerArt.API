﻿using AutoMapper;
using SneakerArt.API.Collection.Domain.Models;
using SneakerArt.API.Collection.Resources;

namespace SneakerArt.API.Collection.Mapping;

public class ModelToResourceProfile : Profile
{
    protected ModelToResourceProfile()
    {
        CreateMap<Shoe, ShoeResource>();
    }
}