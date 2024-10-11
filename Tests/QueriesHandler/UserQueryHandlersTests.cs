using AutoFixture;
using Domain.Entities.User.Queries;
using Domain.Entities.User.Responses;
using Domain.Interfaces.User;
using Moq;
using System.Net;

public class ListUserQueryHandlersTests
{
    private readonly Mock<IUserRepository> _userRepositoryMock;
    private readonly ListUserQueryHandlers _handler;
    private readonly GetByIdUserQueryHandler _handlerGetById;
    private readonly Fixture _fixture;

    public ListUserQueryHandlersTests()
    {
        _userRepositoryMock = new Mock<IUserRepository>();
        _handler = new ListUserQueryHandlers(_userRepositoryMock.Object);
        _fixture = new Fixture();
    }

    [Fact]
    public async Task Handle_ReturnsUsers_WhenUsersExist()
    {
        // Arrange
        var users = _fixture.CreateMany<UserListResponse>(2).ToList();
        _userRepositoryMock.Setup(r => r.List()).Returns(users);

        var query = _fixture.Create<ListUserQuery>();

        // Act
        var result = await _handler.Handle(query, CancellationToken.None);

        // Assert
        Assert.Equal(HttpStatusCode.OK, result.StatusCode);
        Assert.Equal(users, result.Data);
    }

    [Fact]
    public async Task Handle_ReturnsEmptyList_WhenNoUsersExist()
    {
        // Arrange
        var users = new List<UserListResponse>();
        _userRepositoryMock.Setup(r => r.List()).Returns(users);

        var query = _fixture.Create<ListUserQuery>();

        // Act
        var result = await _handler.Handle(query, CancellationToken.None);

        // Assert
        Assert.Equal(HttpStatusCode.OK, result.StatusCode);

        // Verifica se Data é null ou uma coleção vazia
        Assert.True(result.Data is IEnumerable<UserListResponse> data && !data.Any());
    }
}
