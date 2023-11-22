using Domain.Commons;
using Domain.Interfaces.User;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.User.Queries
{
    public class UserQueriesHandlers { }

    public class ListUserQueryHandlers : IRequestHandler<ListUserQuery, Response> 
    {
        private readonly IUserRepository _iUserRepository;

        public ListUserQueryHandlers(IUserRepository iUserRepository)
        {
            _iUserRepository = iUserRepository;
        }

        public Task<Response> Handle(ListUserQuery request, CancellationToken cancellationToken)
        {
            var response = _iUserRepository.List();

            return Task.FromResult(new Response(System.Net.HttpStatusCode.OK, null, response));
        }
    }
}
