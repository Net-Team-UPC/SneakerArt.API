using System.Net.Mime;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SneakerArt.API.Collection.Domain.Models;
using SneakerArt.API.Collection.Domain.Services;
using SneakerArt.API.Collection.Resources;
using Swashbuckle.AspNetCore.Annotations;

namespace SneakerArt.API.Collection.Interfaces.Rest.Controllers;

[ApiController]
[Route("/api/v1/comments/{commentId}/shoes")]
[Produces(MediaTypeNames.Application.Json)]
public class CommentShoesController : ControllerBase
{
    private readonly IShoeService _shoeService;
    private readonly IMapper _mapper;

    public CommentShoesController(IShoeService shoeService, IMapper mapper)
    {
        _shoeService = shoeService;
        _mapper = mapper;
    }

    [HttpGet]
    [SwaggerOperation(
        Summary = "Get All Comments for Given Shoe",
        Description = "Get existing Comments associated with the specified Shoe",
        OperationId = "GetCommentShoes",
        Tags = new[] { "Comments" }
    )]
    public async Task<IEnumerable<ShoeResource>> GetAllByCommentIdAsync(int shoeId)
    {
        var shoes = await _shoeService.ListByCommentIdAsync(shoeId);

        var resources = _mapper.Map<IEnumerable<Shoe>, IEnumerable<ShoeResource>>(shoes);

        return resources;
    }
}