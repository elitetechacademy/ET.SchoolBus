using ET.SchoolBus.Application.DTOs.Request;
using ET.SchoolBus.Data.Repositories.Implementations;
using ET.SchoolBus.Data.Repositories.Interfaces;
using ET.SchoolBus.Domain.Entities;
using ET.SchoolBus.Pack.Enumerations;
using ET.SchoolBus.Pack.Extensions;
using FluentValidation;

namespace ET.SchoolBus.Application.Validators;


public class SeasonNameValidator : AbstractValidator<string>
{
    public SeasonNameValidator()
    {
        RuleFor(x => x)
            .NotEmpty().WithMessage("Sezon adı boş olamaz.")
            .MaximumLength(100).WithMessage("Sezon adı en fazla 100 karakter olabilir.");
    }
}

public class CreateSeasonValidator : AbstractValidator<SeasonCreateDto>
{
    private readonly ISeasonRepository _seasonRepository;

    public CreateSeasonValidator(ISeasonRepository seasonRepository)
    {
        _seasonRepository = seasonRepository;

        RuleFor(x => x.Name)
            .SetValidator(new SeasonNameValidator())
            .MustAsync(async (seasonName, _) =>
            {
                return !await _seasonRepository.SeasonExistsByNameOnCreate(seasonName.ToUpperByCulture(Culture.TR));
            }).WithMessage("Bu isimde bir Sezon zaten kayıtlıdır.")
            ;
    }
}

public class UpdateSeasonValidator : AbstractValidator<SeasonUpdateDto>
{
    private readonly ISeasonRepository _seasonRepository;

    public UpdateSeasonValidator(ISeasonRepository seasonRepository)
    {
        _seasonRepository = seasonRepository;

        RuleFor(x => x.Name)
            .SetValidator(new SeasonNameValidator());

        RuleFor(x => x.SeasonId)
        .MustAsync(async (seasonId, _) => {
            return await _seasonRepository.AnyAsync(x => x.SeasonId == seasonId);
        }).WithMessage(Season => $"{Season.SeasonId} numaralı kayıt bulunamadı");

        RuleFor(x => x)
            .MustAsync(async (season, _) =>
            {
                return !await _seasonRepository.SeasonExistsByNameOnUpdate(season.SeasonId,
                    season.Name.ToUpperByCulture(Culture.TR));
            }).WithMessage("Bu isimde bir sezon zaten kayıtlıdır.");
    }
}
