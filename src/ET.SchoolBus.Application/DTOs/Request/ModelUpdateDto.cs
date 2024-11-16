using System;

namespace ET.SchoolBus.Application.DTOs.Request;

public class ModelUpdateDto
{
    public int ModelId { get; set; }
    public int BrandId { get; set; }
    public string ModelName { get; set; }
}
