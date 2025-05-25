using Microsoft.EntityFrameworkCore;
using SmartParker.Domain.Entities;

namespace SmartParker.Infrastructure.Data
{
    public class SmartParkerDbContext : DbContext
    {
        public SmartParkerDbContext(DbContextOptions<SmartParkerDbContext> options)
            : base(options)
        {
        }

        public DbSet<Moto> Motos { get; set; }
    }
}