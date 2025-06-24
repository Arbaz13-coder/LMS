using LMS.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMenuService _menuService; 

        public MenuController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        //[HttpGet("role/{roleId}")]
        //public async Task<IActionResult> GetMenuByRole(Guid roleId)
        //{
        //    var menu = await _menuService.GetMenuByRoleAsync(roleId);
        //    return Ok(menu);
        //}
    }
}
