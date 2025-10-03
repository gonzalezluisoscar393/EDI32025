using Biblioteca.Abstactions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteca.Entities
{
    public class Libro : IEntidad
    {
        public Libro()
        {
            AutoresPorLibros = new HashSet<AutorPorLibro>();
            GenerosPorLibros = new HashSet<GeneroPorLibro>();
        }
        public int Id { get; set; }
        [StringLength(10)]
        public string Nombre { get; set; }
        public int Pages { get; set; }
        public DateTime FechaPublicación { get; set; }
        [ForeignKey(nameof(Editorial))]
        public int IdEditorial { get; set; }
        public virtual Editorial Editorial { get; set; }
        public virtual ICollection<AutorPorLibro> AutoresPorLibros { get; set; }
        public virtual ICollection<GeneroPorLibro> GenerosPorLibros { get; set; }
    }
}
