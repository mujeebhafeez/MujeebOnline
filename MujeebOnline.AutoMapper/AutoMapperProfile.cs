using AutoMapper;
using MujeebOnline.Entities;
using MujeebOnline.ViewModels;

namespace MujeebOnline.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Employee, EmployeeVM>().ReverseMap();
        }
    }
}