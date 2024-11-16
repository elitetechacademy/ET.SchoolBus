using System;
using ET.SchoolBus.Application.DTOs.Request;
using ET.SchoolBus.Domain.Repositories;
using FluentValidation;

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
            .MustAsync(async (brandName, _) =>
            {
                return !await _brandRepository.BrandExistsByNameOnCreate(brandName.ToUpper());
            }).WithMessage("Bu isimde bir marka zaten kayıtlıdır.")
            .SetValidator(new BrandNameValidator());
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
                    brand.BrandName.ToUpper());
            }).WithMessage("Bu isimde bir marka zaten kayıtlıdır.");
    }
}
