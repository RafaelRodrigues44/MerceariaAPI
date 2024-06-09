using MerceariaAPI.Models;
using Microsoft.AspNetCore.Identity;

namespace MerceariaAPI.Areas.Identity.Models
{
    // Modelo para representar um usuário
    public class ApplicationUser : IdentityUser
    {

        // Propriedade de navegação para o TypeUser
        public virtual TypeUser TypeUser { get; set; }
    }

    // Modelo para representar uma função de superusuário
    public class ApplicationRole : IdentityRole
    {
    }

     public class RegisterModel
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int TypeUser { get; set; }
    }
}
