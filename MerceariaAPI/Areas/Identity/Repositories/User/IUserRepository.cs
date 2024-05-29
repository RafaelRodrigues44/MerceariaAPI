using MerceariaAPI.Areas.Identity.Models;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace MerceariaAPI.Areas.Identity.Repositories.User
{
    public interface IUserRepository
    {
        Task<IEnumerable<ApplicationUser>> GetUsers();
        Task<ApplicationUser> GetUserById(string id);
        Task CreateUser(ApplicationUser user);
        Task UpdateUser(ApplicationUser user);
        Task DeleteUser(ApplicationUser user);
    }
}