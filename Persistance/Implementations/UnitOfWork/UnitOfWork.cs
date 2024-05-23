using Application.Abstractions.IRepositories;
using Application.Abstractions.IUnitOfWorks;
using Domain.Entities.Common;
using Persistance.Implementations.Repositories;

namespace Persistance.Implementations.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private Dictionary<Type, object> _repositorios;
        public UnitOfWork(AppDbContext context)
        {
            _context = context;

            _repositorios = new Dictionary<Type, object>();

        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity
        {
            if (_repositorios.ContainsKey(typeof(TEntity)))
            {
                return (IGenericRepository<TEntity>)_repositorios[typeof(TEntity)];
            }
            IGenericRepository<TEntity> repository = new GenericRepository<TEntity>(_context);
            _repositorios.Add(typeof(TEntity), repository);
            return repository;
        }
    }
}
