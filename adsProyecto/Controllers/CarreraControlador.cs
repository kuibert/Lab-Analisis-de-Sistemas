using adsProyecto.Interfaces;
using adsProyecto.Models;
using Microsoft.AspNetCore.Mvc;
namespace adsProyecto.Controllers
{
    [Route("api/carreras/")]
    public class CarreraControlador : ControllerBase
    {
        private readonly ICarrera carrera;
        private const string COD_EXITO = "000000";
        private const string COD_ERROR = "999999";
        private string pCOdRespuesta;
        private string pMsjUsuario;
        private string pMsjTecnico;

        public CarreraControlador(ICarrera carrera)
        {
            this.carrera = carrera;
        }
        [HttpPost("agregarCarrera")]
        public ActionResult<string> AgregarCarrera([FromBody] Carrera carrera)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                int contador = this.carrera.AgregarCarrera(carrera);
                if(contador > 0)
                {
                    pCOdRespuesta = COD_EXITO;
                    pMsjUsuario = "Carrera agregada correctamente";
                    pMsjTecnico = pCOdRespuesta + "II" + pMsjUsuario;
                }
                else
                {
                    pCOdRespuesta = COD_ERROR;
                    pMsjUsuario = "Error al agregar carrera";
                    pMsjTecnico = pCOdRespuesta + "II" + pMsjUsuario;
                }
                return Ok(new {pCOdRespuesta, pMsjUsuario, pMsjTecnico});
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpPut("actualizarCarrera/{idCarrera}")]
        public ActionResult<string> ActualizarCarrera([FromBody] Carrera carrera)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                int contador = this.carrera.ModificarCarrera(carrera.IdCarrera, carrera);
                if(contador > 0)
                {
                    pCOdRespuesta = COD_EXITO;
                    pMsjUsuario = "Carrera actualizada correctamente";
                    pMsjTecnico = pCOdRespuesta + "II" + pMsjUsuario;
                }
                else
                {
                    pCOdRespuesta = COD_ERROR;
                    pMsjUsuario = "Error al actualizar carrera";
                    pMsjTecnico = pCOdRespuesta + "II" + pMsjUsuario;
                }
                return Ok(new {pCOdRespuesta, pMsjUsuario, pMsjTecnico});
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpGet("consultarCarreras")]
        public ActionResult<List<Carrera>> ConsultarCarreras()
        {
            try
            {
                List<Carrera> lstCarreras = this.carrera.ConsultarCarreras();
                return Ok(lstCarreras);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpGet("consultarCarreraPorID/{idCarrera}")]
        public ActionResult<Carrera> ConsultarCarreraPorID(int idCarrera)
        {
            try
            {
                Carrera carrera = this.carrera.ConsultarCarreraPorID(idCarrera);
                if (carrera != null)
                {
                    return Ok(carrera);
                }
                else
                {
                    pCOdRespuesta = COD_ERROR;
                    pMsjUsuario = "Carrera no encontrada";
                    pMsjTecnico = pCOdRespuesta + "II" + pMsjUsuario;
                    return NotFound(new {pCOdRespuesta, pMsjUsuario, pMsjTecnico});
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpDelete("eliminarCarrera/{idCarrera}")]
        public ActionResult<string> EliminarCarrera(int idCarrera)
        {
            try
            {
                bool resultado = this.carrera.EliminarCarrera(idCarrera);
                if(resultado)
                {
                    pCOdRespuesta = COD_EXITO;
                    pMsjUsuario = "Carrera eliminada correctamente";
                    pMsjTecnico = pCOdRespuesta + "II" + pMsjUsuario;
                }
                else
                {
                    pCOdRespuesta = COD_ERROR;
                    pMsjUsuario = "Error al eliminar carrera";
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
