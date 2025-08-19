using Core.Entities;

namespace Application.Interfaces;

public interface IUserRepository
{
    Task<List<User>> GetUsersAsync(CancellationToken ct = default);
    Task<User> AddAsync(User user, CancellationToken ct = default);
    Task<User?> GetByIdAsync(Guid id, CancellationToken ct = default);
}
