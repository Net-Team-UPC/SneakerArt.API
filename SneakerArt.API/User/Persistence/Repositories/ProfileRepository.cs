﻿using Microsoft.EntityFrameworkCore;
using SneakerArt.API.User.Domain.Models;
using SneakerArt.API.User.Domain.Responsitories;
using SneakerArt.API.Shared.Persistence.Contexts;
using SneakerArt.API.Shared.Persistence.Repositories;

namespace SneakerArt.API.User.Persistence.Repositories;

public class ProfileRepository : BaseRepository, IProfileRepository
{
    public ProfileRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Profile>> ListAsync()
    {
        return await _context.Profiles.ToListAsync();
    }

    public async Task AddAsync(Profile profile)
    {
        await _context.Profiles.AddAsync(profile);
    }

    public async Task<Profile> FindByIdAsync(int id)
    {
        return await _context.Profiles.FindAsync(id);
    }

    public void Update(Profile profile)
    {
        _context.Profiles.Update(profile);
    }

    public void Remove(Profile profile)
    {
        _context.Profiles.Remove(profile);
    }
}