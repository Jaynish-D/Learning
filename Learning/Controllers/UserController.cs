using Learning.Models.UserModels;
using Learning.Repository.Uow;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Learning.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IUnitOfWork uow) : ControllerBase
    {
        private readonly IUnitOfWork _uow = uow;

        [HttpGet, Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var list = await _uow.Users.GetAllAsync();

                var useC = new UserCreateModel
                {
                    Id = Guid.NewGuid(),
                    Email = "Jaynish@Test1.com",
                    Password = "Jaynish@Test1",
                    FirstName = "Jaynish",
                    LastName = "Chauhan",
                    RoleId = Guid.Parse("3F026D11-4CF4-4963-BB8F-B9B76A7B3071")
                };

                return Ok(list);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
