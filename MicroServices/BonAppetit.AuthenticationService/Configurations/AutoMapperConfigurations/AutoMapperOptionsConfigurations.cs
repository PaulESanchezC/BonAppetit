﻿using AutoMapper;
using Models.ApplicationUserModels;


namespace Configurations.AutoMapperConfigurations;
public class AutoMapperOptionsConfigurations : Profile
{
    public AutoMapperOptionsConfigurations()
    {
        CreateMap<ApplicationUser, ApplicationUserDto>().ReverseMap();
        CreateMap<ApplicationUser, ApplicationUserCreateDto>().ReverseMap();
        CreateMap<ApplicationUserDto, ApplicationUserCreateDto>().ReverseMap();
    }
}