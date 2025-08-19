using Application.Interfaces;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly Persistence.AppDbContext _db;
    public UserRepository(Persistence.AppDbContext db) => _db = db;

    public async Task<User> AddAsync(User user, CancellationToken ct = default)
    {
        _db.Users.Add(user);
        await _db.SaveChangesAsync(ct);
        return user;
    }

    public Task<User?> GetByIdAsync(Guid id, CancellationToken ct = default)
        => _db.Users.FirstOrDefaultAsync(u => u.Id == id, ct);

    public Task<List<User>> GetUsersAsync(CancellationToken ct = default)
        => _db.Users.AsNoTracking().OrderBy(u => u.Username).ToListAsync(ct);
}
