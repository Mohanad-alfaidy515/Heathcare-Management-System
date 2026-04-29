using Domain.Contract;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.Specifications
{
    public class BaseSpecification<TEntity, TKey> : ISpecifications<TEntity, TKey>
        where TEntity : BaseEntity<TKey>
    {
        //p=>p.id==id as int?====where  offical shape

        public Expression<Func<TEntity, bool>>? Cirteria { get ; set; }


        //p=>p.categ//////no shape 
        public List<Expression<Func<TEntity, object>>> IncludeExpressions { get; set; } = new List<Expression<Func<TEntity, object>>>();
        public Expression<Func<TEntity, object>> AddOrderBy { get; set ; }
        public Expression<Func<TEntity, object>> AddOrderByDecsinding { get ; set ; }
        public int Take { get; set ; }
        public int Skip { get ; set; }
        public bool IsPagination { get; set ; }

        //  public Expression<Func<TEntity, object>> Appointment {  get; set ; }

        public BaseSpecification(Expression<Func<TEntity, bool>>? expression)
        {
           Cirteria= expression;       
        }

        protected void AddInclude(Expression<Func<TEntity, object>> expression)
        {
            IncludeExpressions.Add(expression); 
        }
        protected void AddOrderByy(Expression<Func<TEntity, object>> expression)
        {
            AddOrderBy= expression;
        }
        protected void AddOrderByyDecsinding(Expression<Func<TEntity, object>> expression)
        {
            AddOrderByDecsinding= expression;
        }
        protected void ApplyPagination(int pageIndex,int pageSize)
        {
            IsPagination = true;
            Take= pageSize;
            Skip=(pageIndex-1)*pageSize;

        }
      
    }
}

