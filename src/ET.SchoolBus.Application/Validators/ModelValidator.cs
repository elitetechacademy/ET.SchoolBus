using ET.SchoolBus.Application.DTOs.Request;
using ET.SchoolBus.Data.Repositories.Interfaces;
using ET.SchoolBus.Pack.Enumerations;
using ET.SchoolBus.Pack.Extensions;
using FluentValidation;

namespace ET.SchoolBus.Application.Validators;


public class ModelNameValidator : AbstractValidator<string>
{
    public ModelNameValidator()
    {
        RuleFor(x => x)
            .NotEmpty().WithMessage("Model adı boş olamaz.")
            .MaximumLength(30).WithMessage("Model adı en fazla 30 karakter olabilir.");
    }
}

public class CreateModelValidator : AbstractValidator<ModelCreateDto>
{
    private readonly IModelRepository _modelRepository;
    private readonly IBrandRepository _brandRepository;

    public CreateModelValidator(IModelRepository modelRepository, IBrandRepository brandRepository)
    {
        _modelRepository = modelRepository;
        _brandRepository = brandRepository;

        RuleFor(x => x)
            .MustAsync(async (model, _) =>
            {
                return !await _modelRepository.ModelExistsByNameOnCreate(model.BrandId,
                    model.ModelName);
            }).WithMessage("Bu isimde bir marka zaten kayıtlıdır.")
            .MustAsync(async (model, _) =>
            {
                return await _brandRepository.AnyAsync(x => x.BrandId == model.BrandId);
            }).WithMessage("Marka bulunamadı.");

        RuleFor(x => x.ModelName)
            .SetValidator(new BrandNameValidator());        
    }
}

public class UpdateModelValidator : AbstractValidator<ModelUpdateDto>
{
    private readonly IModelRepository _modelRepository;
    private readonly IBrandRepository _brandRepository;

    public UpdateModelValidator(IModelRepository modelRepository, IBrandRepository brandRepository)
    {
        _modelRepository = modelRepository;
        _brandRepository = brandRepository;

        RuleFor(x => x.ModelName)
            .SetValidator(new ModelNameValidator());

        RuleFor(x => x.ModelId)
        .MustAsync(async (modelId, _) =>
        {
            return await _modelRepository.AnyAsync(x => x.ModelId == modelId);
        }).WithMessage(model => $"{model.ModelId} numaralı kayıt bulunamadı");

        RuleFor(x => x)
            .MustAsync(async (model, _) =>
            {
                return !await _modelRepository.ModelExistsByNameOnUpdate(model.ModelId,
                    model.BrandId, model.ModelName.ToUpperByCulture(Culture.TR));
            }).WithMessage("Bu isimde bir model zaten kayıtlıdır.")
            .MustAsync(async (model, _) =>
            {
                return !await _brandRepository.AnyAsync(x => x.BrandId == model.BrandId);
            }).WithMessage("Marka bulunamadı.");
        
    }
}
