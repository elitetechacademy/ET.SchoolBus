using System;
using ET.SchoolBus.Application.DTOs.Request;
using ET.SchoolBus.Application.DTOs.Response;
using ET.SchoolBus.Application.Wrapper;

namespace ET.SchoolBus.Application.Interfaces;

public interface ISeasonService
{
    Task<Result<List<SeasonDto>>> GetAllAsync();
    Task<Result<SeasonDto>> GetByIdAsync(int id);
    Task<Result> AddSeasonAsync(SeasonCreateDto seasonCreateDto);
    Task<Result> UpdateSeasonAsync(SeasonUpdateDto seasonUpdateDto);
    Task<Result> DeleteSeasonAsync(int seasonId);
}
