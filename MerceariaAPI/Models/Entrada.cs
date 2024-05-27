using System;
using System.Collections.Generic;

namespace MerceariaAPI.Models
{
    public class Entrada
    {
        public int EntradaId { get; set; }
        public DateTime DataEntrada { get; set; }
        public string Lote { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoCompra { get; set; } // Preço unitário de compra do produto

        // Lista de produtos na entrada
        public ICollection<Produto> Produtos { get; set; }

        // Propriedade de navegação para EntradaVendas
        public ICollection<EntradaVenda> EntradaVendas { get; set; }

        // Construtor padrão 
        public Entrada()
        {
        }

        public Entrada(DateTime dataEntrada, string lote, int quantidade, decimal precoCompra)
        {
            DataEntrada = dataEntrada;
            Lote = lote;
            Quantidade = quantidade;
            PrecoCompra = precoCompra;
        }
    }
}
