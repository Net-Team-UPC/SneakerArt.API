using SneakerArt.API.User.Domain.Models;

namespace SneakerArt.API.User.Domain.Responsitories;

public interface IProfileRepository
{
    Task<IEnumerable<Profile>> ListAsync();
    Task AddAsync(Profile profile);
    Task<Profile> FindByIdAsync(int id);
    void Update(Profile profile);
    void Remove(Profile profile);
}