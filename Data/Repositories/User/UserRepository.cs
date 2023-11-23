using Dapper;
using Data.Connections;
using Domain.Entities.User.Commands;
using Domain.Entities.User.Queries;
using Domain.Entities.User.Responses;
using Domain.Interfaces.User;
using System.Data.SqlClient;

namespace Data.Repositories.User
{
    public class UserRepository : MSSQL, IUserRepository
    {
        private const string TABLE = "Users";

        public IEnumerable<UserListResponse> List()
        {
            using var connection = new SqlConnection(GetConnection());
            var sql = $@"SELECT *
                         FROM {TABLE}
                         WHERE DateRemoval IS NULL";

            var response = connection.Query<UserListResponse>(sql);

            return response;
        }

        public int Add(AddUserCommand request)
        {
            using var connection = new SqlConnection(GetConnection());
            var sql = $@"
                       INSERT INTO {TABLE} (IdUserRegistration, DateRegistration, Name, LastName, Email, DateOfBirth)
                       VALUES ({request.UserId}, GETDATE(), '{request.Name}', '{request.LastName}', '{request.Email}', '{request.DateOfBirth}')
                       SELECT CAST(SCOPE_IDENTITY() as int)";

            var response = connection.Query<int>(sql).First();

            return response;
        }

        public bool Exist(ExistUserQuery request)
        {
            using var connection = new SqlConnection(GetConnection());
            var sql = $@"SELECT *
                         FROM {TABLE}
                         WHERE DateRemoval IS NULL";

            if (request.Id != 0)
            {
                sql += $@"
                        AND Id <> {request.Id}";
            }

            sql += $@"
                        AND Email <> {request.Email}";

            var response = connection.Query<UserGetResponse>(sql).Count() > 0 ? true : false;

            return response;
        }
    }
}
