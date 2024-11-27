using ET.SchoolBus.Application.DTOs.Request;
using ET.SchoolBus.Application.DTOs.Response;
using ET.SchoolBus.Application.Wrapper;

namespace ET.SchoolBus.Application.Interfaces;

public interface ISchoolService
{
    Task<Result<List<SchoolDto>>> GetAllAsync();
    Task<Result<SchoolDto>> GetByIdAsync(int id);
    Task<Result> AddSchoolAsync(SchoolCreateDto schoolCreateDto);
    Task<Result> UpdateSchoolAsync(SchoolUpdateDto schoolUpdateDto);
    Task<Result> DeleteSchoolAsync(int schoolId);
}
