using System;

namespace MerceariaAPI.Models
{
    public class Doce : Produto
    {
        // Propriedade ID
        public new int Id { get; set; }

        public Doce(){
            
        }

        // Construtor da classe derivada Doce que chama o construtor da classe base Produto
        public Doce(int id, string nome, string tipo, string descricao)
            : base(nome, tipo, descricao)
        {
            this.Id = id;
        }
    }
}
