
using ET.SchoolBus.Api.Controllers;
using ET.SchoolBus.Api.CustomAttributes;
using ET.SchoolBus.Application.DTOs.Request;
using ET.SchoolBus.Application.Interfaces;
using ET.SchoolBus.Application.Services.Implementations;
using ET.SchoolBus.Domain.Enumerations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Route("season")]
public class SeasonController : ApiController
{
    private readonly ISeasonService _seasonService;

    public SeasonController(ISeasonService seasonService)
    {
        _seasonService = seasonService;
    }

    [HttpGet("get-all")]
    public async Task<ActionResult> GetAll()
    {
        var result = await _seasonService.GetAllAsync();
        return CustomResponse(result);
    }

    [HttpGet("get-by-id/{id:int}")]
    public async Task<ActionResult> GetById(int id)
    {
        var result = await _seasonService.GetByIdAsync(id);
        return CustomResponse(result);
    }

    [HttpPost("create")]
    public async Task<ActionResult> Create([FromBody] SeasonCreateDto seasonCreateDto)
    {
        var result = await _seasonService.AddSeasonAsync(seasonCreateDto);
        return CustomResponse(result);
    }

    [HttpPut("update")]
    public async Task<ActionResult> Update([FromBody] SeasonUpdateDto seasonUpdateDto)
    {
        var result = await _seasonService.UpdateSeasonAsync(seasonUpdateDto);
        return CustomResponse(result);
    }

    [HttpDelete("delete/{id:int}")]
    public async Task<ActionResult> Delete(int id)
    {
        var result = await _seasonService.DeleteSeasonAsync(id);
        return CustomResponse(result);
    }
}
