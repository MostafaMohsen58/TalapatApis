using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talapat.Core.Entities;
using Talapat.Core.specifications;

namespace Talapat.Core.Repositories
{
    public interface IgenericRepository<T> where T : BaseEntity
    {
        #region without specification
        Task<IReadOnlyList<T>> GetAllAsync();

        Task<T> GetByIdAsync(int id);
        #endregion

        #region WithSpec
        Task<IReadOnlyList<T>> GetAllWithSpecAsync(Ispecifications<T> spec);
        Task<T> GetByIdWithSpecAsync(Ispecifications<T> spec); 

        Task<int> GetCountWithSpecAsync (Ispecifications<T> spec);
        Task Add(T item);
        #endregion

    }
}
