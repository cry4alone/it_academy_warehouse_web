using AutoMapper;
using Storage.BLL.DTO.Reponses;
using Storage.DAL.Models;

namespace Storage.BLL.Mappings;

public class MeltProfile : Profile
{
    public MeltProfile()
    {
        CreateMap<Melt, MeltResponse>()
            .ForCtorParam("MeltStatus", opt => opt.MapFrom(src => src.MeltStatus.Name))
            .ForCtorParam("SpecificationName", opt => opt.MapFrom(src => src.Specification.Name ))
            .ForCtorParam("Brand", opt => opt.MapFrom(src => src.Brand.Name));
    }
}
