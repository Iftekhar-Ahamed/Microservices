using CurdOperation.IRepository;
using System.Security.Claims;
using System.Text;
using CurdOperation.Dtos;
using Dapper;
using Microsoft.Data.SqlClient;

namespace CurdOperation.Repository
{
    public class CurdOperationRepository : ICurdOperations
    {
        private readonly SqlConnection _dbConnection;
        public CurdOperationRepository(SqlConnection sqlConnection)
        {
            _dbConnection = sqlConnection;
        }
        public Task<List<UserDto>> AllUserData()
        {
            
            List<UserDto> res = _dbConnection.Query<UserDto>("select * from tblUser").ToList();
            return Task.FromResult(res);
          
        }
        public Task<List<UserDto>> GetUserById(int id)
        {
            var perameter = new { Id = id };
            List<UserDto> res = _dbConnection.Query<UserDto>("select * from tblUser where userId=@Id",perameter).ToList();
            return Task.FromResult(res);
        }
        public Task<List<UserDto>> UpdateUserById(UserDto obj)
        {
            var perameter = new {Id = obj.UserId };
            var res = GetUserById(Convert.ToInt32(obj.UserId));
            List<UserDto> ok = _dbConnection.Query<UserDto>("UPDATE User SET Username = @NewUsername, Email = @NewEmail WHERE UserId = @UserId", perameter).ToList();
            return Task.FromResult(res);
        }
    }
}
