using adsProyecto.Interfaces;
using adsProyecto.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace adsProyecto.Controllers
{
    [Route("api/[controller]")]
    public class EstudianteControlador : ControllerBase
    {
        private readonly IEstudiante estudiante;
        private const string COD_EXITO = "000000";
        private const string COD_ERROR = "000000";
        private string pCOdRespuesta;
        private string pMsjUsuario;
        private string pMsjTecnico;
            
        public EstudianteControlador(IEstudiante estudiante)
        {
            this.estudiante = estudiante;
        }
        [HttpPost("agregarEstudiante")]
        public ActionResult<string> AgregarEstudiante([FromBody] Estudiante estudiante)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                int contador = this.estudiante.AgregarEstudiante(estudiante);
                if(contador > 0)
                {
                    pCOdRespuesta = COD_EXITO;
                    pMsjUsuario = "Estudiante agregado correctamente";
                    pMsjTecnico = pCOdRespuesta + "II" + pMsjUsuario;
                }
                else
                {
                    pCOdRespuesta = COD_ERROR;
                    pMsjUsuario = "Error al agregar estudiante";
                    pMsjTecnico = pCOdRespuesta + "II" + pMsjUsuario;
                }
                return Ok(new {pCOdRespuesta, pMsjUsuario, pMsjTecnico});
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpPut("actualizarEstudiante/{idEstudiante}")]
        public ActionResult<string> ActualizarEstudiante([FromBody] Estudiante estudiante)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                int contador = this.estudiante.ModificarEstudiante(estudiante.IdEstudiante, estudiante);
                if(contador > 0)
                {
                    pCOdRespuesta = COD_EXITO;
                    pMsjUsuario = "Estudiante actualizado correctamente";
                    pMsjTecnico = pCOdRespuesta + "II" + pMsjUsuario;
                }
                else
                {
                    pCOdRespuesta = COD_ERROR;
                    pMsjUsuario = "Error al actualizar estudiante";
                    pMsjTecnico = pCOdRespuesta + "II" + pMsjUsuario;
                }
                return Ok(new {pCOdRespuesta, pMsjUsuario, pMsjTecnico});
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpDelete("eliminarEstudiante/{idEstudiante}")]
        public ActionResult<string> EliminarEstudiante(int idEstudiante)
        {
            try
            {
                bool resultado = this.estudiante.EliminarEstudiante(idEstudiante);
                if(resultado)
                {
                    pCOdRespuesta = COD_EXITO;
                    pMsjUsuario = "Estudiante eliminado correctamente";
                    pMsjTecnico = pCOdRespuesta + "II" + pMsjUsuario;
                }
                else
                {
                    pCOdRespuesta = COD_ERROR;
                    pMsjUsuario = "Error al eliminar estudiante";
                    pMsjTecnico = pCOdRespuesta + "II" + pMsjUsuario;
                }
                return Ok(new {pCOdRespuesta, pMsjUsuario, pMsjTecnico});
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpGet("consultarEstudiantePorID/{idEstudiante}")]
        public ActionResult<Estudiante> ConsultarEstudiantePorID(int idEstudiante)
        {
            try
            {
                Estudiante estudiante = this.estudiante.ConsultarEstudiantePorID(idEstudiante);
                if (estudiante != null)
                {
                    return Ok(estudiante);
                }
                else
                {
                    pCOdRespuesta = COD_ERROR;
                    pMsjUsuario = "Error al consultar estudiante";
                    pMsjTecnico = pCOdRespuesta + "II" + pMsjUsuario;
                    return NotFound(new {pCOdRespuesta, pMsjUsuario, pMsjTecnico});
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpGet("consultarEstudiantes")]
        public ActionResult<List<Estudiante>> ConsultarEstudiantes()
        {
            try
            {
                List<Estudiante> lstEstudiantes = this.estudiante.ConsultarEstudiantes();
                return Ok(lstEstudiantes);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
