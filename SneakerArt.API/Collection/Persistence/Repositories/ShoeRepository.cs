using Microsoft.EntityFrameworkCore;
using SneakerArt.API.Collection.Domain.Models;
using SneakerArt.API.Collection.Domain.Repositories;
using SneakerArt.API.Shared.Persistence.Contexts;
using SneakerArt.API.Shared.Persistence.Repositories;

namespace SneakerArt.API.Collection.Persistence.Repositories;

public class ShoeRepository : BaseRepository, IShoeRepository
{
    public ShoeRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Shoe>> ListAsync()
    {
        return await _context.Shoes.ToListAsync();
    }

    public async Task AddAsync(Shoe shoe)
    {
        await _context.Shoes.AddAsync(shoe);
    }

    public async Task<Shoe> FindByIdAsync(int id)
    {
        return await _context.Shoes.FindAsync(id);
    }

    public async Task<IEnumerable<Shoe>> FindByCommentIdAsync(int commentId)
    {
        return await _context.Shoes
            .Where(p => p.CommentId == commentId)
            .Include(p => p.Comment)
            .ToListAsync();
    }

    public void Update(Shoe shoe)
    {
        _context.Shoes.Update(shoe);
    }

    public void Remove(Shoe shoe)
    {
        _context.Shoes.Remove(shoe);
    }
}