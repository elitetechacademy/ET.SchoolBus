using ET.SchoolBus.Application.DTOs.Request;
using ET.SchoolBus.Application.DTOs.Response;
using ET.SchoolBus.Application.Wrapper;

namespace ET.SchoolBus.Application.Services.Interfaces;

public interface IParentService
{
    Task<Result<List<ParentDto>>> GetAllAsync();
    Task<Result<ParentDto>> GetByIdAsync(int id);
    Task<Result<List<ParentDto>>> GetAllByProfessionIdAsync(int professionId);
    Task<Result<List<ParentDto>>> GetAllBySchoolIdAsync(int schoolId);
    Task<Result> AddParentAsync(ParentCreateDto parentCreateDto);
    Task<Result> UpdateParentAsync(ParentUpdateDto parentUpdateDto);
    Task<Result> DeleteParentAsync(int parentId);
}
