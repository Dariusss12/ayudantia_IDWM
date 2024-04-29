using ayudantia_IDWM.Src.DTOs;
using ayudantia_IDWM.Src.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using proy_ayudantía.Src.Models;
using proy_ayudantía.Src.Repositories.Interfaces;

namespace proy_ayudantía.Src.Controllers
{
    [ApiController]
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> GetAllUsers()
        {
            var result = _userService.GetUsers().Result;
            return Ok(result);
        }

        [HttpPut("{id}")]
        public ActionResult<string> EditUser(int id, [FromBody] EditUserDto editUser)
        {
            var result = _userService.EditUser(id, editUser).Result;
            if(!result){
                return NotFound("El usuario no existe en el sistema.");
            }
            return Ok("El usuario se editó correctamente");
        }

        [HttpDelete("{id}")]
        public ActionResult<string> DeleteUser(int id)
        {
            var result = _userService.DeleteUser(id).Result;
            if(!result){
                return NotFound("El usuario no existe en el sistema.");
            }
            return Ok("El usuario se eliminó correctamente");
        }
    }
}