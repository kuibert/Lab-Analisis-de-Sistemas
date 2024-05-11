using adsProyecto.Models;
using Microsoft.EntityFrameworkCore;

namespace adsProyecto.DB
{
    public class ApplicationDbContext : DbContext
    {
        private IConfiguration configuration;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration configuration) 
            : base(options) {
            this.configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlServer(this.configuration.GetConnectionString("DefaultConnection"));
        }

        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<Carrera> Carrera { get; set; }
        public DbSet<Grupo> Grupo { get; set; }
        public DbSet<Materias> Materias { get; set; }
        public DbSet<Profesor> Profesor { get; set; }
    }
}
