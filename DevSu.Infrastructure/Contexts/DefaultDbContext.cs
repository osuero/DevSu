using DevSu.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace DevSu.Infrastructure.Contexts
{
    public class DefaultDbContext : DbContext
    {
        public DefaultDbContext(DbContextOptions<DefaultDbContext> options) : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Cuenta> Cuentas { get; set; }
        public DbSet<Movimiento> Movimientos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cuenta>()
                .Property(b => b.SaldoInicial)
                .HasPrecision(18, 2);  

            modelBuilder.Entity<Movimiento>()
                .Property(b => b.Saldo)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Movimiento>()
                .Property(b => b.Valor)
                .HasPrecision(18, 2);


            modelBuilder.Entity<Cliente>()
                 .ToTable("Clientes")
                .Property(c => c.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Cuenta>()
                .Property(c => c.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Movimiento>()
                .Property(m => m.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Cuenta>()
                .HasMany(c => c.Movimientos)
                .WithOne(m => m.Cuenta)
                .HasForeignKey(m => m.CuentaId)
                .HasPrincipalKey(c => c.NumeroCuenta);

            modelBuilder.Entity<Cliente>()
                .HasMany(c => c.Cuentas)
                .WithOne(cu => cu.Cliente)
                .HasForeignKey(cu => cu.ClienteId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
