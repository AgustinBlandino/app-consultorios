using System.ComponentModel.DataAnnotations;

namespace API_ObrasSociales.Models
{
    public class Turno
    {
        [Key]
        public int idTurno { get; set; }
        public string nombreApellido { get; set; }
        public string email { get; set; }
        public int dni { get; set; }
        public string obraSocial { get; set; }
        public int nroTelefono { get; set; }
        public string fecha { get; set; }
        public string horario { get; set; }
        public DateTime fechaPedidoTurno { get; set; }
        public bool disponibilidadSesionVirtual { get; set; }
    
    }
}
