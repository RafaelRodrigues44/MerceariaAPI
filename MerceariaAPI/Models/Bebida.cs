using System;

namespace MerceariaAPI.Models
{
    public class Bebida : Produto
    {
        // Propriedade ID pública
        public new int Id { get; set; }

        // Construtor padrão necessário para o EF Core
        public Bebida()
        {
        }

        // Construtor da classe derivada Bebida que chama o construtor da classe base Produto
        public Bebida(int id, string nome, string descricao, string tipo)
            : base(nome, tipo, descricao)
        {
            Id = id;
        }
    }
}
