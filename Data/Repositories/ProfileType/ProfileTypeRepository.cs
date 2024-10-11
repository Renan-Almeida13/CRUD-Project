using Dapper;
using Data.Connections;
using Domain.Entities.ProfileType.Responses;
using Domain.Interfaces.ProfileType;
using System.Data.SqlClient;

namespace Data.Repositories.ProfileType
{
    public class ProfileTypeRepository : MSSQL, IProfileTypeRepository
    {
        private const string TABLE = "ProfileTypes";

        public IEnumerable<ProfileTypeListResponse> List()
        {
            using var connection = new SqlConnection(GetConnection());
            var sql = $@"SELECT *
                         FROM {TABLE}";

            var response = connection.Query<ProfileTypeListResponse>(sql);

            return response;
        }
    }
}
