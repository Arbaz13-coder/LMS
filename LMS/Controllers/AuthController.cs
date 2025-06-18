using LMS.DTOs;
using LMS.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly ITokenService _tokenService;
        public AuthController(IAuthService authService, ITokenService tokenService)
        {
            _authService = authService;
            _tokenService = tokenService;
        }

        [HttpPost("validate-user")]
        public IActionResult ValidateUser([FromBody] LoginRequestDto request)
        {
            var user = _authService.FindUserByUsernameOrEmail(request.UsernameOrEmail);
            if (user == null) return NotFound("User not found.");
            return Ok("Username or Email validated.");
        }

        [HttpPost("validate-password")]
        public IActionResult ValidatePassword([FromBody] PasswordValidationDto dto)
        {
            //var result = _authService.ValidatePassword(dto.UsernameOrEmail, dto.Password);
            //if (!result.Success) return Unauthorized("Invalid credentials.");
            //var token = _tokenService.GenerateAccessToken(result.User);
            //return Ok(new { Token = token });
            var result = _authService.ValidatePassword(dto.UsernameOrEmail, dto.Password);
            if (!result.Success) return Unauthorized("Invalid Credential");
            return Ok("Password Verified Successfully");

        }
    }
}
