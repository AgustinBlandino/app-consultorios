using Microsoft.AspNetCore.Mvc;
using API_ObrasSociales.Factory;
using API_ObrasSociales.Models;

namespace API_ObrasSociales.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IObrasSocialesFactory _obras;

        public WeatherForecastController(IObrasSocialesFactory obras)
        {
            _obras = obras;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ObraSocial>> Get()
        {
            var obrasSociales = _obras.ListObrasSociales();

            if (obrasSociales == null || !obrasSociales.Any())
            {
                return NotFound(); // Puedes devolver NotFound si la colección está vacía o nula.
            }

            return Ok(obrasSociales); // Devuelve un ActionResult con el código de estado 200 (OK).
        }

    }
}