using Common.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace Vineria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TastingController : Controller
    {
        private readonly ITastingService _service;
        public TastingController(ITastingService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get() {
            return Ok(_service.GetTastings());
        }

        [HttpPost]

        public IActionResult AddTasting([FromBody] TastingToCreateDto dto)
        {
            _service.AddTasting(dto);
            return Ok("The tasting has been created succesfully");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateGuestList([FromRoute] int id, [FromBody] List<string> guest)
        {
            _service.UpdateGuestsList(id, guest);
            return Ok("The Guests list has been updated succesfully");

        }

    }
}
