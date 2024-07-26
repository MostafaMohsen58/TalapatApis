using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talapat.Core.Entities
{
    public class Product:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string PictureUrl { get; set; }
        public decimal Price { get; set; }
      //  [ForeignKey("productBrand")]
        public int ProductBrandId { get; set; }//REpresentation FK
        public ProductBrand productBrand { get; set; }
        public int ProductTypeId { get; set; }//REpresentation FK
        public ProductType ProductType { get; set; }



    }
}
