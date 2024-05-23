using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Abstractions.IRepositories;
using Domain.Entities.Common;

namespace Application.Abstractions.IUnitOfWorks
{
    public interface IUnitOfWork : IDisposable
    {
        public Task<int> SaveAsync();
        public IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity;
    }
}
