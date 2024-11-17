using System;
using ET.SchoolBus.Application.DTOs.Request;
using ET.SchoolBus.Application.DTOs.Response;
using ET.SchoolBus.Application.Wrapper;

namespace ET.SchoolBus.Application.Services.Interfaces;

public interface ILoginService
{
    Task<Result> SignIn(LoginRequestDto loginRequest);
}
