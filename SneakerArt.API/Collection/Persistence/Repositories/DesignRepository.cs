using Microsoft.EntityFrameworkCore;
using SneakerArt.API.Collection.Domain.Models;
using SneakerArt.API.Collection.Domain.Repositories;
using SneakerArt.API.Shared.Persistence.Contexts;
using SneakerArt.API.Shared.Persistence.Repositories;

namespace SneakerArt.API.Collection.Persistence.Repositories;

public class DesignRepository : BaseRepository, IDesignRepository
{
    public DesignRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Design>> ListAsync()
    {
        return await _context.Designs.ToListAsync();
    }

    public async Task AddAsync(Design design)
    {
        await _context.Designs.AddAsync(design);
    }

    public async Task<Design> FindByIdAsync(int id)
    {
        return await _context.Designs.FindAsync(id);
    }

    public void Update(Design design)
    {
        _context.Designs.Update(design);
    }

    public void Remove(Design design)
    {
        _context.Designs.Remove(design);
    }
}