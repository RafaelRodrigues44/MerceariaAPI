using System;

namespace MerceariaAPI.Models
{
    public class Biscoito : Produto
    {
        // Propriedade ID
       public new int Id { get; set; }

        public Biscoito(){
            
        }

        // Construtor da classe derivada Biscoito que chama o construtor da classe base Produto
        public Biscoito(int id, string nome,  string descricao, string tipo)
            : base(nome, tipo, descricao)
        {
            this.Id = id;
        }
    }
}

