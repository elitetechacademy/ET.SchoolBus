using System;

namespace ET.SchoolBus.Application.DTOs.Request;

public class ParentCreateDto
{
    public int ProfessionId { get; set; } //Foreign Key
    public int SchoolId { get; set; } //Foreign Key
    public string Name { get; set; }
    public string Surname { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
}
