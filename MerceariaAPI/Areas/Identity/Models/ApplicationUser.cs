using MerceariaAPI.Models;
using Microsoft.AspNetCore.Identity;

namespace MerceariaAPI.Areas.Identity.Models
{
    // Modelo para representar um usuário
    public class ApplicationUser : IdentityUser
    {
        public virtual TypeUser TypeUser { get; set; }

         // Adicione a propriedade TypeUserId
        public int TypeUserId { get; set; }
    }

    // Modelo para representar uma função de superusuário
    public class ApplicationRole : IdentityRole
    {
    }
}
