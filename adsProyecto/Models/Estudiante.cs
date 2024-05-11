using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace adsProyecto.Models
{
    [PrimaryKey(nameof(IdEstudiante))]
    public class Estudiante
    {
        public int IdEstudiante { get; set; }
        [Required (ErrorMessage = "El campo es requerido")]
        [MaxLength(50, ErrorMessage = "El campo no puede tener mas de 50 caracteres")]
        public string NombreEstudiante { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        [MaxLength(50, ErrorMessage = "El campo no puede tener mas de 50 caracteres")]
        public string ApellidoEstudiante { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        [MaxLength(50, ErrorMessage = "El campo no puede tener mas de 50 caracteres")]
        [MinLength(12, ErrorMessage = "El campo no pude tener menos de 12 caracteres")]
        public string CodigoEstudiante { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        [MaxLength(254, ErrorMessage = "El campo no puede tener mas de 254 caracteres")]
        [EmailAddress(ErrorMessage = "El campo debe ser un correo valido")]
        public string CorreoEstudiante { get; set; }
    }
}
