using MerceariaAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MerceariaAPI.Areas.Identity.Repositories
{
    public class TypeUserRepository : ITypeUserRepository
    {
        private readonly DbContext _context;

        public TypeUserRepository(DbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TypeUser>> GetTypesUsers()
        {
            return await _context.Set<TypeUser>().ToListAsync();
        }

        public async Task<TypeUser> GetTypeUserById(int id)
        {
            return await _context.Set<TypeUser>().FindAsync(id);
        }

        public async Task<TypeUser> CreateTypeUser(TypeUser typeUser)
        {
            _context.Set<TypeUser>().Add(typeUser);
            await _context.SaveChangesAsync();
            return typeUser;
        }

        public async Task UpdateTypeUser(TypeUser typeUser)
        {
            _context.Entry(typeUser).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTypeUser(TypeUser typeUser)
        {
            _context.Set<TypeUser>().Remove(typeUser);
            await _context.SaveChangesAsync();
        }
    }
}
