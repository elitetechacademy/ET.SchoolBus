
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

public class ModelService : IModelService
{
    private readonly IUnitOfWork _unitWork;
    private readonly ILogger<ModelService> _logger;
    private readonly IModelRepository _modelRepository;
    private readonly IBrandRepository _brandRepository;
    private readonly IMapper _mapper;

    public ModelService(IUnitOfWork unitWork, ILogger<ModelService> logger, IModelRepository modelRepository, IBrandRepository brandRepository, IMapper mapper)
    {
        _unitWork = unitWork;
        _logger = logger;
        _modelRepository = modelRepository;
        _brandRepository = brandRepository;
        _mapper = mapper;
    }


    public async Task<Result<List<ModelDto>>> GetAllAsync()
    {
        try
        {
            var modelEntities = await _unitWork.ModelRepository.GetAllWithBrandAsync();
            var modelDtos = _mapper.Map<List<ModelDto>>(modelEntities);
            return Result<List<ModelDto>>.Success(modelDtos);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"ModelService => GetAllAsync : Model listesi yüklenemedi.");
            return Result<List<ModelDto>>.Failure($"Model listesi yüklenemedi.");
        }
    }

    public async Task<Result<ModelDto>> GetByIdAsync(int id)
    {
        try
        {
            var modelEntity = await _unitWork.ModelRepository.GetByIdWithBrandAsync(id);

            if (modelEntity is null)
                return Result<ModelDto>.Failure($"{id} numaralı kayıt bulunamadı.");

            var ModelDto = _mapper.Map<ModelDto>(modelEntity);
            return Result<ModelDto>.Success(ModelDto);

        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"ModelService => GetByIdAsync : Kayıt yüklenirken bir hata oluştu.");
            return Result<ModelDto>.Failure($"Model yüklenemedi.");
        }
    }

    public async Task<Result<List<ModelDto>>> GetAllByBrandIdAsync(int brandId)
    {
        var brandEntity = await _unitWork.BrandRepository.GetByIdAsync(brandId);
        if(brandEntity is null)
        {
            _logger.LogInformation($"ModelService => GetAllByBrandIdAsync : {brandId} numaralı marka bulunamadı.");
            return Result<List<ModelDto>>.Failure($"Geçerli bir marka seçilmelidir.");
        }

        try
        {
            var modelEntities = await _unitWork.ModelRepository.GetByBrandIdAsync(brandId);
            var modelDtos = _mapper.Map<List<Model>, List<ModelDto>>(modelEntities);
            return Result<List<ModelDto>>.Success(modelDtos);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"{brandId} nolu marka bulunamadı.");
            return Result<List<ModelDto>>.Failure("Markaya bağlı modeller yüklenirken bir hata oluştu.");
        }
    }

    public async Task<Result> AddModelAsync(ModelCreateDto modelCreateDto)
    {
        var validator = new CreateModelValidator(_modelRepository, _brandRepository);
        var validationResult = await validator.ValidateAsync(modelCreateDto, CancellationToken.None);
        if (!validationResult.IsValid)
        {
            return Result.AddValidationError(validationResult.GetErrorMessages());
        }

        try
        {
            var modelEntity = _mapper.Map<ModelCreateDto, Model>(modelCreateDto);
            await _unitWork.ModelRepository.AddAsync(modelEntity);
            var isOk = await _unitWork.Commit();
            return Result.Success($"Model başarıyla kaydedildi.");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"ModelService => AddModelAsync : Kayıt eklenirken bir hata oluştu.");
            return Result.Failure($"Model eklenemedi.");
        }
    }

    public async Task<Result> UpdateModelAsync(ModelUpdateDto modelUpdateDto)
    {
        var validator = new UpdateModelValidator(_modelRepository, _brandRepository);
        var validationResult = await validator.ValidateAsync(modelUpdateDto, CancellationToken.None);
        if (!validationResult.IsValid)
        {
            return Result.AddValidationError(validationResult.GetErrorMessages());
        }

        var existsModel = await _unitWork.ModelRepository.GetByIdAsync(modelUpdateDto.ModelId);
        _mapper.Map(modelUpdateDto, existsModel);

        try
        {
            _unitWork.ModelRepository.Update(existsModel);
            var isOk = await _unitWork.Commit();
            return Result.Success($"Güncelleme işlemi başarıyla tamamlandı.");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"ModelService => UpdateModelAsync : Kayıt güncellenirken bir hata oluştu.");
            return Result.Failure($"Model güncellenirken bir hata oluştu.");
        }
    }

    public async Task<Result> DeleteModelAsync(int modelId)
    {
        var existsModel = await _unitWork.ModelRepository.GetByIdAsync(modelId);
        if (existsModel is null)
        {
            return Result.Failure($"{modelId} nolu marka bulunamadı.");
        }

        try
        {
            await _unitWork.ModelRepository.DeleteAsync(modelId);
            var isOk = await _unitWork.Commit();
            return Result.Success($"{modelId} nolu kayıt başarıyla silindi.");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"ModelService => DeleteModelAsync : Kayıt silinirken bir hata oluştu.");
            return Result.Failure($"Model silinemedi.");
        }
    }    
}
