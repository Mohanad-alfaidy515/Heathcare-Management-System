using Domain.Contract;
using Domain.Models;
using Persistence.Data;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private readonly Dictionary<string, object> _repositories;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            _repositories = new Dictionary<string, object>();
        }
        public IGenericRepository<TEntity, Tkey> GetRepository<TEntity, Tkey>() where TEntity : BaseEntity<Tkey>
        {
            var type= typeof(TEntity).Name;//as string
          if(!_repositories.ContainsKey(type))
          {
                var repository = new GenericRepository<TEntity, Tkey>(_context);
                _repositories.Add(type, repository);
          }
          return (IGenericRepository<TEntity, Tkey>) _repositories[type] ;//casting
        }

        public async Task<int> SaveChangesAsync()
        {
           return await _context.SaveChangesAsync();    
        }
    }
}
