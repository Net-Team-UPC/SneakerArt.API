using System.Net.Mime;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SneakerArt.API.Collection.Domain.Models;
using SneakerArt.API.Collection.Domain.Services;
using SneakerArt.API.Collection.Resources;

namespace SneakerArt.API.Collection.Interfaces.Rest.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class ShoesController : ControllerBase
{
    private readonly IShoeService _shoeService;
    private readonly IMapper _mapper;

    public ShoesController(IShoeService shoeService, IMapper mapper)
    {
        _shoeService = shoeService;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<ShoeResource>), 200)]
    public async Task<IEnumerable<ShoeResource>> GetAllAsync()
    {
        var shoes = await _shoeService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Shoe>, IEnumerable<ShoeResource>>(shoes);
        return resources;
    }
}