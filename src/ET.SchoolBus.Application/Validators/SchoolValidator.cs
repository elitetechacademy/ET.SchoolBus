using ET.SchoolBus.Application.DTOs.Request;
using ET.SchoolBus.Data.Repositories.Interfaces;
using ET.SchoolBus.Pack.Enumerations;
using ET.SchoolBus.Pack.Extensions;
using FluentValidation;

namespace ET.SchoolBus.Application.Validators;


public class SchoolNameValidator : AbstractValidator<string>
{
    public SchoolNameValidator()
    {
        RuleFor(x => x)
            .NotEmpty().WithMessage("Marka adı boş olamaz.")
            .MaximumLength(100).WithMessage("Marka adı en fazla 100 karakter olabilir.");
    }
}

public class StudentCountValidator : AbstractValidator<int>
{
    public StudentCountValidator()
    {
        RuleFor(x => x)
            .NotEmpty().WithMessage("Öğrenci sayısı 0 dan büyük olmalıdır");
    }
}

public class StartYearValidator : AbstractValidator<int>
{
    public StartYearValidator()
    {
        RuleFor(x => x)
            .GreaterThanOrEqualTo(1923).WithMessage("Açılış yılı 1923 sonrası olmalıdır")
            .LessThanOrEqualTo(DateTime.Now.Year).WithMessage("Açılış yılı içinde bulunduğumuz yıldan büyük olamaz");
    }
}

public class CreateSchoolValidator : AbstractValidator<SchoolCreateDto>
{
    private readonly ISchoolRepository _schoolRepository;

    public CreateSchoolValidator(ISchoolRepository SchoolRepository)
    {
        _schoolRepository = SchoolRepository;

        RuleFor(x => x.SchoolName)
            .SetValidator(new SchoolNameValidator())
            .MustAsync(async (schoolName, _) =>
            {
                return !await _schoolRepository.SchoolExistsByNameOnCreate(schoolName.ToUpperByCulture(Culture.TR));
            }).WithMessage("Bu isimde bir okul zaten kayıtlıdır.");

        RuleFor(x => x.StudentCount)
       .SetValidator(new StudentCountValidator());

        RuleFor(x => x.StartYear)
       .SetValidator(new StartYearValidator());

    }
}

public class UpdateSchoolValidator : AbstractValidator<SchoolUpdateDto>
{
    private readonly ISchoolRepository _schoolRepository;

    public UpdateSchoolValidator(ISchoolRepository schoolRepository)
    {
        _schoolRepository = schoolRepository;

        RuleFor(x => x.SchoolName)
            .SetValidator(new SchoolNameValidator());

        RuleFor(x => x.SchoolId)
        .MustAsync(async (SchoolId, _) =>
        {
            return await _schoolRepository.AnyAsync(x => x.SchoolId == SchoolId);
        }).WithMessage(School => $"{School.SchoolId} numaralı kayıt bulunamadı");

        RuleFor(x => x)
            .MustAsync(async (School, _) =>
            {
                return !await _schoolRepository.SchoolExistsByNameOnUpdate(School.SchoolId,
                    School.SchoolName.ToUpperByCulture(Culture.TR));
            }).WithMessage("Bu isimde bir okul zaten kayıtlıdır.");

        RuleFor(x => x.StudentCount)
        .SetValidator(new StudentCountValidator());

        RuleFor(x => x.StartYear)
      .SetValidator(new StartYearValidator());
    }
}
