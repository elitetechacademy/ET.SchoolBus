using System;

namespace ET.SchoolBus.Application.DTOs.Request;

public class LoginRequestDto
{
    public string UserName { get; set; }
    public string Password { get; set; }
    public int TenantId { get; set; }
}
