using Microsoft.EntityFrameworkCore;
using VexTel.Domain.Entities;
using VexTel.Repository.Config;

namespace VexTel.Repository.Context
{
    public class VexTelContext : DbContext
    {
        public DbSet<DDD> DDDs { get; set; }
        public DbSet<Plano> Planos { get; set; }
        public DbSet<CustoChamada> CustoChamadas { get; set; }


        public VexTelContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Mapeamento das entidades
            modelBuilder.ApplyConfiguration(new DDDConfiguration());
            modelBuilder.ApplyConfiguration(new PlanoConfiguration());
            modelBuilder.ApplyConfiguration(new CustoChamadaConfiguration());

            base.OnModelCreating(modelBuilder);
        }

    }
}
