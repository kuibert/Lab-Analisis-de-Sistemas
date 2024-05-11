using adsProyecto.DB;
using adsProyecto.Interfaces;
using adsProyecto.Models;

namespace adsProyecto.Repositorios
{
    public class grupoRepositorio : IGrupo
    {
        /*private List<Grupo> lstGrupo = new List<Grupo>
        {
            new Grupo { IdGrupo = 1, IdCarrera = 1, IdMateria = 1, IdProfesor = 1, cliclo = "Enero-Junio", anio = "2021" },
        };*/
        private readonly ApplicationDbContext applicationDbContext;
        public grupoRepositorio(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        public int AgregarGrupo(Grupo Grupo)
        {
            try
            {
                /*if (lstGrupo.Count > 0)
                {
                    Grupo.IdGrupo = lstGrupo.Last().IdGrupo + 1;
                }
                lstGrupo.Add(Grupo);*/
                applicationDbContext.Grupo.Add(Grupo);
                applicationDbContext.SaveChanges();
                return Grupo.IdGrupo;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Grupo ConsultarGrupoPorID(int idGrupo)
        {
            try
            {
                /*if (lstGrupo.Count > 0)
                {
                    Grupo Grupo = lstGrupo.Find(temp => temp.IdGrupo == idGrupo);
                    return Grupo;
                }
                else
                {
                    return null;
                }*/
                var Grupo = applicationDbContext.Grupo.SingleOrDefault(x => x.IdGrupo == idGrupo);
                return Grupo;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Grupo> ConsultarGrupo()
        {
            try
            {
                // return lstGrupo;
                return applicationDbContext.Grupo.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool EliminarGrupo(int idGrupo)
        {
            try
            {
                /*int index = lstGrupo.FindIndex(temp => temp.IdGrupo == idGrupo);
                lstGrupo.RemoveAt(index);*/
                var item = applicationDbContext.Grupo.SingleOrDefault(x => x.IdGrupo == idGrupo);
                applicationDbContext.Grupo.Remove(item);
                applicationDbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public int ModificarGrupo(int idGrupo, Grupo Grupo)
        {
            try
            {
                /*int index = lstGrupo.FindIndex(temp => temp.IdGrupo == idGrupo);
                if (index != -1)
                {
                    lstGrupo[index] = Grupo;
                    lstGrupo[index].IdGrupo = idGrupo;
                    return idGrupo;
                }
                else
                {
                    return 0;
                }*/
                var item = applicationDbContext.Grupo.SingleOrDefault(x => x.IdGrupo == idGrupo);
                applicationDbContext.Entry(item).CurrentValues.SetValues(Grupo);
                applicationDbContext.SaveChanges();
                return idGrupo;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}