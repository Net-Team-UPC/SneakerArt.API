using System.ComponentModel.DataAnnotations;

namespace SneakerArt.API.Security.Domain.Services.Communication;

public class RegisterRequest
{
    [Required] public string FirstName { get; set; }
    [Required] public string LastName { get; set; }
    [Required] public string Username { get; set; }
    [Required] public string Password { get; set; }
}