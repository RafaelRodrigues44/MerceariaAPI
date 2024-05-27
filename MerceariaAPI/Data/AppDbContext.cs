using Microsoft.EntityFrameworkCore;
using MerceariaAPI.Models;

namespace MerceariaAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Cereal> Cereal { get; set; }
        public DbSet<Laticinio> Laticinio { get; set; }
        public DbSet<Carne> Carne { get; set; }
        public DbSet<Doce> Doce { get; set; }
        public DbSet<Hortifruti> Hortifruti { get; set; }
        public DbSet<Bebida> Bebida { get; set; }
        public DbSet<Limpeza> Limpeza { get; set; }
        public DbSet<Higiene> Higiene { get; set; }
        public DbSet<Geral> Geral { get; set; }
        public DbSet<Papelaria> Papelaria { get; set; }
        public DbSet<Utensilios> Utensilios { get; set; }
        public DbSet<Biscoito> Biscoito { get; set; }
        public DbSet<Padaria> Padaria { get; set; }
        public DbSet<Frios> Frios { get; set; }
    }
}
