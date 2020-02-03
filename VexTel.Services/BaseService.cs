using System.Collections.Generic;
using VexTel.Domain.Contracts.IRepositories;
using VexTel.Domain.Contracts.IServices;

namespace VexTel.Services
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class
    {
        private readonly IBaseRepository<TEntity> _baseRepository;

        public BaseService(IBaseRepository<TEntity> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public List<string> Erros { get; set; }

        public void Add(TEntity entity)
        {
            _baseRepository.Add(entity);
        }

        public void Dispose()
        {
            _baseRepository.Dispose();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _baseRepository.GetAll();
        }

        public TEntity GetById(int id)
        {
            return _baseRepository.GetById(id);
        }

        public void Remove(TEntity entity)
        {
            _baseRepository.Remove(entity);
        }

        public void Update(TEntity entity)
        {
            _baseRepository.Update(entity);
        }
    }
}
