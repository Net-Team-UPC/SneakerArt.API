using System.Net.Mime;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SneakerArt.API.Collection.Domain.Models;
using SneakerArt.API.Collection.Domain.Services;
using SneakerArt.API.Collection.Resources;
using SneakerArt.API.Shared.Extensions;

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

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveShoeResource resource)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState.GetErrorMessages());
        }

        var shoe = _mapper.Map<SaveShoeResource, Shoe>(resource);
        var result = await _shoeService.SaveAsync(shoe);

        if (!result.Success)
            return BadRequest(result.Message);

        var shoeResource = _mapper.Map<Shoe, ShoeResource>(result.Resource);
        
        return Created(nameof(PostAsync), shoeResource);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveShoeResource resource)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState.GetErrorMessages());
        }
        
        var shoe = _mapper.Map<SaveShoeResource, Shoe>(resource);
        var result = await _shoeService.UpdateAsync(id,shoe);
        
        if (!result.Success)
            return BadRequest(result.Message);
        
        var shoeResource = _mapper.Map<Shoe, ShoeResource>(result.Resource);
        
        return Ok(shoeResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _shoeService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);

        var shoeResource = _mapper.Map<Shoe, ShoeResource>(result.Resource);

        return Ok(shoeResource);
    }
}