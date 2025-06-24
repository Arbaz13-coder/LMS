using LMS.DTOs;
using LMS.Models;

namespace LMS.Services
{
    public interface IMenuService
    {
        Task<List<ModuleDto>> GetMenuByRoleAsync(User userName);

    }
}
