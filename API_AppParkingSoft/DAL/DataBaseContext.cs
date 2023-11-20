using Microsoft.EntityFrameworkCore;

namespace API_AppParkingSoft.DAL
{
    //Contexto de la base de datos del proyecto
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
