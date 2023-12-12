using Domain.Entities.User.Commands;
using Domain.Interfaces.User;
using Moq;

namespace Tests
{
    public class UserAddCommandTest
    {
        [Fact]
        public async void Add_WhenCalled_ReturnsSum()
        {
            // Arrange
            var iUserMock = new Mock<IUserRepository>();
            var request = new AddUserCommand
            {
                Name = "Test",
                LastName = "Test1",
                DateOfBirth = "1994-07-23",
                Email = "test@gmail.com"
            };

            var handler = new AddUserCommandHandler(iUserMock.Object);

            // Act
            var response = await handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.Null(response.Errors);
            Assert.NotNull(response.Data);
        }
    }
}