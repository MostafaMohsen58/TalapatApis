using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talapat.Repository.Data;
using TalapatApis.Errors;

namespace TalapatApis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiBuggyController : ApiBaseController
    {
        private readonly StoreContext _dbcontext;

        public ApiBuggyController(StoreContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        [HttpGet("NotFound")]
        public ActionResult GetnotFoundRequest()
        {
            var products = _dbcontext.products.Find(100);
            if (products == null)
                return NotFound(new ApiResponse(404));

            return Ok(products);
        }

        [HttpGet("ServerError")]
        public ActionResult GetServerError()
        {
            var product = _dbcontext.products.Find(100);
            var productToReturn = product.ToString();
            // Null REfrence Exception
            return Ok(productToReturn);

        }
        [HttpGet("BadREquest")]

        public ActionResult GetBadRequest()
        {
            return BadRequest();

        }


        [HttpGet("BadREquest/{id}")]

        public ActionResult GetBadRequest(int id)
        {
            return Ok();


        }
    }
}
