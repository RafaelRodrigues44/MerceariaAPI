using System;
using System.Collections.Generic;

namespace MerceariaAPI.Models
{
    public class Compra
    {
        public int CompraId { get; set; } 
        public DateTime DataCompra { get; set; }
        public string Lote { get; set; } 
        public DateTime DataFabricacao { get; set; }
        public DateTime DataValidade { get; set; }
        public string Fabricante { get; set; }
        public string Vendedor { get; set; }
        public string Transportadora { get; set; }
        public decimal PrecoCompra { get; set; }
        public decimal PrecoVenda { get; set; }

        // Lista de produtos comprados nesta compra
        public List<Produto> Produtos { get; set; }

        // Construtor padrão 
        public Compra()
        {
            // Inicializa a lista de produtos para evitar exceções de referência nula
            Produtos = new List<Produto>();
        }

        public Compra(DateTime dataCompra, string lote, DateTime dataFabricacao, DateTime dataValidade, string fabricante, string vendedor, string transportadora, decimal precoCompra, decimal precoVenda)
        {
            DataCompra = dataCompra;
            Lote = lote;
            DataFabricacao = dataFabricacao;
            DataValidade = dataValidade;
            Fabricante = fabricante;
            Vendedor = vendedor;
            Transportadora = transportadora;
            PrecoCompra = precoCompra;
            PrecoVenda = precoVenda;
            Produtos = new List<Produto>(); // Inicializa a lista de produtos
        }
    }
}
