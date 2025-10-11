using AutoMapper;
using Biblioteca.Application.Dtos.Editorial;
using Biblioteca.Entities;

namespace Biblioteca.WebApi.Mapping
{
    public class EditorialMappingProfile: Profile
    {
        public EditorialMappingProfile()
        {
            CreateMap<Editorial, EditorialResponseDto>();
            CreateMap<EditorialRequestDto, Editorial>();
        }
    }
}
