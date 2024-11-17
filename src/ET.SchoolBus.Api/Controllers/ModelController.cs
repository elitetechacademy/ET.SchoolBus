
using ET.SchoolBus.Api.Controllers;
using ET.SchoolBus.Application.DTOs.Request;
using ET.SchoolBus.Application.Interfaces;
using ET.SchoolBus.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

[Route("model")]
public class ModelController : ApiController
{    
    private readonly IModelService _modelService;

    public ModelController(IModelService modelService)
    {
        _modelService = modelService;
    }

    [HttpGet("get-all")]
    public async Task<ActionResult> GetAll()
    {
        var result = await _modelService.GetAllAsync();
        return CustomResponse(result);
    }

    [HttpGet("get-by-id/{id:int}")]
    public async Task<ActionResult> GetById(int id)
    {
        var result = await _modelService.GetByIdAsync(id);
        return CustomResponse(result);
    }

    [HttpGet("get-by-brand/{id:int}")]
    public async Task<ActionResult> GetByBrandId(int id)
    {
        var result = await _modelService.GetAllByBrandIdAsync(id);
        return CustomResponse(result);
    }

    [HttpPost("create")]
    public async Task<ActionResult> Create([FromBody] ModelCreateDto modelCreateDto)
    {
        var result = await _modelService.AddModelAsync(modelCreateDto);
        return CustomResponse(result);
    }

    [HttpPut("update")]
    public async Task<ActionResult> Update([FromBody] ModelUpdateDto modelUpdateDto)
    {
        var result = await _modelService.UpdateModelAsync(modelUpdateDto);
        return CustomResponse(result);
    }

    [HttpDelete("delete/{id:int}")]
    public async Task<ActionResult> Delete(int id)
    {
        var result = await _modelService.DeleteModelAsync(id);
        return CustomResponse(result);
    }
}
