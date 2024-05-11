using adsProyecto.Models;
using adsProyecto.Interfaces;
using System.Linq.Expressions;
using System.Linq;
using adsProyecto.DB;

namespace adsProyecto.Repositorios
{
    public class estudianteRepositorio : IEstudiante
    {
        /*private List<Estudiante> lstEstudiantes = new List<Estudiante>
        {
            new Estudiante { IdEstudiante = 1, 
                NombreEstudiante = "Juan",
                ApellidoEstudiante = "Perez", 
                CodigoEstudiante = "2019100001", 
                CorreoEstudiante = "jp21i04001@usonsonate.edu.sv"}
        };*/
        private readonly ApplicationDbContext applicationDbContext;
        public estudianteRepositorio(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        public int AgregarEstudiante(Estudiante estudiante)
        {
            try
            {
                /* if(lstEstudiantes.Count > 0)
                 {
                     estudiante.IdEstudiante = lstEstudiantes.Last().IdEstudiante + 1;
                 }
                 lstEstudiantes.Add(estudiante);*/

                applicationDbContext.Estudiantes.Add(estudiante);
                applicationDbContext.SaveChanges();
                return estudiante.IdEstudiante;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Estudiante> ConsultarEstudiantes()
        {
            try
            {
                //return lstEstudiantes;
                return applicationDbContext.Estudiantes.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Estudiante ConsultarEstudiantePorID(int idEstudiante)
        {
            try
            {
                //Estudiante estudiante  = lstEstudiantes.FirstOrDefault(temp => temp.IdEstudiante == idEstudiante);
                var estudiante = applicationDbContext.Estudiantes.SingleOrDefault(x => x.IdEstudiante == idEstudiante);
                return estudiante;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool EliminarEstudiante(int idEstudiante)
        {
            try
            {
                /*int index = lstEstudiantes.FindIndex(temp => temp.IdEstudiante == idEstudiante);
                lstEstudiantes.RemoveAt(index);*/

                var item = applicationDbContext.Estudiantes.SingleOrDefault(x => x.IdEstudiante == idEstudiante);
                applicationDbContext.Estudiantes.Remove(item);
                applicationDbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int ModificarEstudiante(int idEstudiante, Estudiante estudiante)
        {
            try
            {
                /*int index = lstEstudiantes.FindIndex(temp => temp.IdEstudiante == idEstudiante);
                lstEstudiantes[index] = estudiante;
                //esto sirve para el caso de que se quiera modificar el id del estudiante no se modifque y se elimine
                lstEstudiantes[index].IdEstudiante = idEstudiante;*/


                var item = applicationDbContext.Estudiantes.SingleOrDefault(x => x.IdEstudiante == idEstudiante);
                applicationDbContext.Entry(item).CurrentValues.SetValues(estudiante);
                applicationDbContext.SaveChanges();
                return idEstudiante;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}