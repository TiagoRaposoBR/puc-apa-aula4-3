using Domain.Entities;
using Infrastructure.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context
{
    public class SQLiteContext : DbContext
    {
        public DbSet<ContaCorrente> ContaCorrente { get; set; }
        public DbSet<Correntista> Correntista { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Utilizando um servidor SQLite local. Aqui poderíamos configurar qualquer outro banco de dados.
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlite("DataSource=app.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ContaCorrente>(new ContaCorrenteMap().Configure);
            modelBuilder.Entity<Correntista>(new CorrentistaMap().Configure);
        }
    }
}