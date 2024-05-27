using System;

namespace MerceariaAPI.Models
{
    public class Higiene : Produto
    {
        // Propriedade ID
        public new int Id { get; set; }

        public Higiene(){

        }
        
        // Construtor da classe derivada Higiene que chama o construtor da classe base Produto
        public Higiene(int id, string nome,  string descricao, string tipo)
            : base(nome, tipo, descricao)
        {
            this.Id = id;
        }
    }
}
