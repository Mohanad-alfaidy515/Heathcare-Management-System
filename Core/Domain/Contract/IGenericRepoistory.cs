using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contract
{
    public interface IGenericRepoistory<TEntity,TKey> where TEntity :BaseEntity<TKey>
    {
        Task<int> CountASYNC(ISpecifications<TEntity,TKey>SPEC);
        Task<IEnumerable<TEntity>> GetAllAsync(bool trackchange=false);
        Task<IEnumerable<TEntity>> GetAllAsync(ISpecifications<TEntity,TKey>spec,bool trackchange=false);
        Task<TEntity?> GetByIdAsync(TKey id);
        Task<TEntity?> GetByIdAsync(ISpecifications<TEntity,TKey>spec,TKey id);
        Task AddSync(TEntity entity);
        void Delete(int id);
        void Update(int id,TEntity entity);
    }
}
