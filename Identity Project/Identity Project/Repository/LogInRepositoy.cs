using Identity_Project.DbContexts;
using Identity_Project.Dtos;
using Identity_Project.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Identity_Project.Repository
{
    public class LogInRepositoy:ILogIn
    {
        private readonly ReadDbContext _contextR;
        private readonly WriteDbContext _contextW;
        IConfiguration _configuration;
        public LogInRepositoy(ReadDbContext readDbContext,WriteDbContext writeDbContext, IConfiguration configuration)
        {
            _contextR = readDbContext;
            _contextW = writeDbContext;
            _configuration = configuration;
        }
        public async Task<string> GenerateToken(UserDto user)
        {
            var res = await _contextR.TblUsers.Where(x => x.UserName == user.UserName && x.PassWord == user.PassWord).FirstOrDefaultAsync();
            if (res == null)
            {
                return "NOT FOUND";
            }

            var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]??string.Empty),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("UserId", user.UserId.ToString()),
                        //new Claim("DisplayName", "Iftekhar"),
                        //new Claim("UserName", "Ïftekhar Ahamed Siddiquee"),
                        //new Claim("Email", "iftekhar@ibos.io")
            };


            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"] ?? string.Empty));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);


            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.UtcNow.AddMinutes(50),
                signingCredentials: signIn);

            var tk = new JwtSecurityTokenHandler().WriteToken(token);
            return tk;
        }
    }
}
