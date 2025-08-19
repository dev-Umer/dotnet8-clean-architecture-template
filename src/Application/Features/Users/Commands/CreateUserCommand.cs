using MediatR;
using Core.Entities;

namespace Application.Features.Users.Commands;
public sealed record CreateUserCommand(string Username, string Email) : IRequest<User>;
