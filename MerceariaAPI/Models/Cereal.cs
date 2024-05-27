using System;

namespace MerceariaAPI.Models
{
    public class Cereal : Produto
    {
        // Propriedade ID
        public new int Id { get; set; }

        public Cereal(){
            
        }

        // Construtor da classe derivada Cereal que chama o construtor da classe base Produto
        public Cereal(int id, string nome, string descricao, string tipo)
            : base(nome, tipo, descricao)
        {
            this.Id = id;
        }
    }
}
