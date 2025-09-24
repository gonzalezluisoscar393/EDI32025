using Biblioteca.Services;
using Biblioteca.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibrosController : ControllerBase
    {
        private static readonly List<Libro> libros = new List<Libro>
        {
            new Libro{Id = 1, Nombre = "Troya", Pages = 100},
            new Libro{Id = 2, Nombre = ".Net Core", Pages = 250},
            new Libro{Id = 3, Nombre = "SQL Server", Pages = 350},
        };
        private readonly ILogger<LibrosController> _logger;
        private readonly IStringServices _stringServices;

        public LibrosController(ILogger<LibrosController> logger, IStringServices stringServices)
        {
            _logger = logger;
            _stringServices = stringServices;
        }

        [HttpGet]
        [Route("All")]
        public async Task<IActionResult> All()
        {
            return Ok(libros);
        }

        [HttpGet]
        [Route("ById")]
        public async Task<IActionResult> ById(int? Id)
        {
            Libro libro = libros.FirstOrDefault(l => l.Id == Id);
            if (libro is null)
            {
                return NotFound();
            }
            return Ok(libro);
        }

        [HttpPost]
        public async Task<IActionResult> Crear(Libro libro)
        {
            libro.Id = 4;
            libros.Add(libro);
            //return Created();
            return Ok(libros);
        }

        [HttpPut]
        public async Task<IActionResult> Editar(int? Id, string nombre, int pages)
        {
            Libro libro = libros.FirstOrDefault(l => l.Id == Id);
            if (libro is null)
            {
                return NotFound();
            }
            libro.Nombre = nombre;
            libro.Pages = pages;
            return Ok(libro);
        }

        [HttpDelete]
        public async Task<IActionResult> Borrar(int? Id)
        {
            Libro libro = libros.FirstOrDefault(l => l.Id == Id);
            if (libro is null)
            {
                return NotFound();
            }
            libros.Remove(libro);
            return Ok();
        }
    }
}
