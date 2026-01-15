using AutoMapper;
using Storage.BLL.DTO.Requests.RoleRequests;
using Storage.BLL.DTO.Responses;
using Storage.DAL.Models;

namespace Storage.BLL.Mappings;

public class RoleProfile : Profile
{
    public RoleProfile()
    {
        CreateMap<CreateRoleRequest, Role>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.RoleName));
        
        CreateMap<Role, RoleResponse>();
    }
}