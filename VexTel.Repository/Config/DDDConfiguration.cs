using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VexTel.Domain.Entities;

namespace VexTel.Repository.Config
{
    public class DDDConfiguration : IEntityTypeConfiguration<DDD>
    {
        public void Configure(EntityTypeBuilder<DDD> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Codigo).IsRequired().HasMaxLength(3);

            //builder.HasMany(x => x.CustoChamadasOrigem)
            //    .WithOne(org => org.DDDOrigem);

            //builder.HasMany(x => x.CustoChamadasDestino)
            //    .WithOne(des => des.DDDDestino);
        }
    }
}
