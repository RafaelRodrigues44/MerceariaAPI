using System;

namespace MerceariaAPI.Models
{
    public class Cereal : Produto
    {
        // Propriedade ID
        private int id;

        // Construtor da classe derivada Cereal que chama o construtor da classe base Produto
        public Cereal(int id, string nome, decimal preco, int estoque, DateTime dataFabricacao, DateTime dataValidade, string lote, string fornecedor, string descricao, string tipo)
            : base(nome, tipo, preco, estoque, dataFabricacao, dataValidade, lote, fornecedor, descricao)
        {
            this.id = id;
        }

        // Getter para ID
        public int Id
        {
            get { return id; }
        }
    }
}
