using adsProyecto.Models;
namespace adsProyecto.Interfaces
{
    public interface IGrupo
    {
        public int AgregarGrupo(Grupo grupo);
        public int ModificarGrupo(int id, Grupo grupo);
        public bool EliminarGrupo(int idGrupo);
        public List<Grupo> ConsultarGrupo();
        public Grupo ConsultarGrupoPorID(int id);
    }
}
