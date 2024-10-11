using Dapper;
using Data.Connections;
using Domain.Entities.User;
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
        public UserGetByIdResponse GetById(int id)
        {
            using var connection = new SqlConnection(GetConnection());
            var sql = $@"SELECT Name, LastName, Email, DateOfBirth
                         FROM {TABLE}
                         WHERE DateRemoval IS NULL AND UserId = {id}";

            var response = connection.QuerySingleOrDefault<UserGetByIdResponse>(sql, new { Id = id });

            return response;
        }

        public int Add(AddUserCommand request)
        {
            using var connection = new SqlConnection(GetConnection());
            var sql = $@"
                       INSERT INTO {TABLE} (DateRegistration, Name, LastName, Email, DateOfBirth, ProfileID)
                       VALUES ( GETDATE(), '{request.Name}', '{request.LastName}', '{request.Email}', '{request.DateOfBirth}', {request.ProfileId})
                       SELECT CAST(SCOPE_IDENTITY() as int)";

            var response = connection.Query<int>(sql).First();

            return response;
        }

        public int Edit(EditUserCommand request)
        {
            using var connection = new SqlConnection(GetConnection());
            var sql = $@"
                       UPDATE {TABLE} SET DateChange = GETDATE(), Name = '{request.Name}', LastName = '{request.LastName}', Email = '{request.Email}', DateOfBirth = '{request.DateOfBirth}', ProfileID = {request.ProfileId}";

            if (request.DateRemoval != false)
            {
                sql += $@", DateRemoval = GETDATE()";
            }
            else
            {
                sql += $@", DateRemoval = NULL";
            }

            sql += $@" WHERE UserId = {request.Id}";

            var response = connection.Execute(sql);

            return request.Id;
        }
        public int Remove(RemoveUserCommand request)
        {
            using var connection = new SqlConnection(GetConnection());
            var sql = $@"
                       UPDATE {TABLE} SET DateRemoval = GETDATE()
                       WHERE UserId = {request.Id}";

            var response = connection.Execute(sql);

            return request.Id;
        }

        public bool Exist(ExistUserQuery request)
        {
            using var connection = new SqlConnection(GetConnection());
            var sql = $@"SELECT COUNT(*)
                 FROM {TABLE}
                 WHERE DateRemoval IS NULL 
                 AND Email = '{request.Email}'";

            if (request.Id != 0)
            {
                sql += $@" AND UserId != {request.Id}";
            }

            var count = connection.ExecuteScalar<int>(sql, new { Email = request.Email, UserId = request.Id });

            return count > 0;
        }
    }
}
