using Domain.Contract;
using Domain.Models;
using Persistence.Data;
using Persistence.Repoistories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class UniteOfWork : IUniteOfWork
    {
        private readonly ApplicationDbContext _context;
        private readonly Dictionary<string, object> _repoistories;

        public UniteOfWork(ApplicationDbContext context)
        {
            _context = context;
            _repoistories = new Dictionary<string, object>();   
        }
        public IGenericRepoistory<TEntity, Tkey> GetRepoistory<TEntity, Tkey>() where TEntity : BaseEntity<Tkey>
        {
            var type= typeof(TEntity).Name;//as string
          if(!_repoistories.ContainsKey(type))
          {
                var repoistory = new GenericRepoistory<TEntity, Tkey>(_context);
                _repoistories.Add(type, repoistory);
          }
          return (IGenericRepoistory<TEntity, Tkey>) _repoistories[type] ;//casting
        }

        public async Task<int> SaveChangesAsync()
        {
           return await _context.SaveChangesAsync();    
        }
    }
}
