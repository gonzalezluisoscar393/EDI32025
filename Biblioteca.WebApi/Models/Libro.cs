using System.ComponentModel.DataAnnotations;

namespace Biblioteca.WebApi.Models
{
    public class Libro
    {
        public int Id { get; set; }
        [StringLength(10)]
        public string Nombre { get; set; }
        public int Pages { get; set; }
    }
}
