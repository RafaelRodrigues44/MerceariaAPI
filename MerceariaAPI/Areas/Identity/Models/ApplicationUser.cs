using Microsoft.AspNetCore.Identity;

namespace MerceariaAPI.Areas.Identity.Models
{
    // Modelo para representar um usuário
    public class ApplicationUser : IdentityUser
    {
    }

    // Modelo para representar uma função de supersuário
    public class ApplicationRole : IdentityRole
    {
    }
}
