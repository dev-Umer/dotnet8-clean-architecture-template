using Application.Features.Users.Commands;
using Application.Features.Users.Handlers;
using Application.Interfaces;
using Core.Entities;
using FluentAssertions;
using Moq;

namespace UnitTests.Users;

public class CreateUserHandlerTests
{
    [Fact]
    public async Task Creates_User_With_Id()
    {
        var repo = new Mock<IUserRepository>();
        repo.Setup(r => r.AddAsync(It.IsAny<User>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync((User u, CancellationToken _) => u);

        var handler = new CreateUserHandler(repo.Object);
        var result = await handler.Handle(new CreateUserCommand("alice", "alice@example.com"), CancellationToken.None);

        result.Id.Should().NotBe(Guid.Empty);
        result.Username.Should().Be("alice");
        result.Email.Should().Be("alice@example.com");
    }
}
