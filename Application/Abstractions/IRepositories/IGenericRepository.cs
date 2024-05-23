using Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions.IRepositories
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll();
        public Task<bool> Add(T entity);
        public bool Update(T entity);
        public bool Delete(T entity);
        public Task<bool> DeleteById(int id);
        public Task<T> GetById(int id);
        DbSet<T> Table { get; }
    }
}
