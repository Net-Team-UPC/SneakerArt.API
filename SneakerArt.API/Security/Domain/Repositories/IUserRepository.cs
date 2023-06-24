namespace SneakerArt.API.Security.Domain.Repositories;

public interface IUserRepository
{
    Task<IEnumerable<Models.User>> ListAsync();
    Task AddAsync(Models.User user);
    Task<Models.User> FindByIdAsync(int id);
    Task<Models.User> FindByUsernameAsync(string username);
    bool ExistsByUsername(string username);
    Models.User FindById(int id);
    void Update(Models.User user);
    void Remove(Models.User user);
}