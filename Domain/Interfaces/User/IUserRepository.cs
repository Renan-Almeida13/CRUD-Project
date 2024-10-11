using Domain.Entities.User.Commands;
using Domain.Entities.User.Queries;
using Domain.Entities.User.Responses;

namespace Domain.Interfaces.User
{
    public interface IUserRepository
    {
        IEnumerable<UserListResponse> List();
        UserGetByIdResponse GetById(int id);
        int Add(AddUserCommand request);
        int Edit(EditUserCommand request);
        int Remove(RemoveUserCommand request);
        bool Exist(ExistUserQuery request);
    }
}
