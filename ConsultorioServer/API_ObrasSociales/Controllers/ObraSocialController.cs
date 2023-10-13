using Microsoft.AspNetCore.Mvc;
using API_ObrasSociales.Factory;
using API_ObrasSociales.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Cors;

namespace API_ObrasSociales.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class ObraSocialController : ControllerBase
    {
        private readonly IObrasSocialesFactory _obras;

        public ObraSocialController(IObrasSocialesFactory obras)
        {
            _obras = obras;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ObraSocial>> Get()
        {
            var obrasSociales = _obras.ListObrasSociales();

            if (obrasSociales == null || !obrasSociales.Any())
            {
                return NotFound(); 
            }

            return Ok(obrasSociales); //
        }
    }
}
