using System;

namespace MerceariaAPI.Models
{
    public class Laticinio : Produto
    {
        // Propriedade ID
        public new int Id { get; set; }

        public Laticinio(){

        }
        
        // Construtor da classe derivada Laticinio que chama o construtor da classe base Produto
        public Laticinio(int id, string nome, string descricao, string tipo)
            : base(nome, tipo, descricao)
        {
            this.Id = id;
        }
    }
}
