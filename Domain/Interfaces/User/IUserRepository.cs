using Domain.Entities.User.Commands;
using Domain.Entities.User.Queries;
using Domain.Entities.User.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.User
{
    public interface IUserRepository
    {
        IEnumerable<UserListResponse> List();
        int Add(AddUserCommand request);
        bool Exist(ExistUserQuery request);
    }
}
