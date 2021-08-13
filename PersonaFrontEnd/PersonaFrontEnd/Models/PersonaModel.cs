using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PersonaFrontEnd.Models
{
    public class PersonaModel
    {
        public int IdPersona { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "La longitud maxima es de 100")]
        public string Nombres { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "La longitud maxima es de 100")]
        public string Apellidos { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "La longitud maxima es de 30")]
        public string Dpi { get; set; }

        [Required]
        [StringLength(1000, ErrorMessage = "La longitud maxima es de 1000")]
        public string Direccion { get; set; }

        [Required]
        public string Genero { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaNacimiento { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "La longitud maxima es de 50")]
        public string Escolaridad { get; set; }

        [Required]
        public bool Activo { get; set; }
    }
}