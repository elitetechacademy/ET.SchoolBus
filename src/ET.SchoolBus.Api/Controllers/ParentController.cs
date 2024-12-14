
using ET.SchoolBus.Api.Controllers;
using ET.SchoolBus.Api.CustomAttributes;
using ET.SchoolBus.Application.DTOs.Request;
using ET.SchoolBus.Application.Interfaces;
using ET.SchoolBus.Application.Services.Interfaces;
using ET.SchoolBus.Domain.Enumerations;
using Microsoft.AspNetCore.Mvc;

[Route("parent")]
public class ParentController : ApiController
{    
    private readonly IParentService _parentService;

    public ParentController(IParentService parentService)
    {
        _parentService = parentService;
    }

    [HttpGet("get-all")]
    [Permission(Roles.SuperAdmin, Roles.Admin, Roles.User)]
    public async Task<ActionResult> GetAll()
    {
        var result = await _parentService.GetAllAsync();
        return CustomResponse(result);
    }

    [HttpGet("get-by-id/{id:int}")]
    [Permission(Roles.SuperAdmin, Roles.Admin, Roles.User)]
    public async Task<ActionResult> GetById(int id)
    {
        var result = await _parentService.GetByIdAsync(id);
        return CustomResponse(result);
    }

    [HttpGet("get-by-profession/{id:int}")]
    [Permission(Roles.SuperAdmin, Roles.Admin, Roles.User)]
    public async Task<ActionResult> GetByProfessionId(int id)
    {
        var result = await _parentService.GetAllByProfessionIdAsync(id);
        return CustomResponse(result);
    }

    [HttpGet("get-by-school/{id:int}")]
    [Permission(Roles.SuperAdmin, Roles.Admin, Roles.User)]
    public async Task<ActionResult> GetBySchoolId(int id)
    {
        var result = await _parentService.GetAllBySchoolIdAsync(id);
        return CustomResponse(result);
    }

    [HttpPost("create")]
    [Permission(Roles.SuperAdmin, Roles.Admin)]
    public async Task<ActionResult> Create([FromBody] ParentCreateDto parentCreateDto)
    {
        var result = await _parentService.AddParentAsync(parentCreateDto);
        return CustomResponse(result);
    }

    [HttpPut("update")]
    [Permission(Roles.SuperAdmin, Roles.Admin)]
    public async Task<ActionResult> Update([FromBody] ParentUpdateDto parentUpdateDto)
    {
        var result = await _parentService.UpdateParentAsync(parentUpdateDto);
        return CustomResponse(result);
    }

    [HttpDelete("delete/{id:int}")]
    [Permission(Roles.SuperAdmin)]
    public async Task<ActionResult> Delete(int id)
    {
        var result = await _parentService.DeleteParentAsync(id);
        return CustomResponse(result);
    }
}
