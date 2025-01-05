using Microsoft.EntityFrameworkCore;
using VerificaDespesas.Models;

namespace VerificaDespesas.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }

    public DbSet<Deputado> Deputados { get; set; }
    public DbSet<Despesa> Despesas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Deputado>().HasKey(d => d.DeputadoId);

        modelBuilder.Entity<Despesa>().HasKey(d => d.DespesaId);

        modelBuilder.Entity<Despesa>()
        .HasOne(d => d.Deputado)
        .WithMany(d => d.Despesas)
        .HasForeignKey(d => d.DeputadoId);
    }
}
