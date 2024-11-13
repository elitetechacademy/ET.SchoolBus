using System;
using ET.SchoolBus.Application.DTOs.Request;
using ET.SchoolBus.Application.DTOs.Response;
using ET.SchoolBus.Application.Interfaces;
using ET.SchoolBus.Application.Wrapper;
using ET.SchoolBus.Data.UnitWork;
using ET.SchoolBus.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace ET.SchoolBus.Application.Services.Implementaions;

public class BrandService : IBrandService
{
    private readonly IUnitOfWork _unitWork;
    private readonly ILogger<BrandService> _logger;

    public BrandService(IUnitOfWork unitWork, ILogger<BrandService> logger)
    {
        _unitWork = unitWork;
        _logger = logger;
    }

    public async Task<Result> AddBrandAsync(BrandCreateDto brandCreateDto)
    {
        if (string.IsNullOrWhiteSpace(brandCreateDto.BrandName))
        {
            return Result.AddValidationError(new List<string> { "Marka adı boş olamaz." });
        }
        else if (brandCreateDto.BrandName.Length > 30)
        {
            return Result.AddValidationError(new List<string> { "Marka adı 30 karakterden fazla olamaz." });
        }

        try
        {
            var brandEntity = new Brand
            {
                BrandName = brandCreateDto.BrandName
            };
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

    public async Task<Result<List<BrandDto>>> GetAllAsync()
    {
        try
        {
            var brandEntities = await _unitWork.BrandRepository.GetAllAsync();
            var brandDtos = brandEntities.Select(brandEntity => new BrandDto
            {
                BrandId = brandEntity.BrandId,
                BrandName = brandEntity.BrandName
            }).ToList();
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
            var brand = await _unitWork.BrandRepository.GetByIdAsync(id);

            if (brand is null)
                return Result<BrandDto>.Failure($"{id} numaralı kayıt bulunamadı.");

            var data = new BrandDto
            {
                BrandId = brand.BrandId,
                BrandName = brand.BrandName
            };
            return Result<BrandDto>.Success(data);

        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"BrandService => GetByIdAsync : Kayıt yüklenirken bir hata oluştu.");
            return Result<BrandDto>.Failure($"Marka yüklenemedi.");
        }
    }

    public async Task<Result> UpdateBrandAsync(BrandUpdateDto brandUpdateDto)
    {
        var existsBrand = await _unitWork.BrandRepository.GetByIdAsync(brandUpdateDto.BrandId);
        if (existsBrand is null)
        {
            return Result.Failure($"{brandUpdateDto.BrandId} nolu kayıt bulunamadı.");
        }

        existsBrand.BrandName = brandUpdateDto.BrandName;
        existsBrand.UpdatedTime = DateTime.Now;
        existsBrand.UpdatedUser = "admin";

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
}
