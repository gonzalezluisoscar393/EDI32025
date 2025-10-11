using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Application.Dtos.Autor
{
    public class AutorResponseDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string FechaNacimiento { get; set; }
    }
}
