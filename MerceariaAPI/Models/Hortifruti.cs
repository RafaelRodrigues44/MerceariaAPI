using System;

namespace MerceariaAPI.Models
{
    public class Hortifruti : Produto
    {
        // Propriedade ID
        public new int Id { get; set; }

        public Hortifruti(){

        }
        
        // Construtor da classe derivada Hortifruti que chama o construtor da classe base Produto
        public Hortifruti(int id, string nome, string descricao, string tipo)
            : base(nome, tipo, descricao)
        {
            this.Id = id;
        }
    }
}
