using Identity_Project.Dtos;
using System.Security.Claims;

namespace Identity_Project.IRepository
{
    public interface ILogIn
    {
        Task<string> GenerateToken(UserDto user);
    }
}
