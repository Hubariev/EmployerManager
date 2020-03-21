using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmployerManager.Repository.Abstractions
{
    public interface IRepository<TEntity, Guid>
    {
        Task<List<TEntity>> GetAllAsync();
        Task Add(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(Guid type);
        Task<TEntity> GetById(Guid type);
    }
}
