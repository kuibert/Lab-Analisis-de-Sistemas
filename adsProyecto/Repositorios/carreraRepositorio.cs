using adsProyecto.Models;
using adsProyecto.Interfaces;
using adsProyecto.DB;
namespace adsProyecto.Repositorios
{
    public class carreraRepositorio : ICarrera
    {
        /*private List<Carrera> lstCarreras = new List<Carrera>
        {
            new Carrera { IdCarrera = 1, 
                           NombreCarrera = "Ingenieria en Sistemas Informaticos",
                           CodigoCarrera = "ISI"}
        };*/
        private readonly ApplicationDbContext applicationDbContext;
        public carreraRepositorio(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        public int AgregarCarrera(Carrera carrera)
        {
            try
            {
                /*if(lstCarreras.Count > 0)
                {
                    carrera.IdCarrera = lstCarreras.Last().IdCarrera + 1;
                }
                lstCarreras.Add(carrera);*/
                applicationDbContext.Carrera.Add(carrera);
                applicationDbContext.SaveChanges();
                return carrera.IdCarrera;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Carrera> ConsultarCarreras()
        {
            try
            {
                return applicationDbContext.Carrera.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Carrera ConsultarCarreraPorID(int idCarrera)
        {
            try
            {
                //Carrera carrera = lstCarreras.Find(temp => temp.IdCarrera == idCarrera);
                var carrera = applicationDbContext.Carrera.SingleOrDefault(x => x.IdCarrera == idCarrera);
                return carrera;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool EliminarCarrera(int idCarrera)
        {
            try
            {
                /*int index = lstCarreras.FindIndex(temp => temp.IdCarrera == idCarrera);
                lstCarreras.RemoveAt(index);*/
                var carrera = applicationDbContext.Carrera.SingleOrDefault(x => x.IdCarrera == idCarrera);
                applicationDbContext.Remove(carrera);
                applicationDbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int ModificarCarrera(int idCarrera, Carrera carrera)
        {
            try
            {
                /*int index = lstCarreras.FindIndex(temp => temp.IdCarrera == idCarrera);
                if(index != -1)
                {
                    lstCarreras[index] = carrera;
                    lstCarreras[index].IdCarrera = idCarrera;
                    return idCarrera;
                }
                else
                {
                    return 0;
                }*/
                var item = applicationDbContext.Carrera.SingleOrDefault(x => x.IdCarrera == idCarrera);
                applicationDbContext.Entry(item).CurrentValues.SetValues(carrera);
                applicationDbContext.SaveChanges();
                return idCarrera;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
