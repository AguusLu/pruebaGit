using System.ComponentModel.DataAnnotations;

namespace pruebaGit.Models
{
        public class Libro
        {
            public int id { get; set; }

            [Required]
            public required string titulo { get; set; }

            [Required]
            [Range(1800, 2100)]
            public int anioPublicacion { get; set; }

            public required Autor autor { get; set; }

            public int autorId { get; set; }

            public required string urlImagen { get; set; }

    }
}
