using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MerceariaAPI.Models
{
    public class Estoque
    {
        // Chave primária
        public int Id { get; set; }

        // Chave estrangeira para Produto
        public int ProdutoId { get; set; }
        
        // Quantidade em estoque
        public int Quantidade { get; set; }

        // Relação com a tabela Produto
        [ForeignKey("ProdutoId")]
        public Produto Produto { get; set; }
    }
}
