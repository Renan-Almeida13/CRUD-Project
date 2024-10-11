using Domain.Commons;
using Domain.Interfaces.ProfileType;
using MediatR;

namespace Domain.Entities.ProfileType.Queries
{
    public class ProfileTypeQueriesHandlers { }

    public class ListProfileTypeQueriesHandlers : IRequestHandler<ListProfileTypeQuery, Response>
    {
        private readonly IProfileTypeRepository _iProfileTypeRepository;

        public ListProfileTypeQueriesHandlers(IProfileTypeRepository iUserRepository)
        {
            _iProfileTypeRepository = iUserRepository;
        }

        public Task<Response> Handle(ListProfileTypeQuery request, CancellationToken cancellationToken)
        {
            var response = _iProfileTypeRepository.List();

            return Task.FromResult(new Response(System.Net.HttpStatusCode.OK, null, response));
        }
    }
}
