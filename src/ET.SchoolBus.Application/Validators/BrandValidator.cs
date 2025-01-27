using ET.SchoolBus.Data.Repositories.Interfaces;
using ET.SchoolBus.Pack.Enumerations;
using FluentValidation;
using ET.SchoolBus.Pack.Extensions;
using ET.SchoolBus.Application.DTOs.Request;

namespace ET.SchoolBus.Application.Validators;


public class BrandNameValidator : AbstractValidator<string>
{
    public BrandNameValidator()
    {
        RuleFor(x => x)
            .NotEmpty().WithMessage("Marka adı boş olamaz.")
            .MaximumLength(30).WithMessage("Marka adı en fazla 30 karakter olabilir.");
    }
}

public class CreateBrandValidator : AbstractValidator<BrandCreateDto>
{
    private readonly IBrandRepository _brandRepository;

    public CreateBrandValidator(IBrandRepository brandRepository)
    {
        _brandRepository = brandRepository;

        RuleFor(x => x.BrandName)
            .SetValidator(new BrandNameValidator())
            .MustAsync(async (brandName, _) =>
            {
                return !await _brandRepository.BrandExistsByNameOnCreate(brandName.ToUpperByCulture(Culture.TR));
            }).WithMessage("Bu isimde bir marka zaten kayıtlıdır.")
            ;
    }
}

public class UpdateBrandValidator : AbstractValidator<BrandUpdateDto>
{
    private readonly IBrandRepository _brandRepository;

    public UpdateBrandValidator(IBrandRepository brandRepository)
    {
        _brandRepository = brandRepository;

        RuleFor(x => x.BrandName)
            .SetValidator(new BrandNameValidator());

        RuleFor(x => x.BrandId)
        .MustAsync(async(brandId, _)=>{
            return await _brandRepository.AnyAsync(x => x.BrandId == brandId);
        }).WithMessage(brand => $"{brand.BrandId} numaralı kayıt bulunamadı");

        RuleFor(x => x)
            .MustAsync(async (brand, _) =>
            {
                return !await _brandRepository.BrandExistsByNameOnUpdate(brand.BrandId,
                    brand.BrandName.ToUpperByCulture(Culture.TR));
            }).WithMessage("Bu isimde bir marka zaten kayıtlıdır.");
    }
}
