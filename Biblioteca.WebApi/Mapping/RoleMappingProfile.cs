using AutoMapper;
using Biblioteca.Application.Dtos.Identity.Roles;
using Biblioteca.Entities.MicrosoftIdentity;

namespace Biblioteca.WebApi.Mapping
{
    public class RoleMappingProfile: Profile
    {
        public RoleMappingProfile()
        {
            CreateMap<Role, RoleResponseDto>();
            CreateMap<RoleRequestDto, Role>();
        }
    }
}
