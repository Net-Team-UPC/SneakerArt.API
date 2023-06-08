using SneakerArt.API.User.Domain.Models;
using SneakerArt.API.User.Domain.Services.Communication;


namespace SneakerArt.API.User.Domain.Services;

public interface IProfileService
{
    Task<IEnumerable<Profile>> ListAsync();
    Task<ProfileResponse> SaveAsync(Profile profile);
    Task<ProfileResponse> UpdateAsync(int id, Profile profile);
    Task<ProfileResponse> DeleteAsync(int id);
    
}