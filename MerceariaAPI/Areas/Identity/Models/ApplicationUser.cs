using MerceariaAPI.Models;
using Microsoft.AspNetCore.Identity;

namespace MerceariaAPI.Areas.Identity.Models
{
    // Modelo para representar um usuário
    public class ApplicationUser : IdentityUser
    {
        public string Tipo { get; set; }

        // Propriedade de navegação para o TypeUser
        public virtual TypeUser TypeUser { get; set; }
    }

    // Modelo para representar uma função de superusuário
    public class ApplicationRole : IdentityRole
    {
    }
}
