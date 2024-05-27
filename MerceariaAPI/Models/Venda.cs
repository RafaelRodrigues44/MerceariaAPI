using System;

namespace MerceariaAPI.Models
{
    public class Venda
    {
        // Propriedades
        public int VendaId { get; set; }
        public int EntradaId { get; set; }  // Chave estrangeira para a entrada no estoque
        public Entrada Entradas { get; set; } // Navegação para a entrada no estoque
        public DateTime DataVenda { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }
        public decimal Total { get; set; }

        // Propriedade de navegação para EntradaVendas
        public ICollection<EntradaVenda> EntradaVendas { get; set; }

        // Construtor
        #pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

        public Venda() {}
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.


#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

        public Venda(int entradaId, Entrada entrada, DateTime dataVenda, int quantidade, decimal precoUnitario, decimal total)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

        {
            EntradaId = entradaId;
            Entradas = entrada;
            DataVenda = dataVenda;
            Quantidade = quantidade;
            PrecoUnitario = precoUnitario;
            Total = total;
        }
    }
}
