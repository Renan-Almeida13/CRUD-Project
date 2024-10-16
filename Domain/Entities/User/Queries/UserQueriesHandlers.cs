﻿using Domain.Commons;
using Domain.Interfaces.User;
using MediatR;

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
    public class GetByIdUserQueryHandler : IRequestHandler<GetByIdUserQuery, Response>
    {
        private readonly IUserRepository _userRepository;

        public GetByIdUserQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<Response> Handle(GetByIdUserQuery request, CancellationToken cancellationToken)
        {
            var response =  _userRepository.GetById(request.Id);

            return Task.FromResult(new Response(System.Net.HttpStatusCode.OK, null, response));
        }
    }
}
