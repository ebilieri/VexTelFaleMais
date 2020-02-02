using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VexTel.Domain.Entities;

namespace VexTel.Repository.Config
{
    public class PlanoConfiguration : IEntityTypeConfiguration<Plano>
    {
        public void Configure(EntityTypeBuilder<Plano> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Descricao).IsRequired().HasMaxLength(30);
            builder.Property(x => x.TempoMinutos).IsRequired();            
        }
    }
}
