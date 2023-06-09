using SneakerArt.API.Security.Domain.Models;
using SneakerArt.API.Security.Domain.Repositories;
using SneakerArt.API.Shared.Persistence.Contexts;
using SneakerArt.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace SneakerArt.API.Security.Persistence;

public class UserRepository : BaseRepository, IUserRepository
{
    public UserRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Domain.Models.User>> ListAsync()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task AddAsync(Domain.Models.User user)
    {
        await _context.Users.AddAsync(user);
    }

    public async Task<Domain.Models.User> FindByIdAsync(int id)
    {
        return await _context.Users.FindAsync(id);
    }

    public async Task<Domain.Models.User> FindByUsernameAsync(string username)
    {
        return await _context.Users.SingleOrDefaultAsync(x => x.Username == username);
    }

    public bool ExistsByUsername(string username)
    {
        return _context.Users.Any(x => x.Username == username);
    }

    public Domain.Models.User FindById(int id)
    {
        return _context.Users.Find(id);
    }

    public void Update(Domain.Models.User user)
    {
        _context.Users.Update(user);
    }

    public void Remove(Domain.Models.User user)
    {
        _context.Users.Remove(user);
    }
}