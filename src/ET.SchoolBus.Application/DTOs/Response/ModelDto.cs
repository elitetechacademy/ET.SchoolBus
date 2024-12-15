using System;

namespace ET.SchoolBus.Application.DTOs.Response;

public class ModelDto
{
    public int ModelId { get; set; }
    public string ModelName { get; set; }
    public BrandDto Brand { get; set; }
}
