using LMS.Data;
using LMS.DTOs;
using System;
using System.Reflection;
using LMS.Models;
using Module = LMS.Models.Module;
using Microsoft.EntityFrameworkCore;

namespace LMS.Services
{
    public class MenuService : IMenuService
    {
        private readonly ApplicationDbContext _context;
        public MenuService(ApplicationDbContext context) { _context = context; }
        public async Task<List<ModuleDto>> GetMenuByRoleAsync(User userName)
        {
            List<Module> mDto = new List<Module>();

            try
            {
                var roleIds =await GetRoleId(userName);


                var modules = await _context.Permissions
                    .Include(p => p.ModuleName)
                    .Where(p => roleIds.Contains(p.RoleId) && p.CanView && p.IsActive)
                    .Select(p => p.ModuleName)
                    .Where(m => m.IsActive && m.IsVisible)
                    .Distinct()
                    .ToListAsync();

                return BuildModuleTree(modules, null);
            } catch(Exception ex)
            {

                return new List<ModuleDto>();
            }
           
        }
        public async Task<List<Guid>> GetRoleId(User userName)
        {
            var roleIds = await _context.UserRoles
        .Where(ur => ur.UserId == userName.UserId)
        .Select(ur => ur.RoleId)
        .ToListAsync();

            return roleIds;
        }

        private List<ModuleDto> BuildModuleTree(List<Module> allModules, Guid? parentId)
        {
            return allModules
                .Where(m => m.ParentModuleId == parentId)
                .OrderBy(m => m.DisplayOrder)
                .Select(m => new ModuleDto
                {
                    ModuleId = m.ModuleId,
                    ModuleName = m.ModuleName,
                    RoutePath = m.RoutePath,
                    Icon = m.Icon,
                    Children = BuildModuleTree(allModules, m.ModuleId)
                })
                .ToList();
        }
    }
}
