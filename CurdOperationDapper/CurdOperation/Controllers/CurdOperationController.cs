using CurdOperation.Dtos;
using CurdOperation.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Identity_Project.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CurdController : ControllerBase
    {
        private readonly ICurdOperations _CurdOperations;
        public CurdController(ICurdOperations curdOperations)
        {
            _CurdOperations = curdOperations;
        }

        [HttpGet]
        [Route("AllUserData")]
        public async Task<IActionResult> AllUserData()
        {
            return Ok(_CurdOperations.AllUserData());
        }
        [HttpPost]
        [Route("GetUserById")]
        public async Task<IActionResult> GetUserById(int id)
        {
            return Ok(_CurdOperations.GetUserById(id));
        }
    }
}
