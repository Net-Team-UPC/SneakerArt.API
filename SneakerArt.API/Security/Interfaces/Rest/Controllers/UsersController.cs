using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using SneakerArt.API.Security.Domain.Models;
using SneakerArt.API.Security.Domain.Services;
using SneakerArt.API.Security.Domain.Services.Communication;
using SneakerArt.API.Security.Resources;
using Microsoft.AspNetCore.Mvc;

namespace SneakerArt.API.Security.Interfaces.Rest.Controllers;

[Authorization.Attributes.Authorize]
[ApiController]
[Route("/api/v1/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public UsersController(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }

    [AllowAnonymous]
    [HttpPost("sign-in")]
    public async Task<IActionResult> Authenticate(AuthenticateRequest request)
    {
        var response = await _userService.AuthenticateAsync(request);
        return Ok(response);
    }

    [AllowAnonymous]
    [HttpPost("sign-up")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        await _userService.RegisterAsync(request);
        return Ok(new { message = "Registration successful" });
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var users = await _userService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Domain.Models.User>, IEnumerable<UserResource>>(users);
        return Ok(resources);
    }
}