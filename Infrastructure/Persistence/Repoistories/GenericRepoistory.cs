using Domain.Contract;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repoistories
{
    public class GenericRepoistory<TEntity, TKey> : IGenericRepoistory<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        private readonly ApplicationDbContext _context;

        public GenericRepoistory(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<TEntity>> GetAllAsync(bool trackchange = false)
        {
            if(typeof(TEntity)==typeof(Doctor))//static query
            {
                return trackchange ?
                 await _context.Doctors.Include(p=>p.Specialization).ToListAsync() as IEnumerable<TEntity>
               : await _context.Doctors.Include(p=>p.Specialization).AsNoTracking().ToListAsync() as IEnumerable<TEntity>;
            }
           return trackchange?
                  await _context.Set<TEntity>().ToListAsync()
                : await _context.Set<TEntity>().AsNoTracking().ToListAsync();  

        }

        public async Task<TEntity?> GetByIdAsync(TKey id)
        {
            if (typeof(TEntity) == typeof(Doctor))
            {
                return await _context.Doctors.Where(p=>p.Id==id as int?).Include(p=>p.Specialization).FirstOrDefaultAsync(p=>p.Id ==id as int?) as TEntity;
            }

                return await _context.Set<TEntity>().FindAsync(id);
        }
        public async Task AddSync(TEntity entity)
        {
           await _context.AddAsync(entity);
        }

        public void Update(int id,TEntity entity)
        {
            _context.Update(entity);    
        }
      

        public void Delete(int id)
        {
          var entity=_context.Set<TEntity>().Find(id);
            if(entity!=null) 
                entity.IsDeleted=true;
                _context.Set<TEntity>().Update(entity);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(ISpecifications<TEntity, TKey> spec, bool trackchange = false)
        {
            

             return await ApplaySpecifications(spec).ToListAsync();
        }

        public async Task<TEntity?> GetByIdAsync(ISpecifications<TEntity, TKey> spec, TKey id)
        {
           return await ApplaySpecifications(spec).FirstOrDefaultAsync();
        }
        public async Task<int> CountASYNC(ISpecifications<TEntity, TKey> SPEC)
        {
           return await ApplaySpecifications(SPEC).CountAsync();
        }
        private IQueryable<TEntity>ApplaySpecifications(ISpecifications<TEntity,TKey>spec)
        {
            return SpecificationsEvalutor.GetQuery(_context.Set<TEntity>(), spec);
        }

       
    }
    
}
