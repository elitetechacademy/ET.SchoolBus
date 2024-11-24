using System;
using AutoMapper;
using ET.SchoolBus.Application.DTOs.Response;
using ET.SchoolBus.Domain.Entities;

namespace ET.SchoolBus.Application.Automapper;

public class DomainToDto : Profile
{
    public DomainToDto()
    {
        CreateMap<Brand, BrandDto>();
        CreateMap<Model, ModelDto>();
        CreateMap<Profession, ProfessionDto>();
    }
}
