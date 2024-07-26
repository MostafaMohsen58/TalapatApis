using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talapat.Core.Entities;

namespace Talapat.Core.specifications
{
    public class ProductWithBrandAndTypeSpecifications:BaseSpecifications<Product>
    {
        // CTOR is used for Get all product
        public ProductWithBrandAndTypeSpecifications( ProductSpecParams Params) 
            :base(p=>(!Params.TypeId.HasValue || p.ProductTypeId==Params.TypeId)
            && ( !Params.BrandId.HasValue || p.ProductBrandId == Params.BrandId))
                  
        {
            Includes.Add(p => p.ProductType);
            Includes.Add(p => p.productBrand);
            if (!string.IsNullOrEmpty(Params.Sort))
            {
                switch (Params.Sort)
                {
                    case "PriceAsc":
                        AddOrderBy(p => p.Price);
                        break;
                    case "PriceDesc":
                        AddOrderByDesc(p => p.Price);
                        break;
                    default:
                        AddOrderBy(p => p.Name);
                        break;
                }
            }


            // Product=100
            //PageSize=10
            //PageIndex=5
            // => skip 40 take 10

            // Skip = PageSize*Index-1
            ApplayPagination(Params.PageSize * (Params.PageIndex - 1), Params.PageSize);
        }


       

        


        // CTOR is used for Get product By id
        public ProductWithBrandAndTypeSpecifications( int id ):base(p=>p.Id==id)
        {
            Includes.Add(p => p.ProductType);
            Includes.Add(p => p.productBrand);
        }


    }
}
