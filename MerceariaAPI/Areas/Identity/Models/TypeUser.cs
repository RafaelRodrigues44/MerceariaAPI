using System.ComponentModel.DataAnnotations;

namespace MerceariaAPI.Models
{
    public class TypeUser
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }
    }
}
