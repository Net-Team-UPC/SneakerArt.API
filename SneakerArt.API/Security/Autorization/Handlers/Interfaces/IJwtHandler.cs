using SneakerArt.API.Security.Domain.Models;

namespace SneakerArt.API.Security.Authorization.Handlers.Interfaces;

public interface IJwtHandler
{
    public string GenerateToken(Domain.Models.User user);
    public int? ValidateToken(string token);
}