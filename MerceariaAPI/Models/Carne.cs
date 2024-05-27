using System;

namespace MerceariaAPI.Models
{
    public class Carne : Produto
    {
        // Propriedade ID
        public new int Id { get; set; }

        public Carne(){
            
        }

        // Construtor da classe derivada Carne que chama o construtor da classe base Produto
        public Carne(int id, string nome, string descricao, string tipo)
            : base(nome, tipo, descricao)
        {
            this.Id = id;
        }
    }
}
