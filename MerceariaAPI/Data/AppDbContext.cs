using Microsoft.EntityFrameworkCore;
using MerceariaAPI.Models;

namespace MerceariaAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // DbSet para cada entidade
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Entrada> Entradas { get; set; }
        public DbSet<Venda> Vendas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuração dos relacionamentos entre Entrada e Produto
            modelBuilder.Entity<Entrada>()
                .HasOne(e => e.Produto)
                .WithMany(p => p.Entradas)
                .HasForeignKey(e => e.ProdutoId);

            // Configuração do relacionamento muitos-para-muitos entre Entrada e Venda
            modelBuilder.Entity<EntradaVenda>()
                .HasKey(ev => new { ev.EntradaId, ev.VendaId });

            modelBuilder.Entity<EntradaVenda>()
                .HasOne(ev => ev.Entrada)
                .WithMany(e => e.EntradaVendas)
                .HasForeignKey(ev => ev.EntradaId);

            modelBuilder.Entity<EntradaVenda>()
                .HasOne(ev => ev.Venda)
                .WithMany(v => v.EntradaVendas)
                .HasForeignKey(ev => ev.VendaId);

            // Configuração de TPH para Produto
            modelBuilder.Entity<Produto>()
                .HasDiscriminator<string>("Tipo")
                .HasValue<Cereal>("Cereal")
                .HasValue<Laticinio>("Laticinio")
                .HasValue<Carne>("Carne")
                .HasValue<Doce>("Doce")
                .HasValue<Hortifruti>("Hortifruti")
                .HasValue<Bebida>("Bebida")
                .HasValue<Limpeza>("Limpeza")
                .HasValue<Higiene>("Higiene")
                .HasValue<Geral>("Geral")
                .HasValue<Papelaria>("Papelaria")
                .HasValue<Utensilios>("Utensilios")
                .HasValue<Biscoito>("Biscoito")
                .HasValue<Padaria>("Padaria")
                .HasValue<Frios>("Frios");
        }
    }
}
