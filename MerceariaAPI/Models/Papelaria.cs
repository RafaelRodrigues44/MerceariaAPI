using System;

namespace MerceariaAPI.Models
{
    public class Papelaria : Produto
    {
        // Propriedade ID
        public new int Id { get; set; }

        public Papelaria(){

        }
        
        // Construtor da classe derivada Papelaria que chama o construtor da classe base Produto
        public Papelaria(int id, string nome, string descricao, string tipo)
            : base(nome, tipo, descricao)
        {
            this.Id = id;
        }
    }
}
