using Talapat.Core.Entities;

namespace TalapatApis.DTOS
{
    public class ProductToReturnDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PictureUrl { get; set; }
        public decimal Price { get; set; }
        //  [ForeignKey("productBrand")]
        public int ProductBrandId { get; set; }//REpresentation FK
        public String productBrand { get; set; }
        public int ProductTypeId { get; set; }//REpresentation FK
        public String ProductType { get; set; }
    }
}
