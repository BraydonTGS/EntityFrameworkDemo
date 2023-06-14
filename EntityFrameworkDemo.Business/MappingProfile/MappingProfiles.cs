using AutoMapper;
using EntityFrameworkDemo.Business.Dto;
using EntityFrameworkDemo.Entity.Entities;

namespace EntityFrameworkDemo.Business.MappingProfile
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Device, DeviceDto>().ReverseMap();
            CreateMap<SubSystem, SubSystemDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Password, PasswordDto>().ReverseMap();
        }
    }
}
