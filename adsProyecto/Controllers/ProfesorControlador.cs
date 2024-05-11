using adsProyecto.Interfaces;
using adsProyecto.Models;
using Microsoft.AspNetCore.Mvc;

namespace adsProyecto.Controllers
{
    public class ProfesorControlador : ControllerBase
    {
        private readonly IProfesor profesor;
        private const string COD_EXITO = "000000";
        private const string COD_ERROR = "999999";
        private string pCOdRespuesta;
        private string pMsjUsuario;
        private string pMsjTecnico;

        public ProfesorControlador(IProfesor profesor)
        {
            this.profesor = profesor;
        }
        [HttpPost("agregarProfesor")]
        public ActionResult<string> AgregarProfesor([FromBody] Profesor profesor)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                int contador = this.profesor.AgregarProfesor(profesor);
                if(contador > 0)
                {
                    pCOdRespuesta = COD_EXITO;
                    pMsjUsuario = "Profesor agregado correctamente";
                    pMsjTecnico = pCOdRespuesta + "II" + pMsjUsuario;
                }
                else
                {
                    pCOdRespuesta = COD_ERROR;
                    pMsjUsuario = "Error al agregar profesor";
                    pMsjTecnico = pCOdRespuesta + "II" + pMsjUsuario;
                }
                return Ok(new {pCOdRespuesta, pMsjUsuario, pMsjTecnico});
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpPut("actualizarProfesor/{idProfesor}")]
        public ActionResult<string> ActualizarProfesor([FromBody] Profesor profesor)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                int contador = this.profesor.ModificarProfesor(profesor.IdProfesor, profesor);
                if(contador > 0)
                {
                    pCOdRespuesta = COD_EXITO;
                    pMsjUsuario = "Profesor actualizado correctamente";
                    pMsjTecnico = pCOdRespuesta + "II" + pMsjUsuario;
                }
                else
                {
                    pCOdRespuesta = COD_ERROR;
                    pMsjUsuario = "Error al actualizar profesor";
                    pMsjTecnico = pCOdRespuesta + "II" + pMsjUsuario;
                }
                return Ok(new {pCOdRespuesta, pMsjUsuario, pMsjTecnico});
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpGet("consultarProfesores")]
        public ActionResult<List<Profesor>> ConsultarProfesores()
        {
            try
            {
                List<Profesor> listaProfesores = this.profesor.ConsultarProfesores();
                return Ok(listaProfesores);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpGet("consultarProfesorPorID/{idProfesor}")]
        public ActionResult<Profesor> ConsultarProfesorPorID(int idProfesor)
        {
            try
            {
                Profesor profesor = this.profesor.ConsultarProfesorPorID(idProfesor);
                return Ok(profesor);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpDelete("eliminarProfesor/{idProfesor}")]
        public ActionResult<string> EliminarProfesor(int idProfesor)
        {
            try
            {
                bool resultado = this.profesor.EliminarProfesor(idProfesor);
                if(resultado)
                {
                    pCOdRespuesta = COD_EXITO;
                    pMsjUsuario = "Profesor eliminado correctamente";
                    pMsjTecnico = pCOdRespuesta + "II" + pMsjUsuario;
                }
                else
                {
                    pCOdRespuesta = COD_ERROR;
                    pMsjUsuario = "Error al eliminar profesor";
                    pMsjTecnico = pCOdRespuesta + "II" + pMsjUsuario;
                }
                return Ok(new {pCOdRespuesta, pMsjUsuario, pMsjTecnico});
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
