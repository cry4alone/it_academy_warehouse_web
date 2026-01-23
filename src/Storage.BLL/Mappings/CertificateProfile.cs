using AutoMapper;
using Storage.BLL.DTO.Reponses;
using Storage.DAL.Models;

namespace Storage.BLL.Mappings;

public class CertificateProfile : Profile
{
    public CertificateProfile()
    {
        CreateMap<Certificate, CertificateResponse>()
            .ForCtorParam("CertificateId", opt => opt.MapFrom(src => src.CertificateId))
            .ForCtorParam("ControlScheme", opt => opt.MapFrom(src => src.ControlScheme!.Specification.Name))
            .ForCtorParam("CreationDate", opt => opt.MapFrom(src => src.CreatedDate)) 
            .ForCtorParam("WarehouseName", opt => opt.MapFrom(src => src.Warehouse.Name))
            .ForCtorParam("SigningUser", opt => opt.MapFrom(src => src.User!.Surname))
            .ForCtorParam("MeltsInCertificate", opt => opt.MapFrom(src => src.Melts.Count));
    }
}
