using Microsoft.EntityFrameworkCore;
using Verifarma_Challenge_Backend.Models;

namespace Verifarma_Challenge_Backend.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Farmacia> Farmacia { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var configuration = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Farmacia>(entity =>
            {
                entity.ToTable("Farmacia");
                entity.Property(e => e.IdFarmacia).HasColumnName("id").UseIdentityColumn();
                entity.Property(e => e.Nombre).HasColumnName("nombre").IsRequired().HasMaxLength(15);
                entity.Property(e => e.Direccion).HasColumnName("direccion").IsRequired().HasMaxLength(15);
                entity.Property(e => e.Latitud).HasColumnName("latitud").IsRequired().HasColumnType("decimal(9, 6)");
                entity.Property(e => e.Longitud).HasColumnName("longitud").IsRequired().HasColumnType("decimal(9, 6)");
            });
        }
    }
}
