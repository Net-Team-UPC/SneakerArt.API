using System.Net.Mime;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SneakerArt.API.Collection.Domain.Models;
using SneakerArt.API.Collection.Domain.Services;
using SneakerArt.API.Collection.Resources;
using SneakerArt.API.Shared.Extensions;
using Swashbuckle.AspNetCore.Annotations;

namespace SneakerArt.API.Collection.Interfaces.Rest.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Create, read, update and delete Designs")]
public class DesignsController : ControllerBase
{
    private readonly IDesignService _designService;
    private readonly IMapper _mapper;


    public DesignsController(IDesignService designService, IMapper mapper)
    {
        _designService = designService;
        _mapper = mapper;
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<DesignResource>), 200)]
    [SwaggerOperation(
        Summary = "Get All Designs from Collection",
        Description = "Get existing Designs associated with the Collection"
    )]
    public async Task<IEnumerable<DesignResource>> GetAllAsync()
    {
        var designs = await _designService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Design>, IEnumerable<DesignResource>>(designs);
        return resources;
    }
    
    [HttpPost]
    [ProducesResponseType(typeof(DesignResource),201)]
    [ProducesResponseType(typeof(List<string>),400)]
    [ProducesResponseType(500)]
    [SwaggerOperation(
        Summary = "Post a Design to Collection",
        Description = "Post a new Design to the Collection"
    )]
    public async Task<IActionResult> PostAsync([FromBody] SaveDesignResource resource)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState.GetErrorMessages());
        }

        var design = _mapper.Map<SaveDesignResource, Design>(resource);
        var result = await _designService.SaveAsync(design);

        if (!result.Success)
            return BadRequest(result.Message);

        var designResource = _mapper.Map<Design, DesignResource>(result.Resource);
        
        return Created(nameof(PostAsync), designResource);
    }

    [HttpPut("{id}")]
    [SwaggerOperation(
        Summary = "Put a Design from Collection",
        Description = "Put existing Design from the Collection"
    )]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveDesignResource resource)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState.GetErrorMessages());
        }
        
        var design = _mapper.Map<SaveDesignResource, Design>(resource);
        var result = await _designService.UpdateAsync(id,design);
        
        if (!result.Success)
            return BadRequest(result.Message);
        
        var designResource = _mapper.Map<Design, DesignResource>(result.Resource);

        return Ok(designResource);
    }
    
    [HttpDelete("{id}")]
    [SwaggerOperation(
        Summary = "Delete a Design to Collection",
        Description = "Delete existing Design to the Collection"
    )]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _designService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);

        var designResource = _mapper.Map<Design, DesignResource>(result.Resource);

        return Ok(designResource);
    }
    
}