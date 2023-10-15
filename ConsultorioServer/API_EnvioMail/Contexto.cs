using Microsoft.EntityFrameworkCore;

namespace API_EnvioMail
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {

        }
   
    }
}
