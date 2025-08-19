using MediatR;
using Core.Entities;
using Application.Interfaces;

namespace Application.Features.Users.Handlers;

public sealed class GetUsersHandler : IRequestHandler<Features.Users.Queries.GetUsersQuery, List<User>>
{
    private readonly IUserRepository _repo;
    public GetUsersHandler(IUserRepository repo) => _repo = repo;

    public Task<List<User>> Handle(Features.Users.Queries.GetUsersQuery request, CancellationToken ct)
        => _repo.GetUsersAsync(ct);
}
