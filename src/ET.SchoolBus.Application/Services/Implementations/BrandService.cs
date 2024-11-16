
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

public class BrandService : IBrandService
{
    private readonly IUnitOfWork _unitWork;
    private readonly ILogger<BrandService> _logger;
    private readonly IBrandRepository _brandRepository;
    private readonly IMapper _mapper;

    public BrandService(IUnitOfWork unitWork, ILogger<BrandService> logger, IBrandRepository brandRepository, IMapper mapper)
    {
        _unitWork = unitWork;
        _logger = logger;
        _brandRepository = brandRepository;
        _mapper = mapper;
    }


    public async Task<Result<List<BrandDto>>> GetAllAsync()
    {
        try
        {
            var brandEntities = await _unitWork.BrandRepository.GetAllAsync();
            var brandDtos = _mapper.Map<List<BrandDto>>(brandEntities);
            return Result<List<BrandDto>>.Success(brandDtos);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"BrandService => GetAllAsync : Kayıt dilinirken bir hata oluştu.");
            return Result<List<BrandDto>>.Failure($"Kayıt güncellenirken bir hata oluştu.");
        }
    }

    public async Task<Result<BrandDto>> GetByIdAsync(int id)
    {
        try
        {
            var brandEntity = await _unitWork.BrandRepository.GetByIdAsync(id);

            if (brandEntity is null)
                return Result<BrandDto>.Failure($"{id} numaralı kayıt bulunamadı.");

            var brandDto = _mapper.Map<BrandDto>(brandEntity);
            return Result<BrandDto>.Success(brandDto);

        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"BrandService => GetByIdAsync : Kayıt yüklenirken bir hata oluştu.");
            return Result<BrandDto>.Failure($"Marka yüklenemedi.");
        }
    }

    public async Task<Result> AddBrandAsync(BrandCreateDto brandCreateDto)
    {
        var validator = new CreateBrandValidator(_brandRepository);
        var validationResult = await validator.ValidateAsync(brandCreateDto, CancellationToken.None);
        if (!validationResult.IsValid)
        {
            return Result.AddValidationError(validationResult.GetErrorMessages());
        }

        try
        {
            var brandEntity = _mapper.Map<BrandCreateDto, Brand>(brandCreateDto);
            await _unitWork.BrandRepository.AddAsync(brandEntity);
            var isOk = await _unitWork.Commit();
            return Result.Success($"Marka başarıyla kaydedildi.");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"BrandService => Create : Kayıt eklenirken bir hata oluştu.");
            return Result.Failure($"Kayıt eklenirken bir hata oluştu.");
        }
    }

    public async Task<Result> UpdateBrandAsync(BrandUpdateDto brandUpdateDto)
    {
        var validator = new UpdateBrandValidator(_brandRepository);
        var validationResult = await validator.ValidateAsync(brandUpdateDto, CancellationToken.None);
        if (!validationResult.IsValid)
        {
            return Result.AddValidationError(validationResult.GetErrorMessages());
        }

        var existsBrand = await _unitWork.BrandRepository.GetByIdAsync(brandUpdateDto.BrandId);
        _mapper.Map<BrandUpdateDto, Brand>(brandUpdateDto);

        try
        {
            _unitWork.BrandRepository.Update(existsBrand);
            var isOk = await _unitWork.Commit();
            return Result.Success($"Güncelleme işlemi başarıyla tamamlandı.");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"BrandService => Update : Kayıt güncellenirken bir hata oluştu.");
            return Result.Failure($"Marka güncellenirken bir hata oluştu.");
        }
    }

    public async Task<Result> DeleteBrandAsync(int brandId)
    {
        var existsBrand = await _unitWork.BrandRepository.GetByIdAsync(brandId);
        if (existsBrand is null)
        {
            return Result.Failure($"{brandId} nolu marka bulunamadı.");
        }

        existsBrand.Status = false;
        existsBrand.UpdatedTime = DateTime.Now;
        existsBrand.UpdatedUser = "admin";

        try
        {
            _unitWork.BrandRepository.Update(existsBrand);
            var isOk = await _unitWork.Commit();
            return Result.Success($"{brandId} nolu kayıt başarıyla silindi.");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"BrandService => Update : Kayıt silinirken bir hata oluştu.");
            return Result.Failure($"Kayıt güncellenirken bir hata oluştu.");
        }
    }


}
