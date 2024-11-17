using System;

namespace ET.SchoolBus.Application.DTOs.Response;

public class LoginResponseDto
{
    public int UserId { get; set; }
    public string Token { get; set; }
    public DateTime ExpireDate { get; set; }
}
