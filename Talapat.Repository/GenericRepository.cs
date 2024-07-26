using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talapat.Core.Entities;
using Talapat.Core.Repositories;
using Talapat.Core.specifications;
using Talapat.Repository.Data;

namespace Talapat.Repository
{
    public class GenericRepository<T> : IgenericRepository<T> where T : BaseEntity 
    {
        private readonly StoreContext _dbContext;

        public GenericRepository( StoreContext dbContext)
        {
            _dbContext = dbContext;
        }
        #region Without Specifications
        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            if (typeof(T) == typeof(Product))
            {
                return (IReadOnlyList<T>)await _dbContext.products.Include(P => P.productBrand).Include(P => P.ProductType).ToListAsync();

            }
            else
                return await _dbContext.Set<T>().ToListAsync();
        }


        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
            // return await _dbContext.products.Where(p=>p.Id==id)..Include(P => P.productBrand).Include(P => P.ProductType)
        }

        #endregion 

        public async Task<IReadOnlyList<T>> GetAllWithSpecAsync(Ispecifications<T> spec)
        {
            
            return await ApplaySpecification(spec).ToListAsync();


        }

        public async Task<T> GetByIdWithSpecAsync(Ispecifications<T> spec)
        {
            return await ApplaySpecification(spec).FirstOrDefaultAsync();
        }

        public async Task<int> GetCountWithSpecAsync(Ispecifications<T> spec)
        {

            return await ApplaySpecification(spec).CountAsync();
        }

        private IQueryable<T> ApplaySpecification (Ispecifications<T> spec)
        {

            return  SpecificationEvaluators<T>.GetQuery(_dbContext.Set<T>(), spec);
        }

        public async Task Add(T item)
        {
           await _dbContext.Set<T>().AddAsync(item);
        }
    }


}
