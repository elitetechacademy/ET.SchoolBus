using System;
using AutoMapper;
using ET.SchoolBus.Application.DTOs.Request;
using FluentValidation;

namespace ET.SchoolBus.Application.Validators;

public class LoginRequestValidator : AbstractValidator<LoginRequestDto>
{
    public LoginRequestValidator()
    {
        RuleFor(x => x.UserName)
            .NotEmpty().WithMessage("Kullanıcı adı boş olamaz.")
            .MaximumLength(10).WithMessage("Kullanıcı adı en fazla 10 karakter olabilir.");
        
        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Parola bilgisi boş olamaz.");
    }
}
