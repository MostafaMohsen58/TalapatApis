using AutoMapper;
using Talapat.Core.Entities;
using TalapatApis.DTOS;

namespace TalapatApis.Helper
{
    public class ProductPictureURLResolver : IValueResolver<Product, ProductToReturnDTO, String>
    {
        private readonly IConfiguration _configuration;

        public ProductPictureURLResolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string Resolve(Product source, ProductToReturnDTO destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.PictureUrl))
                return $"{_configuration["ApiBaseURL"]}{source.PictureUrl}";


            return string.Empty;



        }
    }
}
