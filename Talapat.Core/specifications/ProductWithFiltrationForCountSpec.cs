using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talapat.Core.Entities;

namespace Talapat.Core.specifications
{
    public class ProductWithFiltrationForCountSpec:BaseSpecifications<Product>
    {
        public ProductWithFiltrationForCountSpec(ProductSpecParams Params):base(p=>
        (!Params.TypeId.HasValue || p.ProductTypeId==Params.TypeId)
     && ( !Params.BrandId.HasValue || p.ProductBrandId == Params.BrandId))
        {
                
        }

    }
}
