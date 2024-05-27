using System;

namespace MerceariaAPI.Models
{
    public class Padaria : Produto
    {
        // Propriedade ID
        public new int Id { get; set; }

        public Padaria(){

        }
        
        // Construtor da classe derivada Padaria que chama o construtor da classe base Produto
        public Padaria(int id, string nome, string descricao, string tipo)
            : base(nome, tipo, descricao)
        {
            this.Id = id;
        }
    }
}
