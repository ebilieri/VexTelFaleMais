using System.Collections.Generic;
using System.Linq;
using VexTel.Domain.Contracts.IRepositories;
using VexTel.Repository.Context;

namespace VexTel.Repository.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly VexTelContext VexTelContext;

        public BaseRepository(VexTelContext vexTelContex)
        {
            VexTelContext = vexTelContex;
        }

        public void Add(TEntity entity)
        {
            VexTelContext.Set<TEntity>().Add(entity);
            VexTelContext.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            VexTelContext.Set<TEntity>().Update(entity);
            VexTelContext.SaveChanges();
        }

        public TEntity GetById(int id)
        {
            return VexTelContext.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return VexTelContext.Set<TEntity>().ToList();
        }

        public void Remove(TEntity entity)
        {
            VexTelContext.Set<TEntity>().Remove(entity);
            VexTelContext.SaveChanges();
        }

        public void Dispose()
        {
            VexTelContext.Dispose();
        }
    }
}
