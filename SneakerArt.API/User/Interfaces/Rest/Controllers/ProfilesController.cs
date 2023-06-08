using System.Net.Mime;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SneakerArt.API.User.Domain.Models;
using SneakerArt.API.User.Domain.Services;
using SneakerArt.API.User.Resources;
using SneakerArt.API.Shared.Extensions;
using SneakerArt.API.User.Domain.Services.Communication;
using Swashbuckle.AspNetCore.Annotations;
using Profile = SneakerArt.API.User.Domain.Models.Profile;

namespace SneakerArt.API.User.Interfaces.Rest.Controllers;
[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Create, read, update and delete Profiles")]

public class ProfilesController : ControllerBase
{
     private readonly IProfileService _profileService;
    private readonly IMapper _mapper;

    public ProfilesController(IProfileService profileService, IMapper mapper)
    {
        _profileService = profileService;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<ProfileResource>), 200)]
    [SwaggerOperation(
        Summary = "Get All Profiles from User",
        Description = "Get existing Profiles associated with the User"
        )]
    public async Task<IEnumerable<ProfileResource>> GetAllAsync()
    {
        var profiles = await _profileService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Profile>, IEnumerable<ProfileResource>>(profiles);
        return resources;
    }

    [HttpPost]
    [ProducesResponseType(typeof(ProfileResource),201)]
    [ProducesResponseType(typeof(List<string>),400)]
    [ProducesResponseType(500)]
    [SwaggerOperation(
        Summary = "Post a Profile to User",
        Description = "Post a new Profile to the User"
    )]
    public async Task<IActionResult> PostAsync([FromBody] SaveProfileResource resource)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState.GetErrorMessages());
        }

        var profile = _mapper.Map<SaveProfileResource, Profile>(resource);
        var result = await _profileService.SaveAsync(profile);

        if (!result.Success)
            return BadRequest(result.Message);

        var profileResource = _mapper.Map<Profile, ProfileResource>(result.Resource);
        
        return Created(nameof(PostAsync), profileResource);
    }

    [HttpPut("{id}")]
    [SwaggerOperation(
        Summary = "Put a Profile from User",
        Description = "Put existing Profile from the User"
    )]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveProfileResource resource)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState.GetErrorMessages());
        }
        
        var profile = _mapper.Map<SaveProfileResource, Profile>(resource);
        var result = await _profileService.UpdateAsync(id,profile);
        
        if (!result.Success)
            return BadRequest(result.Message);
        
        var profileResource = _mapper.Map<Profile, ProfileResource>(result.Resource);
        
        return Ok(profileResource);
    }

    [HttpDelete("{id}")]
    [SwaggerOperation(
        Summary = "Delete a Profile to User",
        Description = "Delete existing Profile to the User"
    )]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _profileService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);

        var profileResource = _mapper.Map<Profile, ProfileResource>(result.Resource);

        return Ok(profileResource);
    }
}