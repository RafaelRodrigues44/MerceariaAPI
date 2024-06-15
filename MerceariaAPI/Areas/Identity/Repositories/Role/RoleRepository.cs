using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using MerceariaAPI.Areas.Identity.Models;

namespace MerceariaAPI.Areas.Identity.Repositories.Role
{
    public class RoleRepository : IRoleRepository
    {
        private readonly RoleManager<ApplicationRole> _roleManager;

        public RoleRepository(RoleManager<ApplicationRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<IEnumerable<ApplicationRole>> GetRoles()
        {
            return await Task.FromResult(_roleManager.Roles);
        }

        public async Task<ApplicationRole> GetRoleById(string id)
        {
            return await _roleManager.FindByIdAsync(id);
        }

        public async Task<ApplicationRole> GetRoleByName(string roleName)
        {
            return await _roleManager.FindByNameAsync(roleName);
        }

        public async Task CreateRole(ApplicationRole role)
        {
            await _roleManager.CreateAsync(role);
        }

        public async Task UpdateRole(ApplicationRole role)
        {
            await _roleManager.UpdateAsync(role);
        }

        public async Task DeleteRole(ApplicationRole role)
        {
            await _roleManager.DeleteAsync(role);
        }
    }
}
