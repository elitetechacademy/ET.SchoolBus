using System;
using AutoMapper;
using ET.SchoolBus.Application.DTOs.Request;
using ET.SchoolBus.Domain.Entities;
using ET.SchoolBus.Pack.Enumerations;
using ET.SchoolBus.Pack.Extensions;

namespace ET.SchoolBus.Application.Automapper;

public class DtoToDomain : Profile
{
    public DtoToDomain()
    {
        CreateMap<BrandCreateDto, Brand>()
            .ForMember(brand => brand.BrandName, 
                y=> y.MapFrom(dto => dto.BrandName.ToUpperByCulture(Culture.TR)));

        CreateMap<BrandUpdateDto, Brand>()
            .ForMember(brand => brand.BrandName, 
                y=> y.MapFrom(dto => dto.BrandName.ToUpperByCulture(Culture.TR)));

        CreateMap<ModelCreateDto, Model>()
            .ForMember(model => model.ModelName, 
                y=> y.MapFrom(dto => dto.ModelName.ToUpperByCulture(Culture.TR)));

        CreateMap<ModelUpdateDto, Model>()
            .ForMember(model => model.ModelName, 
                y=> y.MapFrom(dto => dto.ModelName.ToUpperByCulture(Culture.TR)));
        
        CreateMap<ProfessionCreateDto, Profession>()
            .ForMember(model => model.Name, 
                y=> y.MapFrom(dto => dto.Name.ToUpperByCulture(Culture.TR)));

        CreateMap<SchoolCreateDto, School>()
         .ForMember(model => model.SchoolName,
             y => y.MapFrom(dto => dto.SchoolName.ToUpperByCulture(Culture.TR)));

        CreateMap<SchoolUpdateDto, School>()
        .ForMember(model => model.SchoolName,
            y => y.MapFrom(dto => dto.SchoolName.ToUpperByCulture(Culture.TR)));
    }
}
