using ET.SchoolBus.Application.DTOs.Request;
using ET.SchoolBus.Data.Repositories.Interfaces;
using ET.SchoolBus.Domain.Entities;
using ET.SchoolBus.Pack.Enumerations;
using ET.SchoolBus.Pack.Extensions;
using FluentValidation;

namespace ET.SchoolBus.Application.Validators;


public class ParentNameValidator : AbstractValidator<string>
{
    public ParentNameValidator()
    {
        RuleFor(x => x)
            .NotEmpty().WithMessage("Veli adı boş olamaz.")
            .MaximumLength(30).WithMessage("Veli adı en fazla 30 karakter olabilir.");
    }
}

public class ParentSurNameValidator : AbstractValidator<string>
{
    public ParentSurNameValidator()
    {
        RuleFor(x => x)
            .NotEmpty().WithMessage("Veli soyadı boş olamaz.")
            .MaximumLength(30).WithMessage("Veli soyadı en fazla 30 karakter olabilir.");
    }
}

public class CreateParentValidator : AbstractValidator<ParentCreateDto>
{
    private readonly IParentRepository _parentRepository;
    private readonly ISchoolRepository _schoolRepository;

    public CreateParentValidator(IParentRepository parentRepository, ISchoolRepository schoolRepository)
    {
        _parentRepository = parentRepository;
        _schoolRepository = schoolRepository;

        RuleFor(x => x)
            .MustAsync(async (model, _) =>
            {
                return !await _parentRepository.ParentExistsByNameOnCreate(model.SchoolId, model.Name, model.Surname);
            }).WithMessage("Bu isimde bir Veli zaten kayıtlıdır.")
            .MustAsync(async (model, _) =>
            {
                return await _schoolRepository.AnyAsync(x => x.SchoolId == model.SchoolId);
            }).WithMessage("Okul bulunamadı.");

        RuleFor(x => x.Name)
            .SetValidator(new ParentNameValidator());

        RuleFor(x => x.Surname)
           .SetValidator(new ParentSurNameValidator());
    }
}

public class UpdateParentValidator : AbstractValidator<ParentUpdateDto>
{
    private readonly IParentRepository _parentRepository;
    private readonly ISchoolRepository _schoolRepository;

    public UpdateParentValidator(IParentRepository parentRepository, ISchoolRepository schoolRepository)
    {
        _parentRepository = parentRepository;
        _schoolRepository = schoolRepository;

        RuleFor(x => x.Name)
            .SetValidator(new ParentNameValidator());

        RuleFor(x => x.Surname)
          .SetValidator(new ParentSurNameValidator());

        RuleFor(x => x.ParentId)
        .MustAsync(async (parentId, _) =>
        {
            return await _parentRepository.AnyAsync(x => x.ParentId == parentId);
        }).WithMessage(model => $"{model.ParentId} numaralı kayıt bulunamadı");

        RuleFor(x => x)
            .MustAsync(async (model, _) =>
            {
                return !await _parentRepository.ParentExistsByNameOnUpdate(model.ParentId,
                    model.SchoolId, model.Name.ToUpperByCulture(Culture.TR), model.Surname.ToUpperByCulture(Culture.TR));
            }).WithMessage("Bu isimde bir Veli zaten kayıtlıdır.")
            .MustAsync(async (model, _) =>
            {
                return !await _parentRepository.AnyAsync(x => x.SchoolId == model.SchoolId);
            }).WithMessage("Okul bulunamadı.");
        
    }
}
