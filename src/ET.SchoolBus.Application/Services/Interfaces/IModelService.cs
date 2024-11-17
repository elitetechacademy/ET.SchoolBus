using System;
using ET.SchoolBus.Application.DTOs.Request;
using ET.SchoolBus.Application.DTOs.Response;
using ET.SchoolBus.Application.Wrapper;

namespace ET.SchoolBus.Application.Services.Interfaces;

public interface IModelService
{
    Task<Result<List<ModelDto>>> GetAllAsync();
    Task<Result<ModelDto>> GetByIdAsync(int id);
    Task<Result<List<ModelDto>>> GetAllByBrandIdAsync(int brandId);
    Task<Result> AddModelAsync(ModelCreateDto modelCreateDto);
    Task<Result> UpdateModelAsync(ModelUpdateDto modelUpdateDto);
    Task<Result> DeleteModelAsync(int modelId);
}
