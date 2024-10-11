using Domain.Commons;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.User.Queries
{
    public class UserQueries { }
    public class ListUserQuery : IRequest<Response> { }
    public class GetByIdUserQuery : IRequest<Response>
    {
        public int Id { get; set; }
    }
    public class ExistUserQuery : IRequest<Response> 
    {
        public int Id { get; set; }
        public string Email { get; set; }
    }

}
