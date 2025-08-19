using MediatR;
using Core.Entities;
using Application.Interfaces;

namespace Application.Features.Users.Handlers;

public sealed class CreateUserHandler : IRequestHandler<Features.Users.Commands.CreateUserCommand, User>
{
    private readonly IUserRepository _repo;
    public CreateUserHandler(IUserRepository repo) => _repo = repo;

    public Task<User> Handle(Features.Users.Commands.CreateUserCommand request, CancellationToken ct)
    {
        var entity = new User { Id = Guid.NewGuid(), Username = request.Username, Email = request.Email };
        return _repo.AddAsync(entity, ct);
    }
}
