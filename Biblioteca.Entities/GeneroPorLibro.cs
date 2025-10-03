using Biblioteca.Abstactions;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteca.Entities
{
    public class GeneroPorLibro : IEntidad
    {
        public int Id { get; set; }
        [ForeignKey(nameof(Genero))]
        public int IdGenero { get; set; }
        [ForeignKey(nameof(Libro))]
        public int IdLibro { get; set; }
        public virtual Genero Genero { get; set; }
        public virtual Libro Libro { get; set; }
    }
}
