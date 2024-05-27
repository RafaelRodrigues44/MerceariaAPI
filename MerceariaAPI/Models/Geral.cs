using System;

namespace MerceariaAPI.Models
{
    public class Geral : Produto
    {
        // Propriedade ID
        public new int Id { get; set; }

        public Geral(){

        }
        
        // Construtor da classe derivada Geral que chama o construtor da classe base Produto
        public Geral(int id, string nome, string descricao, string tipo)
            : base(nome, tipo, descricao)
        {
            this.Id = id;
        }
    }
}
