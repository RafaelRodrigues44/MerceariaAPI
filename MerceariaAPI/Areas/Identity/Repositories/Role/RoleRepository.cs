using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MerceariaAPI.Areas.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MerceariaAPI.Areas.Identity.Repositories.Role
{
    public class RoleRepository : IRoleRepository
    {
        private readonly RoleManager<ApplicationRole> _roleManager;

        public RoleRepository(RoleManager<ApplicationRole> roleManager)
        {
            _roleManager = roleManager ?? throw new ArgumentNullException(nameof(roleManager));
        }

        public async Task<IEnumerable<ApplicationRole>> GetRoles()
        {
            return await Task.FromResult(await _roleManager.Roles.ToListAsync());
        }

        public async Task<ApplicationRole> GetRoleById(string id)
        {
            return await _roleManager.FindByIdAsync(id);
        }

        public async Task CreateRole(ApplicationRole role)
        {
            if (role == null)
            {
                throw new ArgumentNullException(nameof(role));
            }

            await _roleManager.CreateAsync(role);
        }

        public async Task UpdateRole(ApplicationRole role)
        {
            if (role == null)
            {
                throw new ArgumentNullException(nameof(role));
            }

            await _roleManager.UpdateAsync(role);
        }

        public async Task DeleteRole(ApplicationRole role)
        {
            if (role == null)
            {
                throw new ArgumentNullException(nameof(role));
            }

            await _roleManager.DeleteAsync(role);
        }
    }
}
