using System;

namespace MerceariaAPI.Models
{
    public abstract class Produto
    {
        // Atributos protegidos para permitir acesso pelas classes derivadas
        protected string nome;
        protected string tipo;
        protected decimal preco;
        protected int estoque;
        protected DateTime dataFabricacao;
        protected DateTime dataValidade;
        protected string lote;
        protected string fornecedor;
        protected string descricao;

        // Construtor
        protected Produto(string nome, string tipo, decimal preco, int estoque, DateTime dataFabricacao, DateTime dataValidade, string lote, string fornecedor, string descricao)
        {
            this.nome = nome;
            this.tipo = tipo;
            this.preco = preco;
            this.estoque = estoque;
            this.dataFabricacao = dataFabricacao;
            this.dataValidade = dataValidade;
            this.lote = lote;
            this.fornecedor = fornecedor;
            this.descricao = descricao;
        }
    }
}
