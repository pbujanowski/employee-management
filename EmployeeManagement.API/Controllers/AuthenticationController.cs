using EmployeeManagement.API.Models;
using EmployeeManagement.API.Services;
using EmployeeManagement.Core.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService<UserDto> authenticationService;

        public AuthenticationController(IAuthenticationService<UserDto> authenticationService)
        {
            this.authenticationService = authenticationService;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] AuthenticationDto dto)
        {
            var user = authenticationService.Authenticate(dto.Username, dto.Password);
            if (user == null)
                return BadRequest(new { message = "Podane dane są nieprawidłowe!" });

            return Ok(user);
        }

        [Authorize(Roles = Roles.Administrator)]
        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var users = authenticationService.GetAll();
            return Ok(users);
        }
    }
}