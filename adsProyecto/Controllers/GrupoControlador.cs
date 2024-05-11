using adsProyecto.Interfaces;
using adsProyecto.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace adsProyecto.Controllers
{
    [Route("api/grupos/")]
    public class GrupoControlador : ControllerBase
    {
        private readonly IGrupo grupo;
        private const string COD_EXITO = "000000";
        private const string COD_ERROR = "999999";
        private string pCOdRespuesta;
        private string pMsjUsuario;
        private string pMsjTecnico;

        public GrupoControlador(IGrupo grupo)
        {
            this.grupo = grupo;
        }
        [HttpPost("agregarGrupo")]
        public ActionResult<string> AgregarGrupo([FromBody] Grupo grupo)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);

                }
                int contador = this.grupo.AgregarGrupo(grupo);
                if(contador > 0)
                {
                    pCOdRespuesta = COD_EXITO;
                    pMsjUsuario = "Grupo agregado correctamente";
                    pMsjTecnico = pCOdRespuesta + "II" + pMsjUsuario;
                }
                else
                {
                    pCOdRespuesta = COD_ERROR;
                    pMsjUsuario = "Error al agregar grupo";
                    pMsjTecnico = pCOdRespuesta + "II" + pMsjUsuario;
                }
                return Ok(new {pCOdRespuesta, pMsjUsuario, pMsjTecnico});
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpPut("actualizarGrupo/{idGrupo}")]
        public ActionResult<string> ActualizarGrupo([FromBody] Grupo grupo)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                int contador = this.grupo.ModificarGrupo(grupo.IdGrupo, grupo);
                if(contador > 0)
                {
                    pCOdRespuesta = COD_EXITO;
                    pMsjUsuario = "Grupo actualizado correctamente";
                    pMsjTecnico = pCOdRespuesta + "II" + pMsjUsuario;
                }
                else
                {
                    pCOdRespuesta = COD_ERROR;
                    pMsjUsuario = "Error al actualizar grupo";
                    pMsjTecnico = pCOdRespuesta + "II" + pMsjUsuario;
                }
                return Ok(new {pCOdRespuesta, pMsjUsuario, pMsjTecnico});
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpGet("consultarGrupos")]
        public ActionResult<string> ConsultarGrupos()
        {
            try
            {
               List<Grupo> lstgrupo = this.grupo.ConsultarGrupo();
                return Ok(lstgrupo);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpGet("consultarGrupoPorID/{idGrupo}")]
        public ActionResult<string> ConsultarGrupoPorID(int idGrupo)
        {
            try
            {
                Grupo grupo = this.grupo.ConsultarGrupoPorID(idGrupo);
                if (grupo != null)
                {
                    return Ok(grupo);
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
        [HttpDelete("eliminarGrupo/{idGrupo}")]
        public ActionResult<string> EliminarGrupo(int idGrupo)
        {
            try
            {
                bool resultado = this.grupo.EliminarGrupo(idGrupo);
                if (resultado)
                {
                    pCOdRespuesta = COD_EXITO;
                    pMsjUsuario = "Grupo eliminado correctamente";
                    pMsjTecnico = pCOdRespuesta + "II" + pMsjUsuario;
                }
                else
                {
                    pCOdRespuesta = COD_ERROR;
                    pMsjUsuario = "Error al eliminar grupo";
                    pMsjTecnico = pCOdRespuesta + "II" + pMsjUsuario;
                }
                return Ok(new { pCOdRespuesta, pMsjUsuario, pMsjTecnico });
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
