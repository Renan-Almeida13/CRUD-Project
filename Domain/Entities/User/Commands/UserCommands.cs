using Domain.Commons;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.User.Commands
{
    public class UserCommands { }

    public class AddUserCommand : Command, IRequest<Response>
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string DateOfBirth { get; set; }
    }

    public class EditUserCommand : Command, IRequest<Response>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string DateOfBirth { get; set; }
    }
}
