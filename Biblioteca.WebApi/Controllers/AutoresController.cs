using Biblioteca.Application;
using Biblioteca.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoresController : ControllerBase
    {
        private readonly ILogger<AutoresController> _logger;
        private readonly IApplication<Autor> _autor;
        public AutoresController(ILogger<AutoresController> logger, IApplication<Autor> autor)
        {
            _logger = logger;
            _autor = autor;
        }

        [HttpGet]
        [Route("All")]
        public async Task<IActionResult> All()
        {
            return Ok(_autor.GetAll());
        }

        [HttpGet]
        [Route("ById")]
        public async Task<IActionResult> ById(int? Id)
        {
            if (!Id.HasValue)
            {
                return BadRequest();
            }
            Autor autor = _autor.GetById(Id.Value);
            if (autor is null)
            {
                return NotFound();
            }
            return Ok(autor);
        }

        [HttpPost]
        public async Task<IActionResult> Crear(Autor autor)
        {
            if (!ModelState.IsValid) 
            { return BadRequest(); }
            _autor.Save(autor);
            return Ok(autor.Id);
        }

        [HttpPut]
        public async Task<IActionResult> Editar(int? Id, Autor autor)
        {
            if (!Id.HasValue)
            { return BadRequest(); }
            if (!ModelState.IsValid)
            { return BadRequest(); }
            Autor autorBack = _autor.GetById(Id.Value);
            if (autorBack is null)
            { return NotFound(); }
            autorBack.Nombre = autor.Nombre;
            autorBack.Apellido = autor.Apellido;
            autorBack.Email = autor.Email;
            autorBack.FechaNacimiento = autor.FechaNacimiento;
            _autor.Save(autorBack);
            return Ok(autorBack);
        }

        [HttpDelete]
        public async Task<IActionResult> Borrar(int? Id)
        {
            if (!Id.HasValue)
            { return BadRequest(); }
            if (!ModelState.IsValid)
            { return BadRequest(); }
            Autor autorBack = _autor.GetById(Id.Value);
            if (autorBack is null)
            { return NotFound(); }
            _autor.Delete(autorBack.Id);
            return Ok();
        }
    }
}
