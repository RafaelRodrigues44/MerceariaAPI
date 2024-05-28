using MerceariaAPI.Areas.Identity.Models;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace MerceariaAPI.Areas.Identity.Repositories
{
    public interface IRoleRepository
    {
        Task<IEnumerable<ApplicationRole>> GetRoles();
        Task<ApplicationRole> GetRoleById(string id);
        Task CreateRole(ApplicationRole role);
        Task UpdateRole(ApplicationRole role);
        Task DeleteRole(ApplicationRole role);
    }
}



