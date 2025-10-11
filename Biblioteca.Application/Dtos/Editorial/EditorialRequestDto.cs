using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Application.Dtos.Editorial
{
    public class EditorialRequestDto
    {
        public int Id { get; set; }
        [StringLength(30)]
        public string Nombre { get; set; }
    }
}
