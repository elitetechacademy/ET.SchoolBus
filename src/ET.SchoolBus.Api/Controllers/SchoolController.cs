
using ET.SchoolBus.Api.Controllers;
using ET.SchoolBus.Api.CustomAttributes;
using ET.SchoolBus.Application.DTOs.Request;
using ET.SchoolBus.Application.Interfaces;
using ET.SchoolBus.Domain.Enumerations;
using Microsoft.AspNetCore.Mvc;

[Route("school")]
public class SchoolController : ApiController
{    
    private readonly ISchoolService _schoolService;

    public SchoolController(ISchoolService schoolService)
    {
        _schoolService = schoolService;
    }

    [HttpGet("get-all")]
    [Permission(Roles.SuperAdmin, Roles.Admin, Roles.User)]
    public async Task<ActionResult> GetAll()
    {
        var result = await _schoolService.GetAllAsync();
        return CustomResponse(result);
    }

    [HttpGet("get-by-id/{id:int}")]
    [Permission(Roles.SuperAdmin, Roles.Admin, Roles.User)]
    public async Task<ActionResult> GetById(int id)
    {
        var result = await _schoolService.GetByIdAsync(id);
        return CustomResponse(result);
    }

    [HttpPost("create")]
    [Permission(Roles.SuperAdmin, Roles.Admin)]
    public async Task<ActionResult> Create([FromBody] SchoolCreateDto schoolCreateDto)
    {
        var result = await _schoolService.AddSchoolAsync(schoolCreateDto);
        return CustomResponse(result);
    }

    [HttpPut("update")]
    [Permission(Roles.SuperAdmin, Roles.Admin)]
    public async Task<ActionResult> Update([FromBody] SchoolUpdateDto schoolUpdateDto)
    {
        var result = await _schoolService.UpdateSchoolAsync(schoolUpdateDto);
        return CustomResponse(result);
    }

    [HttpDelete("delete/{id:int}")]
    [Permission(Roles.SuperAdmin)]
    public async Task<ActionResult> Delete(int id)
    {
        var result = await _schoolService.DeleteSchoolAsync(id);
        return CustomResponse(result);
    }
}
