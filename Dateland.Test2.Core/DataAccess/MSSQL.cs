using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Dateland.Test2.Core
{
    public class MSSQL : IRepository
    {

        private IDbConnection SqlConnectionString
            => new SqlConnection(RepoHelpers.GetConnectionString("DefaultConnection"));

        public async Task AddUser(User user)
        {
            using(IDbConnection cnn = SqlConnectionString)
            {
                await cnn.QueryAsync("usp_AddUser",
                    new { firstName = user.FirstName, lastName = user.LastName, emailAdress = user.EmailAdress },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            using(IDbConnection cnn = SqlConnectionString)
            {
                var result = await cnn.QueryAsync<User>("usp_GetUsers",
                    commandType: CommandType.StoredProcedure);

                return result;
            }
        }
    }
}
