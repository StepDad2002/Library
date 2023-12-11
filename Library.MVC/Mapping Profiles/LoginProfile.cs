using AutoMapper;
using Library.MVC.Models;
using Library.MVC.Services.Base;

namespace Library.MVC.Mapping_Profiles;

public class LoginProfile : Profile
{
    public LoginProfile()
    {
        CreateMap<LogInDto, LoginVM>().ReverseMap();
    }
}