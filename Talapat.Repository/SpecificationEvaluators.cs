using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talapat.Core.Entities;
using Talapat.Core.specifications;

namespace Talapat.Repository
{
    public static class SpecificationEvaluators<T> where T : BaseEntity
    {
        // fun to build query daynamic
        // return await _dbContext.products.Where(p=>p.Id==id)..Include(P => P.productBrand).Include(P => P.ProductType)
        public static IQueryable<T> GetQuery(IQueryable<T> inputquery, Ispecifications<T> spec)
        {
            var Query = inputquery;// _dbContext.products
            if(spec.Critria != null)
            {
                Query=Query.Where(spec.Critria);// _dbContext.products + .Where(p=>p.Id==id).

            }


            if(spec.OrderBy is not null)
            {
                Query=Query.OrderBy(spec.OrderBy);
            }
            if (spec.OrderByDescending is not null)
            {
                Query = Query.OrderByDescending(spec.OrderByDescending);
            }

            // Pagination
            if (spec.IsPagination)
            {
                Query = Query.Skip(spec.Skip).Take(spec.Take);
            }

            // Include(P => P.productBrand) +  Include(P => P.ProductType)
            // CurrentQuery= the query at the aggregation
            Query = spec.Includes.Aggregate(Query, (CurrentQuery, IncludeExpression) => CurrentQuery.Include(IncludeExpression));

            return Query;

        }

    }
}
