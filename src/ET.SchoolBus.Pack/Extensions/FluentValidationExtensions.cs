using System;
using FluentValidation.Results;

namespace ET.SchoolBus.Pack.Extensions;

public static class FluentValidationExtensions
{
    public static List<string> GetErrorMessages(this ValidationResult validationResult)
    {
        return validationResult.Errors.Select(x => x.ErrorMessage).ToList();
    }
}
