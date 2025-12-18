using AutoMapper;
using Storage.BLL.DTO.Reponses;
using Storage.DAL.Models;

namespace Storage.BLL.Mappings;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<SystemUser, UserResponse>();
    }
}