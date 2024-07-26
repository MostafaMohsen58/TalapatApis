using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Talapat.Core.Entities;
using Talapat.Core.Repositories;
using TalapatApis.DTOS;
using TalapatApis.Errors;

namespace TalapatApis.Controllers
{
    public class BasketComtroller : ApiBaseController
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IMapper _mapper;

        public BasketComtroller(IBasketRepository   basketRepository,IMapper mapper)
        {
            _basketRepository = basketRepository;
            _mapper = mapper;
        }
        // get or create Basket was already found but deleted
        [HttpGet]

        public async Task<ActionResult<CustomerBasket>> GetCustomerBasket(string id)
        {


            var Basket = await _basketRepository.GetBasketAsync(id);
            //    if (basket is null)

            //        return new CustomerBasket(id);
            //    else return basket;
            
            return Basket is null ? new CustomerBasket(id) : Basket;


        }


        // Create for the first time Or Update

        [HttpPost]
        public async Task<ActionResult<CustomerBasket>> UpdateBasket(CustomerBasketDTO basket)
        {
            var mappedbasket=_mapper.Map<CustomerBasketDTO,CustomerBasket>(basket);
             var updatedOrCreatedBasket=await _basketRepository.UpdateBasketAsync(mappedbasket);
            if (updatedOrCreatedBasket is null) return BadRequest(new ApiResponse(400," there is a problem with Ur Basket"));
            return Ok(updatedOrCreatedBasket);

        }

        // Delete Basket
        [HttpDelete]
        public async Task<ActionResult<bool>> DeletedBasket(string id)
        {

            return await _basketRepository.DeleteBasketAsync(id);
        }



    }
}
