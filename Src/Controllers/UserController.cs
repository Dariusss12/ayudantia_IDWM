using Microsoft.AspNetCore.Mvc;
using proy_ayudantía.Src.Models;
using proy_ayudantía.Src.Repositories.Interfaces;

namespace proy_ayudantía.Src.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _service;

        public UserController(IUserRepository service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> GetAllUsers()
        {
            var result = _service.GetUsers().Result;
            return Ok(result);
        }
    }
}