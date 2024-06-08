using MerceariaAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MerceariaAPI.Areas.Identity.Repositories
{
    public interface ITypeUserRepository
    {
        Task<IEnumerable<TypeUser>> GetTypesUsers();
        Task<TypeUser> GetTypeUserById(int id);
        Task<TypeUser> CreateTypeUser(TypeUser typeUser);
        Task UpdateTypeUser(TypeUser typeUser);
        Task DeleteTypeUser(TypeUser typeUser);
    }
}
