using adsProyecto.DB;
using adsProyecto.Interfaces;
using adsProyecto.Models;

namespace adsProyecto.Repositorios
{
    public class profesorRepositorio : IProfesor
    {
        /*private List<Profesor> lstProfesores = new List<Profesor>
        {
            new Profesor { IdProfesor = 1,
                Nombre = "Juan",
                Apellido = "Perez",
                Correo = "hola@gmail"}
        };*/
        private readonly ApplicationDbContext applicationDbContext;
        public profesorRepositorio(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        public int AgregarProfesor(Profesor profesor)
        {
            try
            {
                /*if (lstProfesores.Count > 0)
                {
                    profesor.IdProfesor = lstProfesores.Last().IdProfesor + 1;
                }
                lstProfesores.Add(profesor);*/
                applicationDbContext.Profesor.Add(profesor);
                applicationDbContext.SaveChanges();
                return profesor.IdProfesor;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Profesor> ConsultarProfesores()
        {
            try
            {
                //return lstProfesores;
                return applicationDbContext.Profesor.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Profesor ConsultarProfesorPorID(int idProfesor)
        {
            try
            {
                //Profesor profesor = lstProfesores.Find(temp => temp.IdProfesor == idProfesor);
                var profesor = applicationDbContext.Profesor.SingleOrDefault(x => x.IdProfesor == idProfesor);
                return profesor;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool EliminarProfesor(int idProfesor)
        {
            try
            {
                /*int index = lstProfesores.FindIndex(temp => temp.IdProfesor == idProfesor);
                lstProfesores.RemoveAt(index);*/
                var item = applicationDbContext.Profesor.SingleOrDefault(x => x.IdProfesor == idProfesor);
                applicationDbContext.Profesor.Remove(item);
                applicationDbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int ModificarProfesor(int idProfesor, Profesor profesor)
        {
            try
            {
                /*int index = lstProfesores.FindIndex(temp => temp.IdProfesor == idProfesor);
                if (index != -1)
                {
                    lstProfesores[index] = profesor;
                    lstProfesores[index].IdProfesor = idProfesor;
                    return idProfesor;
                }
                else
                {
                    return 0;
                }*/
                var item = applicationDbContext.Profesor.SingleOrDefault(x => x.IdProfesor == idProfesor);
                applicationDbContext.Entry(item).CurrentValues.SetValues(profesor);
                applicationDbContext.SaveChanges();
                return idProfesor;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}