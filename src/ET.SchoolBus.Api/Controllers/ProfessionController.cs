
using ET.SchoolBus.Api.Controllers;
using ET.SchoolBus.Api.CustomAttributes;
using ET.SchoolBus.Application.DTOs.Request;
using ET.SchoolBus.Application.Interfaces;
using ET.SchoolBus.Application.Services.Interfaces;
using ET.SchoolBus.Domain.Enumerations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Route("profession")]
public class ProfessionController : ApiController
{    
    private readonly IProfessionService _professionService;

    public ProfessionController(IProfessionService professionService)
    {
        _professionService = professionService;
    }

    [HttpGet("get-all")]
    [Permission(Roles.SuperAdmin, Roles.Admin, Roles.User)]
    public async Task<ActionResult> GetAll()
    {
        var result = await _professionService.GetAllAsync();
        return CustomResponse(result);
    }

    [HttpGet("get-by-id/{id:int}")]
    [Permission(Roles.SuperAdmin, Roles.Admin, Roles.User)]
    public async Task<ActionResult> GetById(int id)
    {
        var result = await _professionService.GetByIdAsync(id);
        return CustomResponse(result);
    }

    [HttpPost("create")]
    [Permission(Roles.SuperAdmin, Roles.Admin)]
    public async Task<ActionResult> Create([FromBody] ProfessionCreateDto professionCreateDto)
    {
        var result = await _professionService.AddProfessionAsync(professionCreateDto);
        return CustomResponse(result);
    }

    [HttpPut("update")]
    [Permission(Roles.SuperAdmin, Roles.Admin)]
    public async Task<ActionResult> Update([FromBody] ProfessionUpdateDto professionUpdateDto)
    {
        var result = await _professionService.UpdateProfessionAsync(professionUpdateDto);
        return CustomResponse(result);
    }

    [HttpDelete("delete/{id:int}")]
    [Permission(Roles.SuperAdmin)]
    public async Task<ActionResult> Delete(int id)
    {
        var result = await _professionService.DeleteProfessionAsync(id);
        return CustomResponse(result);
    }
}
