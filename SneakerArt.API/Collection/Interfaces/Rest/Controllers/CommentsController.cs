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
[SwaggerTag("Create, read, update and delete Comments")]
public class CommentsController : ControllerBase
{
    private readonly ICommentService _commentService;
    private readonly IMapper _mapper;

    public CommentsController(ICommentService commentService, IMapper mapper)
    {
        _commentService = commentService;
        _mapper = mapper;
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<CommentResource>), 200)]
    [SwaggerOperation(
        Summary = "Get All Comments from Collection",
        Description = "Get existing Comments associated with the Collection"
    )]
    public async Task<IEnumerable<CommentResource>> GetAllAsync()
    {
        var comments = await _commentService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Comment>, IEnumerable<CommentResource>>(comments);
        return resources;
    }
    
    [HttpPost]
    [ProducesResponseType(typeof(CommentResource),201)]
    [ProducesResponseType(typeof(List<string>),400)]
    [ProducesResponseType(500)]
    [SwaggerOperation(
        Summary = "Post a Comment to Collection",
        Description = "Post a new Comment to the Collection"
    )]
    public async Task<IActionResult> PostAsync([FromBody] SaveCommentResource resource)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState.GetErrorMessages());
        }

        var comment = _mapper.Map<SaveCommentResource, Comment>(resource);
        var result = await _commentService.SaveAsync(comment);

        if (!result.Success)
            return BadRequest(result.Message);

        var commentResource = _mapper.Map<Comment, CommentResource>(result.Resource);
        
        return Created(nameof(PostAsync), commentResource);
    }
    
    [HttpPut("{id}")]
    [SwaggerOperation(
        Summary = "Put a Comment from Collection",
        Description = "Put existing Comment from the Collection"
    )]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveCommentResource resource)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState.GetErrorMessages());
        }
        
        var comment  = _mapper.Map<SaveCommentResource, Comment>(resource);
        var result = await _commentService.UpdateAsync(id,comment);
        
        if (!result.Success)
            return BadRequest(result.Message);
        
        var commentResource = _mapper.Map<Comment, CommentResource>(result.Resource);
        
        return Ok(commentResource);
    }
    
    [HttpDelete("{id}")]
    [SwaggerOperation(
        Summary = "Delete a Comment to Collection",
        Description = "Delete existing Comment to the Collection"
    )]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _commentService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);

        var commentResource = _mapper.Map<Comment, CommentResource>(result.Resource);

        return Ok(commentResource);
    }
    
}