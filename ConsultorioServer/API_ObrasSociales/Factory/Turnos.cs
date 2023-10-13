using API_ObrasSociales.Models;
using API_ObrasSociales.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_ObrasSociales.Factory
{
    public interface ITurnosFactory
    {
       IEnumerable<Turno> GetTurno(int dni);
        bool PostTurno(DTOTurno turno);

    }
    public class TurnosFactory : ITurnosFactory
    {
        private readonly Contexto _contexto;
        public TurnosFactory(Contexto contexto)
        {
            _contexto = contexto;
        }
        public Turno ArmarObjetoTurno(DTOTurno turno)
        {
            var nuevoTurno = new Turno
            {
                nombreApellido = turno.nombreApellido,
                dni = turno.dni,
                nroTelefono = turno.nroTelefono,
                fecha = turno.fecha,
                horario = turno.horario,
                email = turno.email,
                obraSocial = turno.obraSocial,
                fechaPedidoTurno = DateTime.Now
            };
            return nuevoTurno;
        }
        public bool PostTurno(DTOTurno turno)
        {
            try
            {
                var nuevoTurno = ArmarObjetoTurno(turno);
                _contexto.Turnos.Add(nuevoTurno);
                _contexto.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                // Manejo de errores, puedes registrar el error o devolver un BadRequest en caso de fallo.
                return false;
            }
        }

        public IEnumerable<Turno> GetTurno(int dni)
        {
            try
            {
                var turnos = _contexto.Turnos
                    .AsNoTracking()
                    .Where(turno => turno.dni == dni)
                    .ToList();

                return turnos;
            }
            catch (Exception ex)
            {
                // Puedes manejar el error aquí y registrar el error si es necesario.
                throw; // Lanzar la excepción original para que sea manejada por un controlador de excepciones.
            }
        }

    }
}
