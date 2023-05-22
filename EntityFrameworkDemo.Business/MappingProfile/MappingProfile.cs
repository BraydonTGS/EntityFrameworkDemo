﻿using AutoMapper;
using EntityFrameworkDemo.Business.Dto;
using EntityFrameworkDemo.Entity.Entities;

namespace EntityFrameworkDemo.Business.MappingProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Device, DeviceDto>().ReverseMap();
            CreateMap<SubSystem, SubSystemDto>().ReverseMap();
        }
    }
}