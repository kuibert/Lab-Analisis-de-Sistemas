using adsProyecto.Validaciones;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace adsProyecto.Models
{
    [PrimaryKey(nameof(IdGrupo))]
    public class Grupo
    {
        [CustomRequired(ErrorMessage = "El campo es obligatorio")]
        public int IdGrupo { get; set; }
        [CustomRequired(ErrorMessage = "El campo es obligatorio")]
        public int IdCarrera { get; set; }
        [CustomRequired(ErrorMessage = "El campo es obligatorio")]
        public int IdMateria { get; set; }
        [CustomRequired(ErrorMessage = "El campo es obligatorio")]
        public int IdProfesor { get; set; }
        [CustomRequired(ErrorMessage = "El campo es obligatorio")]
        public string cliclo { get; set; }
        [CustomRequired(ErrorMessage = "El campo es obligatorio")]
        public string anio { get; set; }

    }
}
