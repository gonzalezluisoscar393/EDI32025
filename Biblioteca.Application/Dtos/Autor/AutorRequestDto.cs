using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Application.Dtos.Autor
{
    public class AutorRequestDto
    {
        public int Id { get; set; }
        [StringLength(30)]
        public string Nombre { get; set; }
        [StringLength(30)]
        public string Apellido { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }
    }
}
