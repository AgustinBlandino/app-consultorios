using Microsoft.AspNetCore.Mvc;
using API_ObrasSociales.Factory;
using API_ObrasSociales.Models;
using API_ObrasSociales.Models.DTO;

namespace API_ObrasSociales.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TurnosController : Controller
    {
        private readonly ITurnosFactory _turnos;

        public TurnosController(ITurnosFactory turnos)
        {
            _turnos = turnos;
        }

        [HttpPost]
        public ActionResult Post(DTOTurno newTurno)
        {
           if(_turnos.PostTurno(newTurno))
            {
                return Ok(newTurno);
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpGet]
        public ActionResult<IEnumerable<Turno>> Get(int dni)
        {
            var turno= _turnos.GetTurno(dni);

            if (turno != null)
            {
                return Ok(turno);
            }
            else
            {
                return BadRequest();
            }
        }

    }
}