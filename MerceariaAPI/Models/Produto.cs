using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MerceariaAPI.Models
{
    public abstract class Produto
    {
        [Key]
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Tipo { get; set; }

        public string Descricao { get; set; }

        public Produto()
        {

        }

        public Produto(string nome, string tipo, string descricao)
        {
            Nome = nome;
            Tipo = tipo;
            Descricao = descricao;
        }
    }
}
