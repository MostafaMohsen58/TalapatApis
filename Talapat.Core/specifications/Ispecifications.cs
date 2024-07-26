using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Talapat.Core.Entities;

namespace Talapat.Core.specifications
{
    public interface Ispecifications<T> where T:BaseEntity
    {
        // return (IEnumerable<T>) await _dbContext.products.where(p=>p.id==id).Include(P => P.productBrand).Include(P => P.ProductType).ToListAsync();

        // sign for property for where condition   where(p=>p.id==id)

        public Expression<Func<T,bool>>  Critria { get; set; }

        // sign for property for list of includes   Include(P => P.productBrand).Include(P => P.ProductType)
        // need to list contain lambda expression (list of includes)
        public List<Expression <Func<T,object>>> Includes { get; set; }
        // orderBy
        public Expression<Func<T,object>> OrderBy { get; set; }
        // orderby desc
        public Expression<Func<T, object>> OrderByDescending { get; set; }

        // skip
        public int Skip { get; set; }
        // take
        public int Take { get; set; }

        public bool IsPagination { get; set; }


    }
}
