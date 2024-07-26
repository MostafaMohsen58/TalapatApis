using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talapat.Core.Entities;
using Talapat.Core.Repositories;
using Talapat.Core.specifications;
using TalapatApis.DTOS;
using TalapatApis.Errors;
using TalapatApis.Helper;

namespace TalapatApis.Controllers
{
  
    public class ProductController : ApiBaseController
    {
        private readonly IgenericRepository<Product> _productRebo;
        private readonly IMapper _mapper;
        private readonly IgenericRepository<ProductType> _typerepo;
        private readonly IgenericRepository<ProductBrand> _brandRebo;

        public ProductController(IgenericRepository<Product> ProductRebo
            ,IMapper mapper
            ,IgenericRepository<ProductType> Typerepo
            ,IgenericRepository<ProductBrand> BrandRebo)
        {
            _productRebo = ProductRebo;
            _mapper = mapper;
            _typerepo = Typerepo;
            _brandRebo = BrandRebo;
        }

        // Get All Product
        // BaseURL /api/Product ..Get
        [HttpGet]
       // [Authorize(AuthenticationSchemes =JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<Pagination<ProductToReturnDTO>>> GetAllProduct([FromQuery]ProductSpecParams Params)
        {

            var Spec= new ProductWithBrandAndTypeSpecifications(Params);
            var Products= await _productRebo.GetAllWithSpecAsync(Spec);
            //OkObjectResult result = new OkObjectResult(Products);
            //return result;

            var MappedProducts = _mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDTO>>(Products);

            //var ReturnedObject = new Pagination<ProductToReturnDTO>()
            //{
            //    PageIndex=Params.PageIndex,
            //    PageSize=Params.PageSize,
            //    Data= MappedProducts
            //};
            //return Ok(ReturnedObject);
            var countspec = new ProductWithFiltrationForCountSpec(Params);
            var count =await _productRebo.GetCountWithSpecAsync(countspec);

            return Ok(new Pagination<ProductToReturnDTO>(Params.PageIndex,Params.PageSize, MappedProducts,count));




        }


        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProductToReturnDTO),StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse),StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {

            var Spec= new ProductWithBrandAndTypeSpecifications(id);
            var Product = await _productRebo.GetByIdWithSpecAsync(Spec);
            if(Product == null) return NotFound( new ApiResponse(404));
            var mappedproduct= _mapper.Map<Product, ProductToReturnDTO>(Product);
            return Ok(mappedproduct);
        }


        // BaseURl/api/Product/Types
        [HttpGet("Types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetTypes()
        {
            var types= await _typerepo.GetAllAsync();
            return Ok(types);

        }


        [HttpGet("Brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetBrands()
        {
            var Brands= await _brandRebo.GetAllAsync();
            return Ok(Brands);
        }
    }
}
