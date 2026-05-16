using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contract
{
    public interface IGenericRepository<TEntity,TKey> where TEntity :BaseEntity<TKey>
    {
        Task<int> CountAsync(ISpecifications<TEntity,TKey> spec);
        Task<IEnumerable<TEntity>> GetAllAsync(bool trackchange=false);
        Task<IEnumerable<TEntity>> GetAllAsync(ISpecifications<TEntity,TKey>spec,bool trackchange=false);
        Task<TEntity?> GetByIdAsync(TKey id);
        Task<TEntity?> GetByIdAsync(ISpecifications<TEntity,TKey>spec,TKey id);
        Task AddAsync(TEntity entity);
        void Delete(TKey id);
        void Update(TKey id, TEntity entity);
    }
}
