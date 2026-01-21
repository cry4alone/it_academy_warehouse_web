using AutoMapper;
using Storage.BLL.DTO.Reponses;
using Storage.BLL.DTO.Requests.MeltRequests;
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
        
        CreateMap<UpdateMeltRequest, Melt>()
            .ForMember(dest => dest.ProductId, opt => opt.Condition(src => src.ProductId.HasValue))
            .ForMember(dest => dest.BrandId, opt => opt.Condition(src => src.BrandId.HasValue))
            .ForMember(dest => dest.CertificateId, opt => opt.Condition(src => src.CertificateId.HasValue))
            .ForMember(dest => dest.SpecificationId, opt => opt.Condition(src => src.SpecificationId.HasValue))
            .ForMember(dest => dest.ProductionDate, opt => opt.Condition(src => src.ProductionDate.HasValue))
            .ForMember(dest => dest.MeltStatusId, opt => opt.Condition(src => src.MeltStatusId.HasValue));
    }
}
