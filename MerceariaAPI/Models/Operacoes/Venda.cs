using System;
using System.Collections.Generic;

namespace MerceariaAPI.Models
{
    public class Venda
    {
        // Propriedades
        public int VendaId { get; set; }
        public DateTime DataVenda { get; set; }
        public string NomeVendedor { get; set; } // Nome do vendedor
        public decimal Total { get; set; } // Total da venda
        public List<Produto> ItensVenda { get; set; } // Lista de itens vendidos

        // Construtor padrão
        public Venda()
        {
            ItensVenda = new List<Produto>();
        }

        // Construtor
        public Venda(DateTime dataVenda, string nomeVendedor)
        {
            DataVenda = dataVenda;
            NomeVendedor = nomeVendedor;
            ItensVenda = new List<Produto>();
        }
    }

    public class ItemVenda
    {
        public Produto Produto { get; set; }
        public decimal PrecoUnitario { get; set; } // Preço unitário do produto na venda
        public int Quantidade { get; set; } // Quantidade vendida

        // Construtor
        public ItemVenda(Produto produto, decimal precoUnitario, int quantidade)
        {
            Produto = produto;
            PrecoUnitario = precoUnitario;
            Quantidade = quantidade;
        }
    }
}
