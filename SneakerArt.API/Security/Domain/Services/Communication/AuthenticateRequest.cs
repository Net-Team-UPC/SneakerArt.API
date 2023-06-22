using System.ComponentModel.DataAnnotations;

namespace SneakerArt.API.Security.Domain.Services.Communication;

public class AuthenticateRequest
{
    [Required] public string Username { get; set; }
    [Required] public string Password { get; set; }
}