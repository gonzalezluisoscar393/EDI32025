using AutoMapper;
using Biblioteca.Application;
using Biblioteca.Application.Dtos.Editorial;
using Biblioteca.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.WebApi.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class EditorialesController : ControllerBase
    {
        private readonly ILogger<EditorialesController> _logger;
        private readonly IApplication<Editorial> _editorial;
        private readonly IMapper _mapper;
        public EditorialesController(
            ILogger<EditorialesController> logger
            , IApplication<Editorial> editorial
            , IMapper mapper)
        {
            _logger = logger;
            _editorial = editorial;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("All")]
        public async Task<IActionResult> All()
        {
            return Ok(_mapper.Map<IList<EditorialResponseDto>>(_editorial.GetAll()));
        }

        [HttpGet]
        [Route("ById")]
        public async Task<IActionResult> ById(int? Id)
        {
            if (!Id.HasValue)
            {
                return BadRequest();
            }
            Editorial editorial = _editorial.GetById(Id.Value);
            if (editorial is null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<EditorialResponseDto>(editorial));
        }

        [HttpPost]
        public async Task<IActionResult> Crear(EditorialRequestDto editorialRequestDto)
        {
            if (!ModelState.IsValid)
            { return BadRequest(); }
            var editorial = _mapper.Map<Editorial>(editorialRequestDto);
            _editorial.Save(editorial);
            return Ok(editorial.Id);
        }

        [HttpPut]
        public async Task<IActionResult> Editar(int? Id, EditorialRequestDto editorialRequestDto)
        {
            if (!Id.HasValue)
            { return BadRequest(); }
            if (!ModelState.IsValid)
            { return BadRequest(); }
            var editorial = _editorial.GetById(Id.Value);
            if (editorial is null)
            { return NotFound(); }
            editorial = _mapper.Map<Editorial>(editorialRequestDto);
            _editorial.Save(editorial);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Borrar(int? Id)
        {
            if (!Id.HasValue)
            { return BadRequest(); }
            if (!ModelState.IsValid)
            { return BadRequest(); }
            var editorial = _editorial.GetById(Id.Value);
            if (editorial is null)
            { return NotFound(); }
            _editorial.Delete(editorial.Id);
            return Ok();
        }
    }
}
