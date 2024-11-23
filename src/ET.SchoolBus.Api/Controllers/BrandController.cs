
using ET.SchoolBus.Api.Controllers;
using ET.SchoolBus.Api.CustomAttributes;
using ET.SchoolBus.Application.DTOs.Request;
using ET.SchoolBus.Application.Interfaces;
using ET.SchoolBus.Domain.Enumerations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Route("brand")]
public class BrandController : ApiController
{    
    private readonly IBrandService _brandService;

    public BrandController(IBrandService brandService)
    {
        _brandService = brandService;
    }

    [HttpGet("get-all")]
    [Permission(Roles.SuperAdmin, Roles.Admin, Roles.User)]
    public async Task<ActionResult> GetAll()
    {
        var result = await _brandService.GetAllAsync();
        return CustomResponse(result);
    }

    [HttpGet("get-by-id/{id:int}")]
    [Permission(Roles.SuperAdmin, Roles.Admin, Roles.User)]
    public async Task<ActionResult> GetById(int id)
    {
        var result = await _brandService.GetByIdAsync(id);
        return CustomResponse(result);
    }

    [HttpPost("create")]
    [Permission(Roles.SuperAdmin, Roles.Admin)]
    public async Task<ActionResult> Create([FromBody] BrandCreateDto brandCreateDto)
    {
        var result = await _brandService.AddBrandAsync(brandCreateDto);
        return CustomResponse(result);
    }

    [HttpPut("update")]
    [Permission(Roles.SuperAdmin, Roles.Admin)]
    public async Task<ActionResult> Update([FromBody] BrandUpdateDto brandUpdateDto)
    {
        var result = await _brandService.UpdateBrandAsync(brandUpdateDto);
        return CustomResponse(result);
    }

    [HttpDelete("delete/{id:int}")]
    [Permission(Roles.SuperAdmin)]
    public async Task<ActionResult> Delete(int id)
    {
        var result = await _brandService.DeleteBrandAsync(id);
        return CustomResponse(result);
    }
}
