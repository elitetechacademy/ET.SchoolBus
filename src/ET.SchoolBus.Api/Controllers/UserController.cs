
using ET.SchoolBus.Application.DTOs.Request;
using ET.SchoolBus.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ET.SchoolBus.Api.Controllers;

[Route("user")]
public class UserController : ApiController
{
    private readonly ILoginService _loginService;

    public UserController(ILoginService loginService)
    {
        _loginService = loginService;
    }

    [HttpPost("sign-in")]
    public async Task<ActionResult> SignIn(LoginRequestDto loginRequest)
    {
        return CustomResponse(await _loginService.SignIn(loginRequest));
    }
}
