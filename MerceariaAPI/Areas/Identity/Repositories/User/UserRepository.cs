using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using MerceariaAPI.Areas.Identity.Models;

namespace MerceariaAPI.Areas.Identity.Repositories.User
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserRepository(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IEnumerable<ApplicationUser>> GetUsers()
        {
            return await Task.FromResult(_userManager.Users);
        }

        public async Task<ApplicationUser> GetUserById(string id)
        {
            return await _userManager.FindByIdAsync(id);
        }

        public async Task<IdentityResult> CreateUser(ApplicationUser user, string password) 
        {
            var result = await _userManager.CreateAsync(user, password);
            return result;
        }

        public async Task UpdateUser(ApplicationUser user)
        {
            await _userManager.UpdateAsync(user);
        }

        public async Task DeleteUser(ApplicationUser user)
        {
            await _userManager.DeleteAsync(user);
        }

        public async Task<ApplicationUser> GetUserByUsername(string username)
        {
            return await _userManager.FindByNameAsync(username);
        }

        public async Task<ApplicationUser> GetUserByEmail(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<bool> CheckPasswordAsync(ApplicationUser user, string password)
        {
            return await _userManager.CheckPasswordAsync(user, password);
        }

        public async Task<(string username, string passwordHash)> GetLoginCredentials(string username)
        {
                var user = await _userManager.FindByNameAsync(username);
                if (user == null)
                {
                    return (null, null);
                }
                return (user.UserName, user.PasswordHash);
        }

    }
}
