using adsProyecto.Models;
namespace adsProyecto.Interfaces
{
    public interface IEstudiante
    {
        public int AgregarEstudiante(Estudiante estudiante);
        public int ModificarEstudiante(int idEstudiante, Estudiante estudiante);
        public bool EliminarEstudiante(int idEstudiante);
        public List<Estudiante> ConsultarEstudiantes();
        public Estudiante ConsultarEstudiantePorID(int idEstudiante);
    }
}
