using MerceariaAPI.Areas.Identity.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MerceariaAPI.Areas.Identity.Repositories.Type
{
    public interface ITypeUserRepository
    {
        Task<IEnumerable<TypeUser>> GetTypeUsers();
        Task<TypeUser> GetById(int id);
        Task CreateTypeUser(TypeUser typeUser);
        Task UpdateTypeUser(TypeUser typeUser);
        Task DeleteTypeUser(TypeUser typeUser);
    }
}
