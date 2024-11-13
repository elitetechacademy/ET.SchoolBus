
using ET.SchoolBus.Api.Controllers;
using ET.SchoolBus.Application.DTOs.Request;
using ET.SchoolBus.Application.Interfaces;
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
    public async Task<ActionResult> GetAll()
    {
        var result = await _brandService.GetAllAsync();
        return CustomResponse(result);
    }

    [HttpGet("get-by-id/{id:int}")]
    public async Task<ActionResult> GetById(int id)
    {
        var result = await _brandService.GetByIdAsync(id);
        return CustomResponse(result);
    }

    [HttpPost("create")]
    public async Task<ActionResult> Create([FromBody] BrandCreateDto brandCreateDto)
    {
        var result = await _brandService.AddBrandAsync(brandCreateDto);
        return CustomResponse(result);
    }

    [HttpPut("update")]
    public async Task<ActionResult> Update([FromBody] BrandUpdateDto brandUpdateDto)
    {
        var result = await _brandService.UpdateBrandAsync(brandUpdateDto);
        return CustomResponse(result);
    }

    [HttpDelete("delete/{id:int}")]
    public async Task<ActionResult> Delete(int id)
    {
        var result = await _brandService.DeleteBrandAsync(id);
        return CustomResponse(result);
    }
}
