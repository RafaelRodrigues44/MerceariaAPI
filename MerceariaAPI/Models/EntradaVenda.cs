using System;

namespace MerceariaAPI.Models
{
    public class EntradaVenda
    {
        // Chaves estrangeiras
        public int EntradaId { get; set; }
        public required Entrada Entrada { get; set; }

        public int VendaId { get; set; }
        public required Venda Venda { get; set; }

        // Informações sobre a venda do item do estoque
        public decimal PrecoVenda { get; set; } // Preço de venda do item
        public int QuantidadeVendida { get; set; } // Quantidade vendida do item

        // Preço de compra do item, obtido automaticamente do estoque correspondente
        public decimal PrecoCompra => Entrada.PrecoCompra;

        // Construtor padrão 
        public EntradaVenda()
        #pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

        {
        }
    }
}
