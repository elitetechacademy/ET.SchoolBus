using System;
using ET.SchoolBus.Integration.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ET.SchoolBus.Api.Controllers;


public class TestController : ControllerBase
{
    private readonly ICypherService _cypherService;

    public TestController(ICypherService cypherService)
    {
        _cypherService = cypherService;
    }

    [HttpGet("decode/{text}")]
    public IActionResult Decode(string text)
    {
        return Ok(_cypherService.Decrypte(text));
    }

    [HttpGet("encode/{text}")]
    public IActionResult Encode(string text)
    {
        return Ok(_cypherService.Encrypte(text));
    }
}
