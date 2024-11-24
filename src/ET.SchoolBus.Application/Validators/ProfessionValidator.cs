using System;
using ET.SchoolBus.Application.DTOs.Request;
using ET.SchoolBus.Data.Repositories.Interfaces;
using ET.SchoolBus.Domain.Entities;
using ET.SchoolBus.Pack.Enumerations;
using FluentValidation;
using ET.SchoolBus.Pack.Extensions;

namespace ET.SchoolBus.Application.Validators;

public class ProfessionNameValidator : AbstractValidator<string>
{
    public ProfessionNameValidator()
    {
        RuleFor(x => x)
            .NotEmpty().WithMessage("Meslek adı boş olamaz.")
            .MaximumLength(100).WithMessage("Meslek adı en fazla 100 karakter olabilir.");
    }
}

public class CreateProfessionValidator : AbstractValidator<ProfessionCreateDto>
{
    private readonly IProfessionRepository _professionRepository;

    public CreateProfessionValidator(IProfessionRepository professionRepository)
    {
        _professionRepository = professionRepository;

        RuleFor(x => x.Name)
            .SetValidator(new ProfessionNameValidator())
            .MustAsync(async (professionName, _) =>
            {
                return !await _professionRepository.ProfessionExistsByNameOnCreate(professionName.ToUpperByCulture(Culture.TR));
            }).WithMessage("Bu isimde bir meslek zaten kayıtlıdır.");
    }
}

public class UpdateProfessionValidator : AbstractValidator<ProfessionUpdateDto>
{
    private readonly IProfessionRepository _professionRepository;

    public UpdateProfessionValidator(IProfessionRepository professionRepository)
    {
        _professionRepository = professionRepository;

        RuleFor(x => x.Name)
            .SetValidator(new ProfessionNameValidator());

        RuleFor(x => x)
            .MustAsync(async (profession, _) =>
            {
                return !await _professionRepository.ProfessionExistsByNameOnUpdate(profession.ProfessionId ,profession.Name.ToUpperByCulture(Culture.TR));
            }).WithMessage("Bu isimde bir meslek zaten kayıtlıdır.");
            
    }
}
