using Microsoft.AspNetCore.Mvc;

namespace EfTestApi.V1.Controllers
{
    [Route("api/v1/")]
    [ApiController]
    [ApiVersion("1.0")]
    public class HelloController : BaseController
    {
        [Route("hello")]
        [HttpGet]
        public IActionResult GetHello()
        {
            return Ok("Hello");
        }
    }
}
