using System;
using ET.SchoolBus.Application.Wrapper;
using Microsoft.AspNetCore.Mvc;

namespace ET.SchoolBus.Api.Controllers;

public class ApiController : ControllerBase
{
    protected ActionResult CustomResponse(Result result)
    {
        if(result.IsSuccess)
        {
            return Ok(result);
        }
        else
        {
            return BadRequest(result);
        }
    }
}
