using Domain.Commons;
using MediatR;

namespace Domain.Entities.User.Commands
{
    public class UserCommands { }

    public class AddUserCommand : Command, IRequest<Response>
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string DateOfBirth { get; set; }
        public int ProfileId { get; set; }
    }

    public class EditUserCommand : Command, IRequest<Response>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string DateOfBirth { get; set; }
        public int ProfileId { get; set; }
        public bool DateRemoval { get; set; }
    }

    public class RemoveUserCommand : Command, IRequest<Response>
    {
        public int Id { get; set; }
    }
}
