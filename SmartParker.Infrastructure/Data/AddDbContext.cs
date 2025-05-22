using Microsoft.EntityFrameworkCore;
using SmartParker.Domain.Entities;

namespace SmartParker.Infrastructure.Data
{
    public class SmartParkerDbContext : DbContext
    {
        public SmartParkerDbContext(DbContextOptions<SmartParkerDbContext> options) : base(options) { }

        public DbSet<Moto> Motos => Set<Moto>();
        public DbSet<Usuario> Usuarios => Set<Usuario>();
        public DbSet<Patio> Patios => Set<Patio>();
        public DbSet<Setor> Setores => Set<Setor>();
        public DbSet<LocalizacaoMoto> Localizacoes => Set<LocalizacaoMoto>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SmartParkerDbContext).Assembly);
        }
    }
}