using System;

namespace MerceariaAPI.Models
{
    public class Frios : Produto
    {
        // Propriedade ID
        public new int Id { get; set; }

        public Frios(){
            
        }

        // Construtor da classe derivada Frios que chama o construtor da classe base Produto
        public Frios(int id, string nome, string descricao, string tipo)
            : base(nome, tipo, descricao)
        {
            this.Id = id;
        }
    }
}
