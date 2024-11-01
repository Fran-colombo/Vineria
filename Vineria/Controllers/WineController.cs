using Common.Models;
using Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Implementations;
using Services.Interfaces;

namespace Vineria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class WineController : ControllerBase
    {



        private readonly IWineService _wineServices;

        public WineController(IWineService wineServices)
        {
            _wineServices = wineServices;
        }


        [HttpGet]
        public IActionResult GetWines([FromQuery] bool includeDeleted = false)
        {
            if (includeDeleted == true)
            {
                return Ok(_wineServices.GetAllWines());
            }
            else
            {
                return Ok(_wineServices.GetStockedWines());
            }
        }


        [HttpGet("{variety}")]
        public IActionResult GetByVariety([FromRoute] string variety)
        {
            return Ok(_wineServices.GetWineByVarirety(variety));

        }


        [HttpPost]
        public IActionResult Add([FromBody] WineForCreationDto wineDto)
        {

            _wineServices.AddWine(wineDto);
            return Ok("The wine has been created");

        }


        [HttpPut("{idWine}")]
        public IActionResult UpdateWineById([FromRoute] int idWine,  int stock)
        {
            int? wine = _wineServices.GetWineById(idWine)?.Id;
            if (wine.HasValue)
            {

                _wineServices.UpdateWineById(idWine, stock);
                return Ok(wine);
            }
            else
            {
                return NotFound("We couldn´t find the wine you are looking for, try with another Id. ");
            }
        }
    }
}
