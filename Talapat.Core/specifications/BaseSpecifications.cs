using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Talapat.Core.Entities;

namespace Talapat.Core.specifications
{
    public class BaseSpecifications<T> : Ispecifications<T> where T : BaseEntity
    {
        public Expression<Func<T, bool>> Critria { get ; set; }
        public List<Expression<Func<T, object>>> Includes { get ; set; }  = new List<Expression<Func<T, object>>>();
        public Expression<Func<T, object>> OrderBy { get; set; }
        public Expression<Func<T, object>> OrderByDescending { get; set; }
        public int Skip  { get; set; }
        public int Take { get; set; }
        public bool IsPagination { get; set; }


        // Get all 
        public BaseSpecifications()
        {
          //  Includes = new List<Expression<Func<T, object>>>();
        }

        // get by id 

        public BaseSpecifications(Expression<Func<T, bool>> CriteriaExpression)
        {

            Critria = CriteriaExpression;
        }


        public void AddOrderBy(Expression<Func<T, object>> OrderByExpression)
        {

            OrderBy = OrderByExpression;

        }
        public void AddOrderByDesc(Expression<Func<T,object>> OrderByDescExpression)
        {
            OrderByDescending=OrderByDescExpression;

        }

        public void ApplayPagination ( int skip, int take)
        {

            IsPagination=true;
            Skip= skip;
            Take= take;
        }

    }
}
