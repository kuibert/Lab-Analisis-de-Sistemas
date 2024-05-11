using adsProyecto.Interfaces;
using adsProyecto.Models;
using Microsoft.AspNetCore.Mvc;

namespace adsProyecto.Controllers
{
    [Route("api/materias/")]
    public class MateriaControlador : ControllerBase
    {
        private readonly IMaterias materia;
        private const string COD_EXITO = "000000";
        private const string COD_ERROR = "999999";
        private string pCOdRespuesta;
        private string pMsjUsuario;
        private string pMsjTecnico;

        public MateriaControlador(IMaterias materia)
        {
            this.materia = materia;
        }
        [HttpPost("agregarMateria")]
        public ActionResult<string> AgregarMateria([FromBody] Materias materia)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                int contador = this.materia.AgregarMateria(materia);
                if(contador > 0)
                {
                    pCOdRespuesta = COD_EXITO;
                    pMsjUsuario = "Materia agregada correctamente";
                    pMsjTecnico = pCOdRespuesta + "II" + pMsjUsuario;
                }
                else
                {
                    pCOdRespuesta = COD_ERROR;
                    pMsjUsuario = "Error al agregar materia";
                    pMsjTecnico = pCOdRespuesta + "II" + pMsjUsuario;
                }
                return Ok(new {pCOdRespuesta, pMsjUsuario, pMsjTecnico});
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpPut("actualizarMateria/{idMateria}")]
        public ActionResult<string> ActualizarMateria([FromBody] Materias materia)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                int contador = this.materia.ModificarMateria(materia.IdMateria, materia);
                if(contador > 0)
                {
                    pCOdRespuesta = COD_EXITO;
                    pMsjUsuario = "Materia actualizada correctamente";
                    pMsjTecnico = pCOdRespuesta + "II" + pMsjUsuario;
                }
                else
                {
                    pCOdRespuesta = COD_ERROR;
                    pMsjUsuario = "Error al actualizar materia";
                    pMsjTecnico = pCOdRespuesta + "II" + pMsjUsuario;
                }
                return Ok(new { pCOdRespuesta, pMsjUsuario, pMsjTecnico });
            } 
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet("consultarMaterias")]
        public ActionResult<string> ConsultarMaterias()
        {
            try
            {
                List<Materias> lstMaterias = this.materia.ConsultarMaterias();
                return Ok(lstMaterias); 
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpGet("consultarMateriaPorID/{idMateria}")]
        public ActionResult<string> ConsultarMateriaPorID(int idMateria)
        {
            try
            {
                Materias materia = this.materia.ConsultarMateriaPorID(idMateria);
                if (materia != null)
                {
                    return Ok(materia);
                }
                else
                {
                    pCOdRespuesta = COD_ERROR;
                    pMsjUsuario = "Error al consultar materia";
                    pMsjTecnico = pCOdRespuesta + "II" + pMsjUsuario;
                    return Ok(new { pCOdRespuesta, pMsjUsuario, pMsjTecnico });
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpDelete("eliminarMateria/{idMateria}")]
        public ActionResult<string> EliminarMateria(int idMateria)
        {
            try
            {
                bool resultado = this.materia.EliminarMateria(idMateria);
                if (resultado)
                {
                    pCOdRespuesta = COD_EXITO;
                    pMsjUsuario = "Materia eliminada correctamente";
                    pMsjTecnico = pCOdRespuesta + "II" + pMsjUsuario;
                }
                else
                {
                    pCOdRespuesta = COD_ERROR;
                    pMsjUsuario = "Error al eliminar materia";
                    pMsjTecnico = pCOdRespuesta + "II" + pMsjUsuario;
                }
                return Ok(new { pCOdRespuesta, pMsjUsuario, pMsjTecnico });
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
