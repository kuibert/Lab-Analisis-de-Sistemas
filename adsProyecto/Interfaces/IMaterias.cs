using adsProyecto.Models;

namespace adsProyecto.Interfaces
{
    public interface IMaterias
    {
        public int AgregarMateria(Materias materia);
        public int ModificarMateria(int idMateria, Materias materia);
        public bool EliminarMateria(int idMateria);
        public List<Materias> ConsultarMaterias();
        public Materias ConsultarMateriaPorID(int idMateria);
    }
}
