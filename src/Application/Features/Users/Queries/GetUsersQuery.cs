using MediatR;
using Core.Entities;

namespace Application.Features.Users.Queries;
public sealed record GetUsersQuery() : IRequest<List<User>>;
