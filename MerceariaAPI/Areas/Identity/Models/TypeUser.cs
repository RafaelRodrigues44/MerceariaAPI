using System.ComponentModel.DataAnnotations;

namespace MerceariaAPI.Areas.Identity.Models
{
    public class TypeUser
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }
    }
}
