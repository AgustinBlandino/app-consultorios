using API_ObrasSociales.Models;
using Microsoft.EntityFrameworkCore;

namespace API_ObrasSociales.Factory
{
    public interface IObrasSocialesFactory
    {
        IEnumerable<ObraSocial> ListObrasSociales();
    }
    public class ObrasSocialesFactory : IObrasSocialesFactory
    {
        private readonly Contexto _contexto;
        public ObrasSocialesFactory(Contexto contexto)
        {
            _contexto = contexto;
        }
        public IEnumerable<ObraSocial> ListObrasSociales()
        {
            List<ObraSocial> obrasSociales = _contexto.ObrasSociales.AsNoTracking().ToList();
            return obrasSociales;
            
        }
    }
}
