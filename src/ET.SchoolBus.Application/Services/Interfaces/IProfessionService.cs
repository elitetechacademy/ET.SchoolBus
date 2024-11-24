

using ET.SchoolBus.Application.DTOs.Request;
using ET.SchoolBus.Application.DTOs.Response;
using ET.SchoolBus.Application.Wrapper;

namespace ET.SchoolBus.Application.Services.Interfaces;

public interface IProfessionService
{
    Task<Result<List<ProfessionDto>>> GetAllAsync();
    Task<Result<ProfessionDto>> GetByIdAsync(int id);
    Task<Result> AddProfessionAsync(ProfessionCreateDto createProfessionDto);
    Task<Result> UpdateProfessionAsync(ProfessionUpdateDto updateProfessionDto);
    Task<Result> DeleteProfessionAsync(int professionId);
}
