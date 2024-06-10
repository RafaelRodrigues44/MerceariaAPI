using MerceariaAPI.Areas.Identity.Models;
using MerceariaAPI.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MerceariaAPI.Areas.Identity.Repositories.Type
{
    public class TypeUserRepository : ITypeUserRepository
    {
        private readonly AppDbContext _context;

        public TypeUserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TypeUser>> GetTypeUsers()
        {
            return await _context.TypeUsers.ToListAsync();
        }

        public async Task<TypeUser> GetById(int id)
        {
            return await _context.TypeUsers.FindAsync(id);
        }

        public async Task CreateTypeUser(TypeUser typeUser)
        {
            _context.TypeUsers.Add(typeUser);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTypeUser(TypeUser typeUser)
        {
            _context.Entry(typeUser).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTypeUser(TypeUser typeUser)
        {
            _context.TypeUsers.Remove(typeUser);
            await _context.SaveChangesAsync();
        }
    }
}
