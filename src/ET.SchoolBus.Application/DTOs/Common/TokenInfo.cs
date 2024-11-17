using System;

namespace ET.SchoolBus.Application.DTOs.Common;

public class TokenInfo
{
    public string Token { get; set; }
    public DateTime ExpireDate { get; set; }
}
