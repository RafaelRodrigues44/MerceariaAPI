using System;

namespace MerceariaAPI.Models
{
    public class Limpeza : Produto
    {
        // Propriedade ID
        public new int Id { get; set; }

        public Limpeza(){

        }
        
        // Construtor da classe derivada Limpeza que chama o construtor da classe base Produto
        public Limpeza(int id, string nome, string descricao, string tipo)
            : base(nome, tipo, descricao)
        {
            this.Id = id;
        }
    }
}
