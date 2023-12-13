using Domain.Entities.User.Commands;
using Domain.Interfaces.User;
using Moq;

namespace Tests
{
    public class UserCommandTest
    {
        [Fact]
        public async void AddUserComandTest()
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

        [Fact]
        public async void EditUserComandTest()
        {
            // Arrange
            var iUserMock = new Mock<IUserRepository>();
            var request = new EditUserCommand
            {
                Id = 1,
                Name = "Test",
                LastName = "Test1",
                DateOfBirth = "1994-07-23",
                Email = "test@gmail.com"
            };

            var handler = new EditUserCommandHandler(iUserMock.Object);

            // Act
            var response = await handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.Null(response.Errors);
            Assert.NotNull(response.Data);
        }
    }
}