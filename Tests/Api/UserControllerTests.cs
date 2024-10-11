using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Api
{
    using AutoFixture;
    using Moq;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using System.Net;
    using System.Threading.Tasks;
    using Xunit;
    using Domain.Commons;
    using Domain.Entities.User.Queries;
    using Domain.Entities.User.Responses;
    using API.Controllers;
    using Domain.Entities.User.Commands;

    public class UserControllerTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly UserController _userController;
        private readonly Fixture _fixture;

        public UserControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _userController = new UserController(_mediatorMock.Object);
            _fixture = new Fixture();
        }

        [Fact]
        public async Task ListAsync_ReturnsOkResult_WhenUsersAreFound()
        {
            // Arrange
            var users = _fixture.CreateMany<UserListResponse>(2).ToList();
            var response = new Response(HttpStatusCode.OK, null, users);

            _mediatorMock.Setup(m => m.Send(It.IsAny<ListUserQuery>(), default))
                          .ReturnsAsync(response);

            // Act
            var result = await _userController.ListAsync();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal((int)HttpStatusCode.OK, okResult.StatusCode);
            Assert.Equal(users, okResult.Value);
        }

        [Fact]
        public async Task ListAsync_ReturnsNotFound_WhenNoUsersAreFound()
        {
            // Arrange
            var errors = new List<string> { "No users found" };
            var response = new Response(HttpStatusCode.NotFound, errors, null);

            _mediatorMock.Setup(m => m.Send(It.IsAny<ListUserQuery>(), default))
                          .ReturnsAsync(response);

            // Act
            var result = await _userController.ListAsync();

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
            Assert.Equal((int)HttpStatusCode.NotFound, notFoundResult.StatusCode);
            Assert.Equal(errors, notFoundResult.Value);
        }

        [Fact]
        public async Task GetByIdAsync_ReturnsOkResult_WhenUserIsFound()
        {
            // Arrange
            var user = _fixture.Create<UserGetByIdResponse>();
            var response = new Response(HttpStatusCode.OK, null, user);

            _mediatorMock.Setup(m => m.Send(It.IsAny<GetByIdUserQuery>(), default))
                          .ReturnsAsync(response);

            // Act
            var result = await _userController.GetByIdAsync(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal((int)HttpStatusCode.OK, okResult.StatusCode);
            Assert.Equal(user, okResult.Value);
        }

        [Fact]
        public async Task GetByIdAsync_ReturnsNotFound_WhenUserIsNotFound()
        {
            // Arrange
            var response = new Response(HttpStatusCode.NotFound, new List<string> { "User not found" }, null);

            _mediatorMock.Setup(m => m.Send(It.IsAny<GetByIdUserQuery>(), default))
                          .ReturnsAsync(response);

            // Act
            var result = await _userController.GetByIdAsync(1);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
            Assert.Equal((int)HttpStatusCode.NotFound, notFoundResult.StatusCode);
            Assert.Equal("User not found", ((IReadOnlyCollection<string>)notFoundResult.Value).First());
        }

        [Fact]
        public async Task AddAsync_ReturnsOk_WhenUserIsAdded()
        {
            // Arrange
            var command = _fixture.Create<AddUserCommand>();
            var response = new Response(HttpStatusCode.OK, null, command);

            _mediatorMock.Setup(m => m.Send(command, default))
                          .ReturnsAsync(response);

            // Act
            var result = await _userController.AddAsync(command);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal((int)HttpStatusCode.OK, okResult.StatusCode);
            Assert.Equal(command, okResult.Value);
        }

        [Fact]
        public async Task AddAsync_ReturnsBadRequest_WhenValidationFails()
        {
            // Arrange
            var command = _fixture.Create<AddUserCommand>();
            var errors = new List<string> { "Validation error" };
            var response = new Response(HttpStatusCode.BadRequest, errors, null);

            _mediatorMock.Setup(m => m.Send(command, default))
                          .ReturnsAsync(response);

            // Act
            var result = await _userController.AddAsync(command);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal((int)HttpStatusCode.BadRequest, badRequestResult.StatusCode);
            Assert.Equal(errors, badRequestResult.Value);
        }

        [Fact]
        public async Task EditAsync_ReturnsOk_WhenUserIsEdited()
        {
            // Arrange
            var command = _fixture.Create<EditUserCommand>();
            var response = new Response(HttpStatusCode.OK, null, command);

            _mediatorMock.Setup(m => m.Send(command, default))
                          .ReturnsAsync(response);

            // Act
            var result = await _userController.EditAsync(command);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal((int)HttpStatusCode.OK, okResult.StatusCode);
            Assert.Equal(command, okResult.Value);
        }

        [Fact]
        public async Task RemoveAsync_ReturnsOk_WhenUserIsRemoved()
        {
            // Arrange
            var command = _fixture.Create<RemoveUserCommand>();
            var response = new Response(HttpStatusCode.OK, null, command.Id);

            _mediatorMock.Setup(m => m.Send(command, default))
                          .ReturnsAsync(response);

            // Act
            var result = await _userController.RemoveAsync(command);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal((int)HttpStatusCode.OK, okResult.StatusCode);
            Assert.Equal(command.Id, okResult.Value);
        }
    }

}
