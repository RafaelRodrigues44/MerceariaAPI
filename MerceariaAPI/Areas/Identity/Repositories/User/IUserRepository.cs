using MerceariaAPI.Areas.Identity.Models;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MerceariaAPI.Areas.Identity.Repositories.User
{
    public interface IUserRepository
    {
        Task<IEnumerable<ApplicationUser>> GetUsers();
        Task<ApplicationUser> GetUserById(int id);
        Task<IdentityResult> CreateUser(ApplicationUser user, string password);
        Task UpdateUser(ApplicationUser user);
        Task DeleteUser(ApplicationUser user);
        Task<bool> CheckPasswordAsync(ApplicationUser user, string password);
        Task<(string username, string passwordHash)> GetLoginCredentials(string username);
    }
}
