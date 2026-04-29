using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contract
{
    public interface ISpecifications<TEntity,TKey> where TEntity : BaseEntity<TKey>
    {
        //convert from static query to dynmic query
        Expression<Func<TEntity, bool>>? Cirteria { set; get; }
        List<Expression<Func<TEntity, object>>> IncludeExpressions { set; get; }
        Expression<Func<TEntity, object>> AddOrderBy {  set; get; }
        Expression<Func<TEntity, object>> AddOrderByDecsinding {  set; get; }
        int Take {  set; get; }
        int Skip {  set; get; }
        bool IsPagination {  set; get; }
    }
}
