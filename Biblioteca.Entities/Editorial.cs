using Biblioteca.Abstactions;
using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Entities
{
    public class Editorial : IEntidad
    {
        public Editorial()
        {
            Libros = new HashSet<Libro>();
        }
        public int Id { get; set; }
        [StringLength(30)]
        public string Nombre { get; set; }
        public virtual ICollection<Libro> Libros { get; set; }
    }
}
