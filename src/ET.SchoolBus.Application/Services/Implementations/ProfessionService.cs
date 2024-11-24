using System;
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

public class ProfessionService : IProfessionService
{
    private readonly IUnitOfWork _unitWork;
    private readonly IMapper _mapper;
    private readonly ILogger<ProfessionService> _logger;
    private readonly IProfessionRepository _professionRepository;

    public ProfessionService(IUnitOfWork unitWork, IMapper mapper, ILogger<ProfessionService> logger, IProfessionRepository professionRepository)
    {
        _unitWork = unitWork;
        _mapper = mapper;
        _logger = logger;
        _professionRepository = professionRepository;
    }


    public async Task<Result<List<ProfessionDto>>> GetAllAsync()
    {
        var result = new Result<List<ProfessionDto>>
        {
            IsSuccess = true
        };

        try
        {
            var professionEntities = await _unitWork.ProfessionRepository.GetAllAsync();
            var professionDtos = _mapper.Map<List<ProfessionDto>>(professionEntities);
            result.Data = professionDtos;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "ProfessionService => GetAllAsync : Meslek listesi yüklenirken bir hata oluştu.");
            result.IsSuccess = false;
        }
        return result;
    }

    public async Task<Result<ProfessionDto>> GetByIdAsync(int id)
    {
        var result = new Result<ProfessionDto>
        {
            IsSuccess = true
        };

        try
        {
            var professionEntity = await _unitWork.ProfessionRepository.GetByIdAsync(id);
            var professionDtos = _mapper.Map<ProfessionDto>(professionEntity);
            result.Data = professionDtos;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"ProfessionService => GetByIdAsync : {id} nolu meslek bulunamadı.");
            result.Message = $"{id} nolu meslek bulunamadı.";
            result.IsSuccess = false;
        }
        return result;
    }

    public async Task<Result> AddProfessionAsync(ProfessionCreateDto createProfessionDto)    
    {
        var validator = new CreateProfessionValidator(_professionRepository);
        var validationResult = await validator.ValidateAsync(createProfessionDto);

        if(!validationResult.IsValid)
        {
            return Result.AddValidationError(validationResult.GetErrorMessages());
        }

        try
        {
            //Herşey yolundadır.
            var professionEntity = _mapper.Map<Profession>(createProfessionDto);
            await _professionRepository.AddAsync(professionEntity);
            await _unitWork.Commit();       
            return Result.Success("Meslek başarıyla kaydedildi.");    
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"ProfessionService => AddProfessionAsync : Meslek eklenemedi.");  
            return Result.Failure($"Kayıt işlemi başarız.");           
        }   
    }

    public async Task<Result> UpdateProfessionAsync(ProfessionUpdateDto professionUpdateDto)
    {
        var validator = new UpdateProfessionValidator(_professionRepository);
        var validationResult = await validator.ValidateAsync(professionUpdateDto, CancellationToken.None);
        if (!validationResult.IsValid)
        {
            return Result.AddValidationError(validationResult.GetErrorMessages());
        }

        var existsProfession = await _unitWork.ProfessionRepository.GetByIdAsync(professionUpdateDto.ProfessionId);
        _mapper.Map(professionUpdateDto, existsProfession);

        try
        {
            _unitWork.ProfessionRepository.Update(existsProfession);
            var isOk = await _unitWork.Commit();
            return Result.Success($"Güncelleme işlemi başarıyla tamamlandı.");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"ProfessionService => UpdateProfessionAsync : Kayıt güncellenirken bir hata oluştu.");
            return Result.Failure($"Meslek güncellenirken bir hata oluştu.");
        }
    }

    public async Task<Result> DeleteProfessionAsync(int professionId)
    {
        var existsProfession = await _unitWork.ProfessionRepository.GetByIdAsync(professionId);
        if (existsProfession is null)
        {
            return Result.Failure($"{professionId} nolu meslek bulunamadı.");
        }

        try
        {
            await _unitWork.ProfessionRepository.DeleteAsync(professionId);
            var isOk = await _unitWork.Commit();
            return Result.Success($"{professionId} nolu kayıt başarıyla silindi.");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"ProfessionService => DeleteProfessionAsync : Kayıt silinirken bir hata oluştu.");
            return Result.Failure($"Kayıt silinirken bir hata oluştu.");
        }
    }

}
