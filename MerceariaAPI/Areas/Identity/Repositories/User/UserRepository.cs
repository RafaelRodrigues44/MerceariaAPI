using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using MerceariaAPI.Areas.Identity.Models;
using MerceariaAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace MerceariaAPI.Areas.Identity.Repositories.User
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly AppDbContext _dbContext;

        public UserRepository(UserManager<ApplicationUser> userManager, AppDbContext dbContext)
        {
            _userManager = userManager;
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<ApplicationUser>> GetUsers()
        {
            return await Task.FromResult(_dbContext.Users);
        }

        public async Task<ApplicationUser> GetUserById(string id)
        {
            if (Guid.TryParse(id, out Guid userId))
            {
                return await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == userId.ToString());
            }
            return null;
        }

        public async Task<IdentityResult> CreateUser(ApplicationUser model) 
        {
            var user = new ApplicationUser
            {
                UserName = model.UserName,
                Email = model.Email,
                TypeUserId = model.TypeUserId
            };

            var result = await _userManager.CreateAsync(user);
            return result;
        }


        public async Task UpdateUser(ApplicationUser user)
        {
            _dbContext.Users.Update(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteUser(ApplicationUser user)
        {
            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();
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
