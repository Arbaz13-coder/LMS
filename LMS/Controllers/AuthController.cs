using LMS.DTOs;
using LMS.Models;
using LMS.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace LMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly ITokenService _tokenService;
        private readonly IMenuService _menuService;
        //private readonly ApiResponse apiResponse;
        public AuthController(IAuthService authService, ITokenService tokenService,IMenuService menuService)
        {
            _authService = authService;
            _tokenService = tokenService;
            _menuService = menuService;
        }

        [HttpPost("validate-user")]
        public IActionResult ValidateUser([FromBody] LoginRequestDto request)
        {
            var user = _authService.FindUserByUsernameOrEmail(request.UsernameOrEmail);
            if (user == null) return NotFound("User not found.");
            return Ok("Username or Email validated.");
        }

        [HttpPost("validate-password")]
        public async Task<RRM> ValidatePassword([FromBody] PasswordValidationDto dto)
        {
            //var result = _authService.ValidatePassword(dto.UsernameOrEmail, dto.Password);
            //if (!result.Success) return Unauthorized("Invalid credentials.");
            //var token = _tokenService.GenerateAccessToken(result.User);
            //return Ok(new { Token = token });
            RRM rRM = new RRM();
            var result = _authService.ValidatePassword(dto.UsernameOrEmail, dto.Password);
            if (!result.Success)
            {
                //apiResponse.Status = false;
                //apiResponse.Message = "Invalid Credential";
                //apiResponse.RData = null; 
                rRM.Message = "Invalid Credential";
                rRM.Status = "Failed";
                rRM.RData = null;
                return rRM;

            }
            else
            {
                var menu = await _menuService.GetMenuByRoleAsync(result.User);
                rRM.Status = "Success";
                rRM.Message = "OK";
                rRM.RData = menu;
                return rRM;
            }

        }
    }
}
