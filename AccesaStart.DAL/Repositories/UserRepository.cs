using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;

namespace AccesaStart.DAL.Repositories
{
    public class UserRepository : IRepository<User>
    {
        public async Task Create(User user)
        {
            using (IDbConnection dbConnection = new SqlConnection(Configuration.ConnectionString))
            {
                var sQuery = "INSERT INTO Users (PhoneNumber, Password, FirstName, LastName, TotalBalance)"
                             + " VALUES(@PhoneNumber, @Password, @FirstName, @LastName, @TotalBalance)";
                dbConnection.Open();
                await dbConnection.ExecuteAsync(sQuery, user);
            }
        }

        public async Task<User> Read(string phoneNumber)
        {
            using (IDbConnection dbConnection = new SqlConnection(Configuration.ConnectionString))
            {
                var sQuery = "SELECT * FROM Users"
                             + " WHERE PhoneNumber = @PhoneNumber";
                dbConnection.Open();
                return (await dbConnection.QuerySingleAsync<User>(sQuery, new { PhoneNumber = phoneNumber }));
            }
        }

        public async Task Update(User user)
        {
            using (IDbConnection dbConnection = new SqlConnection(Configuration.ConnectionString))
            {
                var sQuery = "UPDATE Users SET Password = @Password,"
                             + " FirstName = @FirstName, LastName= @LastName, TotalBalance = @TotalBalance"
                             + " WHERE PhoneNumber = @PhoneNumber";
                dbConnection.Open();
                await dbConnection.QueryAsync(sQuery, user);
            }
        }
    }
}
