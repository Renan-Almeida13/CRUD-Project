using AutoFixture;
using Domain.Entities.User.Commands;
using Domain.Interfaces.User;
using Moq;
using System.Net;

public class AddUserCommandsHandlerTests
{
    private readonly Mock<IUserRepository> _userRepositoryMock;
    private readonly AddUserCommandHandler _handler;
    private readonly Fixture _fixture;

    public AddUserCommandsHandlerTests()
    {
        _userRepositoryMock = new Mock<IUserRepository>();
        _handler = new AddUserCommandHandler(_userRepositoryMock.Object);
        _fixture = new Fixture();
    }

    [Fact]
    public async Task Handle_ReturnsOk_WhenUserIsAdded()
    {
        // Arrange
        var command = _fixture.Create<AddUserCommand>();
        _userRepositoryMock.Setup(r => r.Add(command)).Returns(1); // Simula que o ID do usuário foi retornado

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.Equal(HttpStatusCode.OK, result.StatusCode);
        Assert.Equal(1, result.Data); // ID do usuário adicionado
    }
}

public class EditUserCommandHandlerTests
{
    private readonly Mock<IUserRepository> _userRepositoryMock;
    private readonly EditUserCommandHandler _handler;
    private readonly Fixture _fixture;

    public EditUserCommandHandlerTests()
    {
        _userRepositoryMock = new Mock<IUserRepository>();
        _handler = new EditUserCommandHandler(_userRepositoryMock.Object);
        _fixture = new Fixture();
    }

    [Fact]
    public async Task Handle_ReturnsOk_WhenUserIsEdited()
    {
        // Arrange
        var command = _fixture.Create<EditUserCommand>();
        _userRepositoryMock.Setup(r => r.Edit(command)).Returns(command.Id); // Simula que o ID do usuário foi retornado

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.Equal(HttpStatusCode.OK, result.StatusCode);
        Assert.Equal(command.Id, result.Data); // ID do usuário editado
    }
}

public class RemoveUserCommandHandlerTests
{
    private readonly Mock<IUserRepository> _userRepositoryMock;
    private readonly RemoveUserCommandHandler _handler;
    private readonly Fixture _fixture;

    public RemoveUserCommandHandlerTests()
    {
        _userRepositoryMock = new Mock<IUserRepository>();
        _handler = new RemoveUserCommandHandler(_userRepositoryMock.Object);
        _fixture = new Fixture();
    }

    [Fact]
    public async Task Handle_ReturnsOk_WhenUserIsRemoved()
    {
        // Arrange
        var command = _fixture.Create<RemoveUserCommand>();
        _userRepositoryMock.Setup(r => r.Remove(command)).Returns(command.Id); // Simula que o ID do usuário foi retornado

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.Equal(HttpStatusCode.OK, result.StatusCode);
        Assert.Equal(command.Id, result.Data); // ID do usuário removido
    }
}
