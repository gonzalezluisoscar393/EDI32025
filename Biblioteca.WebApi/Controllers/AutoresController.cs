using AutoMapper;
using Biblioteca.Application;
using Biblioteca.Application.Dtos.Autor;
using Biblioteca.Application.Dtos.Editorial;
using Biblioteca.Entities;
using Biblioteca.Entities.MicrosoftIdentity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Biblioteca.WebApi.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class AutoresController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly ILogger<AutoresController> _logger;
        private readonly IApplication<Autor> _autor;
        private readonly IMapper _mapper;
        public AutoresController(
            ILogger<AutoresController> logger
            , UserManager<User> userManager
            , IApplication<Autor> autor
            , IMapper mapper)
        {
            _logger = logger;
            _autor = autor;
            _mapper = mapper;
            _userManager = userManager;
        }

        [HttpGet]
        [Route("All")]
        public async Task<IActionResult> All()
        {
            var id = User.FindFirst("Id").Value.ToString();
            var user = _userManager.FindByIdAsync(id).Result;
            if (_userManager.IsInRoleAsync(user, "Administrador").Result)
            {
                var name = User.FindFirst("name");
                var a = User.Claims;
                return Ok(_mapper.Map<IList<AutorResponseDto>>(_autor.GetAll()));
            }
            return Unauthorized();
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
            return Ok(_mapper.Map<AutorResponseDto>(autor));
        }

        [HttpPost]
        public async Task<IActionResult> Crear(AutorRequestDto autorRequestDto)
        {
            if (!ModelState.IsValid) 
            { return BadRequest(); }
            var autor = _mapper.Map<Autor>(autorRequestDto);
            _autor.Save(autor);
            return Ok(autor.Id);
        }

        [HttpPut]
        public async Task<IActionResult> Editar(int? Id, AutorRequestDto autorRequestDto)
        {
            if (!Id.HasValue)
            { return BadRequest(); }
            if (!ModelState.IsValid)
            { return BadRequest(); }
            Autor autorBack = _autor.GetById(Id.Value);
            if (autorBack is null)
            { return NotFound(); }
            autorBack = _mapper.Map<Autor>(autorRequestDto);
            _autor.Save(autorBack);
            return Ok();
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
