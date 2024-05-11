using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace adsProyecto.Models
{
    [PrimaryKey(nameof(IdCarrera))]
    public class Carrera
    {
        public int IdCarrera { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        [MaxLength(50, ErrorMessage = "El campo no puede tener mas de 50 caracteres")]
        public string NombreCarrera { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        [MaxLength(3, ErrorMessage = "El campo no puede tener mas de 3 caracteres")]
        public string CodigoCarrera { get; set; }
    }
}
