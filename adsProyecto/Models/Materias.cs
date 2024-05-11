using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace adsProyecto.Models
{
    [PrimaryKey(nameof(IdMateria))]

    public class Materias
    {
        public int IdMateria { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio")]
        [MaxLength(50, ErrorMessage = "El campo no puede tener mas de 50 caracteres")]
        public string nombreMateria{ get; set; }
    }
}
