using System;

namespace MerceariaAPI.Models
{
    public class Utensilios : Produto
    {
        // Propriedade ID
        public new int Id { get; set; }

        public Utensilios(){

        }
        
        // Construtor da classe derivada Utensilios que chama o construtor da classe base Produto
        public Utensilios(int id, string nome, string descricao, string tipo)
            : base(nome, tipo, descricao)
        {
            this.Id = id;
        }
    }
}
