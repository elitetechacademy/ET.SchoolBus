
using AutoMapper;
using ET.SchoolBus.Application.DTOs.Request;
using ET.SchoolBus.Application.DTOs.Response;
using ET.SchoolBus.Application.Interfaces;
using ET.SchoolBus.Application.Validators;
using ET.SchoolBus.Application.Wrapper;
using ET.SchoolBus.Data.Repositories.Implementations;
using ET.SchoolBus.Data.Repositories.Interfaces;
using ET.SchoolBus.Data.UnitWork;
using ET.SchoolBus.Domain.Entities;
using ET.SchoolBus.Pack.AppContext;
using ET.SchoolBus.Pack.Extensions;
using Microsoft.Extensions.Logging;

namespace ET.SchoolBus.Application.Services.Implementations;

public class SeasonService : ISeasonService
{
    private readonly IUnitOfWork _unitWork;
    private readonly ILogger<SeasonService> _logger;
    private readonly ISeasonRepository _seasonRepository;
    private readonly IMapper _mapper;

    public SeasonService(IUnitOfWork unitWork, ILogger<SeasonService> logger, ISeasonRepository seasonRepository, IMapper mapper)
    {
        _unitWork = unitWork;
        _logger = logger;
        _seasonRepository = seasonRepository;
        _mapper = mapper;
    }


    public async Task<Result<List<SeasonDto>>> GetAllAsync()
    {
        try
        {            
            var seasonEntities = await _unitWork.SeasonRepository.GetAllAsync();
            var seasonDtos = _mapper.Map<List<SeasonDto>>(seasonEntities);
            return Result<List<SeasonDto>>.Success(seasonDtos);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"SeasonService => GetAllAsync : Sezon listesi yüklemedi.");
            return Result<List<SeasonDto>>.Failure($"Sezon listesi yüklenemedi.");
        }
    }

    public async Task<Result<SeasonDto>> GetByIdAsync(int id)
    {
        try
        {
            var seasonEntity = await _unitWork.SeasonRepository.GetByIdAsync(id);

            if (seasonEntity is null)
                return Result<SeasonDto>.Failure($"{id} numaralı kayıt bulunamadı.");

            var seasonDto = _mapper.Map<SeasonDto>(seasonEntity);
            return Result<SeasonDto>.Success(seasonDto);

        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"SeasonService => GetByIdAsync : Kayıt yüklenirken bir hata oluştu.");
            return Result<SeasonDto>.Failure($"Sezon yüklenemedi.");
        }
    }

    public async Task<Result> AddSeasonAsync(SeasonCreateDto seasonCreateDto)
    {
        var validator = new CreateSeasonValidator(_seasonRepository);
        var validationResult = await validator.ValidateAsync(seasonCreateDto, CancellationToken.None);
        if (!validationResult.IsValid)
        {
            return Result.AddValidationError(validationResult.GetErrorMessages());
        }

        try
        {
            var seasonEntity = _mapper.Map<SeasonCreateDto, Season>(seasonCreateDto);
            await _unitWork.SeasonRepository.AddAsync(seasonEntity);
            var isOk = await _unitWork.Commit();
            return Result.Success($"Sezon başarıyla kaydedildi.");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"SeasonService => AddSeasonAsync : Kayıt eklenirken bir hata oluştu.");
            return Result.Failure($"Kayıt eklenirken bir hata oluştu.");
        }
    }

    public async Task<Result> UpdateSeasonAsync(SeasonUpdateDto seasonUpdateDto)
    {
        var validator = new UpdateSeasonValidator(_seasonRepository);
        var validationResult = await validator.ValidateAsync(seasonUpdateDto, CancellationToken.None);
        if (!validationResult.IsValid)
        {
            return Result.AddValidationError(validationResult.GetErrorMessages());
        }

        var existsSeason = await _unitWork.SeasonRepository.GetByIdAsync(seasonUpdateDto.SeasonId);
        _mapper.Map<SeasonUpdateDto, Season>(seasonUpdateDto, existsSeason);

        try
        {
            _unitWork.SeasonRepository.Update(existsSeason);
            var isOk = await _unitWork.Commit();
            return Result.Success($"Güncelleme işlemi başarıyla tamamlandı.");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Seasonervice => UpdateSeasonsync : Kayıt güncellenirken bir hata oluştu.");
            return Result.Failure($"Sezon güncellenirken bir hata oluştu.");
        }
    }

    public async Task<Result> DeleteSeasonAsync(int seasonId)
    {
        var existsSeason = await _unitWork.SeasonRepository.GetByIdAsync(seasonId);
        if (existsSeason is null)
        {
            return Result.Failure($"{seasonId} nolu sezon bulunamadı.");
        }

        try
        {
            await _unitWork.SeasonRepository.DeleteAsync(seasonId);
            var isOk = await _unitWork.Commit();
            return Result.Success($"{seasonId} nolu kayıt başarıyla silindi.");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"SeasonService => DeleteSeasonsync : Kayıt silinirken bir hata oluştu.");
            return Result.Failure($"Kayıt güncellenirken bir hata oluştu.");
        }
    }
}
