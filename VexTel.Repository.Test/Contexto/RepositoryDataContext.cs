using Microsoft.EntityFrameworkCore;
using VexTel.Repository.Context;

namespace VexTel.Repository.Test.Contexto
{
    public class RepositoryDataContext
    {
        public static VexTelContext InstanceContext()
        {
            DbContextOptions<VexTelContext> options;

            var builder = new DbContextOptionsBuilder<VexTelContext>();
            builder.UseInMemoryDatabase("InMemoryEmployeeTest");

            options = builder.Options;

            VexTelContext vexTelDataContex = new VexTelContext(options);

            vexTelDataContex.Database.EnsureDeleted();
            vexTelDataContex.Database.EnsureCreated();

            return vexTelDataContex;
        }
    }
}
