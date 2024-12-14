
using AutoMapper;
using ET.SchoolBus.Application.DTOs.Request;
using ET.SchoolBus.Application.DTOs.Response;
using ET.SchoolBus.Application.Services.Interfaces;
using ET.SchoolBus.Application.Validators;
using ET.SchoolBus.Application.Wrapper;
using ET.SchoolBus.Data.Repositories.Interfaces;
using ET.SchoolBus.Data.UnitWork;
using ET.SchoolBus.Domain.Entities;

using ET.SchoolBus.Pack.Extensions;
using Microsoft.Extensions.Logging;

namespace ET.SchoolBus.Application.Services.Implementations;

public class ParentService : IParentService
{
    private readonly IUnitOfWork _unitWork;
    private readonly ILogger<ParentService> _logger;
    private readonly IParentRepository _parentRepository;
    private readonly IProfessionRepository _professionRepository;
    private readonly ISchoolRepository _schoolRepository;
    private readonly IMapper _mapper;

    public ParentService(IUnitOfWork unitWork, ILogger<ParentService> logger, IParentRepository parentRepository, IProfessionRepository professionRepository, ISchoolRepository schoolRepository, IMapper mapper)
    {
        _unitWork = unitWork;
        _logger = logger;
        _parentRepository = parentRepository;
        _professionRepository = professionRepository;
        _schoolRepository = schoolRepository;
        _mapper = mapper;
    }


    public async Task<Result<List<ParentDto>>> GetAllAsync()
    {
        try
        {
            var parentEntities = await _unitWork.ParentRepository.GetAllAsync();
            var parentDtos = _mapper.Map<List<ParentDto>>(parentEntities);
            return Result<List<ParentDto>>.Success(parentDtos);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"ParentService => GetAllAsync : Veli listesi yüklenemedi.");
            return Result<List<ParentDto>>.Failure($"Veli listesi yüklenemedi.");
        }
    }

    public async Task<Result<ParentDto>> GetByIdAsync(int id)
    {
        try
        {
            var parentEntity = await _unitWork.ParentRepository.GetByIdAsync(id);

            if (parentEntity is null)
                return Result<ParentDto>.Failure($"{id} numaralı kayıt bulunamadı.");

            var parentDto = _mapper.Map<ParentDto>(parentEntity);
            return Result<ParentDto>.Success(parentDto);

        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"ParentService => GetByIdAsync : Kayıt yüklenirken bir hata oluştu.");
            return Result<ParentDto>.Failure($"Veli bilgisi yüklenemedi.");
        }
    }

    public async Task<Result<List<ParentDto>>> GetAllByProfessionIdAsync(int professionId)
    {
        var professionEntity = await _unitWork.ProfessionRepository.GetByIdAsync(professionId);
        if (professionEntity is null)
        {
            _logger.LogInformation($"ProfessionService => GetAllByProfessionIdAsync : {professionId} numaralı Meslek bulunamadı.");
            return Result<List<ParentDto>>.Failure($"Geçerli bir marka seçilmelidir.");
        }

        try
        {
            var parentEntities = await _unitWork.ParentRepository.GetByProfessionIdAsync(professionId);
            var modelDtos = _mapper.Map<List<Parent>, List<ParentDto>>(parentEntities);
            return Result<List<ParentDto>>.Success(modelDtos);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"{professionId} nolu Veli bulunamadı.");
            return Result<List<ParentDto>>.Failure("Veliye bağlı Meslekler yüklenirken bir hata oluştu.");
        }
    }

    public async Task<Result<List<ParentDto>>> GetAllBySchoolIdAsync(int schoolId)
    {
        var schoolEntity = await _unitWork.ParentRepository.GetByIdAsync(schoolId);
        if (schoolEntity is null)
        {
            _logger.LogInformation($"SchoolService => GetAllBySchoolIdAsync : {schoolId} numaralı Okullar bulunamadı.");
            return Result<List<ParentDto>>.Failure($"Geçerli bir Veli seçilmelidir.");
        }

        try
        {
            var schoolEntities = await _unitWork.ParentRepository.GetBySchoolIdAsync(schoolId);
            var modelDtos = _mapper.Map<List<Parent>, List<ParentDto>>(schoolEntities);
            return Result<List<ParentDto>>.Success(modelDtos);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"{schoolId} nolu Okul bulunamadı.");
            return Result<List<ParentDto>>.Failure("Veliye bağlı Okullar yüklenirken bir hata oluştu.");
        }
    }

    public async Task<Result> AddParentAsync(ParentCreateDto parentCreateDto)
    {
        var validator = new CreateParentValidator(_parentRepository, _schoolRepository);
        var validationResult = await validator.ValidateAsync(parentCreateDto, CancellationToken.None);
        if (!validationResult.IsValid)
        {
            return Result.AddValidationError(validationResult.GetErrorMessages());
        }

        try
        {
            var parentEntity = _mapper.Map<ParentCreateDto, Parent>(parentCreateDto);
            await _unitWork.ParentRepository.AddAsync(parentEntity);
            var isOk = await _unitWork.Commit();
            return Result.Success($"Veli başarıyla kaydedildi.");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"ParentService => AddParentAsync : Kayıt eklenirken bir hata oluştu.");
            return Result.Failure($"Parent eklenemedi.");
        }
    }

    public async Task<Result> UpdateParentAsync(ParentUpdateDto parentUpdateDto)
    {
        var validator = new UpdateParentValidator(_parentRepository, _schoolRepository);
        var validationResult = await validator.ValidateAsync(parentUpdateDto, CancellationToken.None);
        if (!validationResult.IsValid)
        {
            return Result.AddValidationError(validationResult.GetErrorMessages());
        }

        var existsParent = await _unitWork.ParentRepository.GetByIdAsync(parentUpdateDto.SchoolId);
        _mapper.Map<ParentUpdateDto, Parent>(parentUpdateDto, existsParent);

        try
        {
            _unitWork.ParentRepository.Update(existsParent);
            var isOk = await _unitWork.Commit();
            return Result.Success($"Güncelleme işlemi başarıyla tamamlandı.");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"ParentService => UpdateParentAsync : Kayıt güncellenirken bir hata oluştu.");
            return Result.Failure($"Parent güncellenirken bir hata oluştu.");
        }
    }

    public async Task<Result> DeleteParentAsync(int parentId)
    {
        var existsParent = await _unitWork.ModelRepository.GetByIdAsync(parentId);
        if (existsParent is null)
        {
            return Result.Failure($"{parentId} nolu marka bulunamadı.");
        }

        try
        {
            await _unitWork.ParentRepository.DeleteAsync(parentId);
            var isOk = await _unitWork.Commit();
            return Result.Success($"{parentId} nolu kayıt başarıyla silindi.");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"ParentService => DeleteParentAsync : Kayıt silinirken bir hata oluştu.");
            return Result.Failure($"Veli silinemedi.");
        }
    }    
}
