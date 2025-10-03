using Biblioteca.Abstactions;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteca.Entities
{
    public class AutorPorLibro : IEntidad
    {
        public int Id { get; set; }
        [ForeignKey(nameof(Autor))]
        public int IdAutor { get; set; }
        [ForeignKey(nameof(Libro))]
        public int IdLibro { get; set; }
        public virtual Autor Autor { get; set; }
        public virtual Libro Libro { get; set; }
    }
}
