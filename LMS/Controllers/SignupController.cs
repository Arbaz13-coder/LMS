using LMS.DTOs;
using LMS.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignupController : ControllerBase
    {
        private readonly IAuthService _authService;
        public SignupController(IAuthService authService) { _authService = authService; }

        [HttpPost]
        public IActionResult Register([FromBody] SignupDto dto)
        {
            var result = _authService.RegisterUser(dto);
            if (!result.Success) return BadRequest(result.Message);
            return Ok("Signup successful.");
        }
    }
}
