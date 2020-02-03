using System;
using System.Collections.Generic;
using System.Text;

namespace VexTel.Domain.Contracts.IServices
{
    public interface IBaseService<TEntity> : IDisposable where TEntity : class
    {
        List<string> Erros { get; set; }

        void Add(TEntity entity);

        TEntity GetById(int id);

        IEnumerable<TEntity> GetAll();

        void Update(TEntity entity);

        void Remove(TEntity entity);
    }
}
