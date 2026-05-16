using Domain.Contract;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class GenericRepository<TEntity, TKey> : IGenericRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        private readonly ApplicationDbContext _context;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(TEntity entity)
        {
           await _context.Set<TEntity>().AddAsync(entity);
        }

        public async Task<int> CountAsync(ISpecifications<TEntity, TKey> spec)
        {
           return await ApplySpecifications(spec).CountAsync();
        }

        public void Delete(TKey id)
        {
            var entity =  _context.Set<TEntity>().Find(id);
            if (entity is not null)
            {
                _context.Set<TEntity>().Remove(entity);
            }
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(bool trackchange = false)
        {
            if (trackchange)
            {
               return await _context.Set<TEntity>().ToListAsync();
            }
            return await _context.Set<TEntity>().AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(ISpecifications<TEntity, TKey> spec, bool trackchange = false)
        {
            if (trackchange)
            {
                return await ApplySpecifications(spec).ToListAsync();
            }
            return await ApplySpecifications(spec).AsNoTracking().ToListAsync();
        }

        public async Task<TEntity?> GetByIdAsync(TKey id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity?> GetByIdAsync(ISpecifications<TEntity, TKey> spec, TKey id)
        {
           return await ApplySpecifications(spec).FirstOrDefaultAsync(e=>e.Id!.Equals(id));
        }

        public void Update(TKey id, TEntity entity)
        {
           _context.Set<TEntity>().Update(entity);
        }

        private IQueryable<TEntity> ApplySpecifications(ISpecifications<TEntity, TKey> spec)
        {
            return SpecificationsEvalutor.GetQuery(_context.Set<TEntity>(), spec);
        }
    }
}
