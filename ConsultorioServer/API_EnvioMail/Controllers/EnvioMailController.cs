using API_EnvioMail.Factory;
using API_ObrasSociales.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace API_EnvioMail.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnvioMailController : ControllerBase
    {
        private readonly IMailFactory _envioMail;

        public EnvioMailController(IMailFactory envioMail)
        {
            _envioMail = envioMail;
        }

        [HttpPost]
        public IActionResult Post(DTOTurno turnoNuevo)
        {
            try
            {
                _envioMail.EnvioMail(turnoNuevo);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
