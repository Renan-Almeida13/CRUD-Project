using Domain.Commons;
using Domain.Interfaces.User;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.User.Commands
{
    public class UserCommandsHandlers { }

    public class AddUserCommandHandler : Handler, IRequestHandler<AddUserCommand, Response> 
    {
        private readonly IUserRepository _iUserRepository;

        public AddUserCommandHandler(IUserRepository iUserRepository)
        {
            _iUserRepository = iUserRepository;
        }

        public Task<Response> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            Errors = new UserValidations(_iUserRepository).AddUserValidation(request);
            if (Errors.Count > 0)
            {
                return Task.FromResult(new Response(System.Net.HttpStatusCode.BadRequest, Errors, null));
            }

            var response = _iUserRepository.Add(request);

            return Task.FromResult(new Response(System.Net.HttpStatusCode.OK, null, response));
        }
    }
}
