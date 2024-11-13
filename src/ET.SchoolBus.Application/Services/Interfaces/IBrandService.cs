using System;
using ET.SchoolBus.Application.DTOs.Request;
using ET.SchoolBus.Application.DTOs.Response;
using ET.SchoolBus.Application.Wrapper;

namespace ET.SchoolBus.Application.Interfaces;

public interface IBrandService
{
    Task<Result<List<BrandDto>>> GetAllAsync();
    Task<Result<BrandDto>> GetByIdAsync(int id);
    Task<Result> AddBrandAsync(BrandCreateDto brandCreateDto);
    Task<Result> UpdateBrandAsync(BrandUpdateDto brandUpdateDto);
    Task<Result> DeleteBrandAsync(int brandId);
}
