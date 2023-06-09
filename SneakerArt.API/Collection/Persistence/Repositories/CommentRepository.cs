﻿using Microsoft.EntityFrameworkCore;
using SneakerArt.API.Collection.Domain.Models;
using SneakerArt.API.Collection.Domain.Repositories;
using SneakerArt.API.Shared.Persistence.Contexts;
using SneakerArt.API.Shared.Persistence.Repositories;

namespace SneakerArt.API.Collection.Persistence.Repositories;

public class CommentRepository : BaseRepository, ICommentRepository
{
    public CommentRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Comment>> ListAsync()
    {
        return await _context.Comments.ToListAsync();
    }

    public async Task AddAsync(Comment comment)
    {
        await _context.Comments.AddAsync(comment);
    }

    public async Task<Comment> FindByIdAsync(int id)
    {
        return await _context.Comments.FindAsync(id);
    }

    public async void Update(Comment comment)
    {
        _context.Comments.Update(comment);
    }

    public async void Remove(Comment comment)
    {
        _context.Comments.Remove(comment);
    }
}