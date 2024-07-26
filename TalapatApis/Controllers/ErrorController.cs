using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TalapatApis.Errors;

namespace TalapatApis.Controllers
{
    [Route("errors/{code}")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi =true)] // to handel swagger because the method without verb
    public class ErrorController : ControllerBase
    {
        public ActionResult Error   (int code)
        {

            return NotFound(new ApiResponse(code));
        }
    }
}
