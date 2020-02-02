using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VexTel.Domain.Entities;

namespace VexTel.Repository.Config
{
    public class CustoChamadaConfiguration : IEntityTypeConfiguration<CustoChamada>
    {
        public void Configure(EntityTypeBuilder<CustoChamada> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.DDDDestinoId).IsRequired();
            builder.Property(x => x.DDDDestinoId).IsRequired();
            builder.Property(x => x.CustoMinuto).IsRequired();            
        }
    }
}
