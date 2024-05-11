using adsProyecto.Models;
namespace adsProyecto.Interfaces
{
    public interface ICarrera
    {
        public int AgregarCarrera(Carrera carrera);
        public int ModificarCarrera(int idCarrera, Carrera carrera);
        public bool EliminarCarrera(int idCarrera);
        public List<Carrera> ConsultarCarreras();
        public Carrera ConsultarCarreraPorID(int idCarrera);
    }
}
