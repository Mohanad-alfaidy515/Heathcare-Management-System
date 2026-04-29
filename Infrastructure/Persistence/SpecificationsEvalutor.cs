using Domain.Contract;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    static class SpecificationsEvalutor
    {
        //Generate Query
       public static IQueryable<TEntity> GetQuery<TEntity,TKey>(IQueryable<TEntity>inputQuery,ISpecifications<TEntity,TKey>spec)
            where TEntity : BaseEntity<TKey>
       {
            var query = inputQuery;
           if(spec.Cirteria is not null)
            
              query = query.Where(spec.Cirteria);
           if(spec.AddOrderBy is not null)
                query=query.OrderBy(spec.AddOrderBy);
           else if(spec.AddOrderByDecsinding is not null)
                query=query.OrderByDescending(spec.AddOrderByDecsinding);
            if (spec.IsPagination)
                query = query.Skip(spec.Skip).Take(spec.Take);


                query = spec.IncludeExpressions.Aggregate(query, (currentquery, includeExpression) => currentquery.Include(includeExpression));
            
            return query;
       }
    }
}
