using Microsoft.AspNetCore.Mvc;

namespace Learning.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet,Route("GetAll")]
        public IActionResult GetAll()
        {
            return Ok("This Is Get All Ok");
        }
    }
}
