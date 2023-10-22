using CurdOperation.Dtos;
using CurdOperation.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Identity_Project.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CurdController : ControllerBase
    {
        private readonly ICurdOperations _CurdOperations;
        public CurdController(ICurdOperations curdOperations)
        {
            _CurdOperations = curdOperations;
        }

        [HttpPost]
        [Route("Test")]
        public async Task<IActionResult> Test()
        {
            return Ok(await Task.FromResult("User Granted"));
        }
    }
}
