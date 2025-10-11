using AutoMapper;
using Biblioteca.Application.Dtos.Autor;
using Biblioteca.Entities;

namespace Biblioteca.WebApi.Mapping
{
    public class AutorMappingProfile: Profile
    {
        public AutorMappingProfile()
        {
            CreateMap<Autor, AutorResponseDto>().
                ForMember(dest => dest.FechaNacimiento, ori => ori.MapFrom(src => src.FechaNacimiento.ToShortDateString()));
            CreateMap<AutorRequestDto, Autor>();
        }
    }
}
