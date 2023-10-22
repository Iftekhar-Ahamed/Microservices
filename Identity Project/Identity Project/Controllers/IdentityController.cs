using Identity_Project.Dtos;
using Identity_Project.IRepository;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Identity_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController:ControllerBase
    {
        private readonly ILogIn _LogIn;
        public IdentityController(ILogIn logIn) {
            _LogIn = logIn;
        }
        [HttpPost]
        [Route("Authentication")]
        public async Task<IActionResult> Authentication(UserDto user)
        {
            return Ok(await _LogIn.GenerateToken(user));
        }
    }
}
