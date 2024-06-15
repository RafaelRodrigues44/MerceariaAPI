using MerceariaAPI.Areas.Identity.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MerceariaAPI.Areas.Identity.Repositories.Role
{
    public interface IRoleRepository
    {
        Task<IEnumerable<ApplicationRole>> GetRoles();
        Task<ApplicationRole> GetRoleById(string id);
        Task<ApplicationRole> GetRoleByName(string roleName);
        Task CreateRole(ApplicationRole role);
        Task UpdateRole(ApplicationRole role);
        Task DeleteRole(ApplicationRole role);
    }
}

