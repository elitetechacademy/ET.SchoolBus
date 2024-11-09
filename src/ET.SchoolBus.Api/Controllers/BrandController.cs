
using System.Diagnostics;
using ET.SchoolBus.Data.Context;
using ET.SchoolBus.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("brand")]
public class BrandController : ControllerBase
{
    private readonly SchoolBusContext _schoolBusContext;
    private readonly ILogger<BrandController> _logger;

    public BrandController(SchoolBusContext schoolBusContext, ILogger<BrandController> logger)
    {
        _schoolBusContext = schoolBusContext;
        _logger = logger;
    }

    [HttpGet("get-all")]
    public async Task<ActionResult> GetAll()
    {
        var brands = await _schoolBusContext.Brands.ToListAsync();
        return Ok(brands);
    }

    [HttpGet("get-by-id/{id:int}")]
    public async Task<ActionResult> GetById(int id)
    {
        var brand = await _schoolBusContext.Brands.FindAsync(id);

        if (brand is null)
            return NotFound($"{id} numaralı kayıt bulunamadı.");
        else
            return Ok(brand);
    }

    [HttpPost("create")]
    public async Task<ActionResult> Create([FromBody] Brand brand)
    {
        try
        {
            await _schoolBusContext.Brands.AddAsync(brand);
            int numRows = await _schoolBusContext.SaveChangesAsync();
            return Ok($"{numRows} adet kayıt eklendi.");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"BrandController => Create : Kayıt eklenirken bir hata oluştu.");
            return BadRequest($"Kayıt eklenirken bir hata oluştu.");
        }
    }

    [HttpPut("update")]
    public async Task<ActionResult> Update([FromBody] Brand brand)
    {
        var existsBrand = await _schoolBusContext.Brands.FindAsync(brand.BrandId);
        if(existsBrand is null)
        {
            return NotFound($"{brand.BrandId} nolu kayıt bulunamadı.");
        }

        existsBrand.BrandName = brand.BrandName;
        existsBrand.UpdatedTime = DateTime.Now;
        existsBrand.UpdatedUser = "admin";

        try
        {
            _schoolBusContext.Brands.Update(existsBrand);
            int numRows = await _schoolBusContext.SaveChangesAsync();
            return Ok($"{numRows} adet kayıt güncellendi.");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"BrandController => Update : Kayıt güncellenirken bir hata oluştu.");
            return BadRequest($"Kayıt güncellenirken bir hata oluştu.");
        }
    }
}
