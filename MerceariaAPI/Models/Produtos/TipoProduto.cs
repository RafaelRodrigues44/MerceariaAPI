using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MerceariaAPI.Models
{
    public class TipoProduto
    {
        [Key]
        public int Id { get; set; }

        public string Nome { get; set; }
    }
}
