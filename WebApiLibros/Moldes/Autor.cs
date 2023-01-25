using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApiLibros.Validations;
namespace WebApiLibros.Moldes
{
    [Table("Autor")]
    public class Autor
    {
        [Key]
        public int IdAutor { get; set; }
        [Required(ErrorMessage = "El Nombre es campo obligatorio")]

        [Column(TypeName = "varchar(50)")]
        [PrimeraLetraMayusculaAtributte]
        public string Nombre { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Apellido { get; set; }

        [Range(18, 110, ErrorMessage = "Solo se acepta edades entre 18 y 110")]
        public int? Edad { get; set; }

        public List<Libro> Libros { get; set; }

        [Column(TypeName = "date")]
        public DateTime FechaDeNacimiento { get; set; }

    }

}
