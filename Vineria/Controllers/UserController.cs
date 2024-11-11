using Common.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace Vineria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class UserController : ControllerBase {
       
            private readonly IUserService _userService;


            public UserController(IUserService userServices)
            {

                _userService = userServices;
            }
            [HttpPost]
            public IActionResult Add([FromBody] UserForCreationDto userDto)
            {

                _userService.AddUser(userDto);
                return Ok("The user has been created");

            }
        }
}
