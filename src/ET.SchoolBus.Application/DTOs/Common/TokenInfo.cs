using System;
using System.ComponentModel.DataAnnotations;

namespace ET.SchoolBus.Application.DTOs.Common;

public class TokenInfo
{
    public string Token { get; set; } = string.Empty;
    public DateTime ExpireDate { get; set; }
}
