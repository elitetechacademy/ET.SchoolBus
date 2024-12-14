
using AutoMapper;
using ET.SchoolBus.Application.DTOs.Request;
using ET.SchoolBus.Application.DTOs.Response;
using ET.SchoolBus.Application.Interfaces;
using ET.SchoolBus.Application.Validators;
using ET.SchoolBus.Application.Wrapper;
using ET.SchoolBus.Data.Repositories.Interfaces;
using ET.SchoolBus.Data.UnitWork;
using ET.SchoolBus.Domain.Entities;
using ET.SchoolBus.Pack.Extensions;
using Microsoft.Extensions.Logging;

namespace ET.SchoolBus.Application.Services.Implementations;

public class SchoolService : ISchoolService
{
    private readonly IUnitOfWork _unitWork;
    private readonly ILogger<SchoolService> _logger;
    private readonly ISchoolRepository _schoolRepository;
    private readonly IMapper _mapper;

    public SchoolService(IUnitOfWork unitWork, ILogger<SchoolService> logger, ISchoolRepository schoolRepository, IMapper mapper)
    {
        _unitWork = unitWork;
        _logger = logger;
        _schoolRepository = schoolRepository;
        _mapper = mapper;
    }

    public async Task<Result<List<SchoolDto>>> GetAllAsync()
    {
        try
        {
            var schoolEntities = await _unitWork.SchoolRepository.GetAllAsync();
            var schoolDtos = _mapper.Map<List<SchoolDto>>(schoolEntities);
            return Result<List<SchoolDto>>.Success(schoolDtos);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"SchoolService => GetAllAsync : Okul listesi yüklenemedi.");
            return Result<List<SchoolDto>>.Failure($"Okul listesi yüklenemedi.");
        }
    }

    public async Task<Result<SchoolDto>> GetByIdAsync(int id)
    {
        try
        {
            var schoolEntity = await _unitWork.SchoolRepository.GetByIdAsync(id);

            if (schoolEntity is null)
                return Result<SchoolDto>.Failure($"{id} numaralı kayıt bulunamadı.");

            var schoolDto = _mapper.Map<SchoolDto>(schoolEntity);
            return Result<SchoolDto>.Success(schoolDto);

        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"SchoolService => GetByIdAsync : Kayıt yüklenirken bir hata oluştu.");
            return Result<SchoolDto>.Failure($"Okul yüklenemedi.");
        }
    }

    public async Task<Result> AddSchoolAsync(SchoolCreateDto schoolCreateDto)
    {
        var validator = new CreateSchoolValidator(_schoolRepository);
        var validationResult = await validator.ValidateAsync(schoolCreateDto, CancellationToken.None);
        if (!validationResult.IsValid)
        {
            return Result.AddValidationError(validationResult.GetErrorMessages());
        }

        try
        {
            var schoolEntity = _mapper.Map<SchoolCreateDto, School>(schoolCreateDto);
            await _unitWork.SchoolRepository.AddAsync(schoolEntity);
            var isOk = await _unitWork.Commit();
            return Result.Success($"Okul başarıyla kaydedildi.");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"SchoolService => AddSchoolAsync : Kayıt eklenirken bir hata oluştu.");
            return Result.Failure($"Kayıt eklenirken bir hata oluştu.");
        }
    }

    public async Task<Result> UpdateSchoolAsync(SchoolUpdateDto schoolUpdateDto)
    {
        var validator = new UpdateSchoolValidator(_schoolRepository);
        var validationResult = await validator.ValidateAsync(schoolUpdateDto, CancellationToken.None);
        if (!validationResult.IsValid)
        {
            return Result.AddValidationError(validationResult.GetErrorMessages());
        }

        var existsSchool = await _unitWork.SchoolRepository.GetByIdAsync(schoolUpdateDto.SchoolId);
        _mapper.Map<SchoolUpdateDto, School>(schoolUpdateDto, existsSchool);

        try
        {
            _unitWork.SchoolRepository.Update(existsSchool);
            var isOk = await _unitWork.Commit();
            return Result.Success($"Güncelleme işlemi başarıyla tamamlandı.");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"SchoolService => UpdateSchoolAsync : Kayıt güncellenirken bir hata oluştu.");
            return Result.Failure($"Okul güncellenirken bir hata oluştu.");
        }
    }

    public async Task<Result> DeleteSchoolAsync(int schoolId)
    {
        var existsSchool = await _unitWork.SchoolRepository.GetByIdAsync(schoolId);
        if (existsSchool is null)
        {
            return Result.Failure($"{schoolId} nolu Okul bulunamadı.");
        }

        try
        {
            await _unitWork.SchoolRepository.DeleteAsync(schoolId);
            var isOk = await _unitWork.Commit();
            return Result.Success($"{schoolId} nolu kayıt başarıyla silindi.");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"SchoolService => DeleteSchoolAsync : Kayıt silinirken bir hata oluştu.");
            return Result.Failure($"Kayıt güncellenirken bir hata oluştu.");
        }
    }
}
