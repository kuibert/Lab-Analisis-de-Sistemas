using adsProyecto.Models;

namespace adsProyecto.Interfaces
{
    public interface IProfesor
    {
        public int AgregarProfesor(Profesor profesor);
        public int ModificarProfesor(int idProfesor, Profesor profesor);
        public bool EliminarProfesor(int idProfesor);
        public List<Profesor> ConsultarProfesores();
        public Profesor ConsultarProfesorPorID(int idProfesor);
    }
}
