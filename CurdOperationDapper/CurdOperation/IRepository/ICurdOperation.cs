using CurdOperation.Dtos;
using System.Security.Claims;

namespace CurdOperation.IRepository
{
    public interface ICurdOperations
    {
        Task<List<UserDto>> AllUserData();
        Task<List<UserDto>> GetUserById(int id);
    }
}
