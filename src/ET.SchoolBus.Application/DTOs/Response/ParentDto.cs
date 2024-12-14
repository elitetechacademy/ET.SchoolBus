using System;

namespace ET.SchoolBus.Application.DTOs.Response;

public class ParentDto
{
    public int ParentId { get; set; } //Primary Key
    public string Name { get; set; }
    public string Surname { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
}
