using Microsoft.EntityFrameworkCore;
using API_ObrasSociales.Models;

namespace API_ObrasSociales
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {

        }
        public DbSet<ObraSocial> ObrasSociales { get; set; }
        public DbSet<Turno> Turnos{ get; set; }
    }
}
