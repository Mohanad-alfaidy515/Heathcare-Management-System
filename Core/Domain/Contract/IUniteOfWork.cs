using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contract
{
    public interface IUniteOfWork
    {
        //unite of work to Generate Repoistory to deal with rables
        Task<int> SaveChangesAsync();
        //Generate Repoistory
        IGenericRepoistory<TEntity, Tkey> GetRepoistory<TEntity, Tkey>() where TEntity : BaseEntity<Tkey>;
    }
}
