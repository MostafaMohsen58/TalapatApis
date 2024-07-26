using AutoMapper;
using Talapat.Core.Entities;
using Talapat.Core.Identity;
using TalapatApis.DTOS;

namespace TalapatApis.Helper
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
                CreateMap<Product,ProductToReturnDTO>()
                .ForMember(d=>d.ProductType,o=>o.MapFrom(s=>s.ProductType.Name))
                .ForMember(d=>d.productBrand,o=>o.MapFrom(s=>s.productBrand.Name))
                .ForMember(d=>d.PictureUrl, o=>o.MapFrom<ProductPictureURLResolver>());

            CreateMap<Address, AddressDTO>().ReverseMap();
            CreateMap<CustomerBasketDTO, CustomerBasket>();
            CreateMap<BasketItemDTO, BasketItem>();
        }
    }
}
