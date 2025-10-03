using Biblioteca.Abstactions;

namespace Biblioteca.Entities
{
    public class Genero : IEntidad
    {
        public Genero()
        {
            GenerosPorLibros = new HashSet<GeneroPorLibro>();
        }
        public int Id { get; set; }
        public string Nombre { get; set; }
        public virtual ICollection<GeneroPorLibro> GenerosPorLibros { get; set; }
    }
}
