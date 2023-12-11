using AutoMapper;
using Library.Application.DTOs;
using Library.Domain.Entities.Schemas.Management;

namespace Library.Application.Profiles;

public class StaffProfile : Profile
{
    public StaffProfile()
    {
        CreateMap<Staff,StaffDto>()
            .ForMember(x => x.HireDate,
                opt => opt.MapFrom(s => s.CreatedDate))
            .ForMember(x => x.Position, opt =>
                opt.MapFrom(x => x.Position.ToString()))
            .ReverseMap();
        CreateMap<Staff,CreateStaffDto>()
            .ForMember(x => x.Position, opt =>
                opt.MapFrom(x => x.Position.ToString())).ReverseMap();
        CreateMap<Staff,StaffListDto>()
            .ForMember(x => x.Position, opt =>
                opt.MapFrom(x => x.Position.ToString())).ReverseMap();
        CreateMap<Staff,UpdateStaffDto>()
            .ForMember(x => x.Position, opt =>
                opt.MapFrom(x => x.Position.ToString())).ReverseMap();
    }
}