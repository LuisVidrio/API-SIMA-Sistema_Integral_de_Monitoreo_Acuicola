namespace WebApi.Controllers;

using Microsoft.AspNetCore.Mvc;
using WebApi.Authorization;
using WebApi.Entities;
using WebApi.Models.Ponds;
using WebApi.Services;

[Authorize]
[ApiController]
[Route("[controller]")]
public class IOT_ValuesController : ControllerBase
{
    private I_IOT_ValuesService _iotValuesService;

    public IOT_ValuesController(I_IOT_ValuesService iotValuesService)
    {
        _iotValuesService = iotValuesService;
    }
    [AllowAnonymous]
    [HttpGet("{id:int}")]
    public IActionResult GetAllByPondId(int id)
    {
        var values = _iotValuesService.GetByPondId(id);
        return Ok(values);
    }/*
    [AllowAnonymous]
    [HttpGet("{id:int}")]
    public IActionResult GetById(int id)
    {
        // only admins can access other user records
        var pond =  _iotValuesService.GetById(id);
        return Ok(pond);
    }
    [HttpDelete("{id:int}")]
     public IActionResult Delete(int id)
    {
        // only admins can access other user

        var pond =  _iotValuesService.Delete(id);
        return Ok(pond);
    }
    [AllowAnonymous]
    [HttpPut("[action]")]
       public IActionResult Update(IOT_Value model)
    {
        // only admins can access other user records
        var pond =  _iotValuesService.Update(model);

        return Ok(pond);
    }*/
}