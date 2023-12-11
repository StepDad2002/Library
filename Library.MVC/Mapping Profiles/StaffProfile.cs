using AutoMapper;
using Library.MVC.Models;
using Library.MVC.Models.Staff;
using Library.MVC.Services.Base;

namespace Library.MVC.Mapping_Profiles;

public class StaffProfile : Profile
{
    public StaffProfile()
    {
        CreateMap<StaffDto, StaffVM>()
            .ForMember(x => x.HireDate, opt =>
                opt.MapFrom(x => x.HireDate))
            .ReverseMap();
        CreateMap<StaffListDto, StaffListVM>().ReverseMap();
        CreateMap<CreateStaffDto, CreateStaffVM>().ReverseMap();
        CreateMap<UpdateStaffDto, UpdateStaffVM>()
            .ReverseMap();
    }
}