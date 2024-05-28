using System.ComponentModel.DataAnnotations.Schema;
using MerceariaAPI.Models;

namespace MerceariaAPI.Models
{
    public class Produto
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        [ForeignKey("TipoProduto")]
        public int TipoProdutoId { get; set; }
        public TipoProduto TipoProduto { get; set; } // Propriedade de navegação

        public string Descricao { get; set; }

        public Produto()
        {

        }

        public Produto(string nome, int tipoProdutoId, string descricao)
        {
            Nome = nome;
            TipoProdutoId = tipoProdutoId;
            Descricao = descricao;
        }
    }
}
