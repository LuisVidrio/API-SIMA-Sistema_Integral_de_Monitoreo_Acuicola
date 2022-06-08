namespace WebApi.Controllers;

using Microsoft.AspNetCore.Mvc;
using WebApi.Authorization;
using WebApi.Entities;
using WebApi.Models.Ponds;
using WebApi.Services;

[Authorize]
[ApiController]
[Route("[controller]")]
public class IOT_ModuleController : ControllerBase
{
    private I_IOT_ModuleService _iotModuleService;

    public IOT_ModuleController(I_IOT_ModuleService iotModuleService)
    {
        _iotModuleService = iotModuleService;
    }

    [AllowAnonymous]
    [HttpPost("[action]")]
    public IActionResult Create(CreateIOT_ModuleRequest model)
    {
        Console.WriteLine("in CREATE");
        var response = _iotModuleService.Add(model);
        return Ok(response);
    }
    [HttpGet]
    public IActionResult GetAll()
    {
        var ponds = _iotModuleService.GetAll();
        return Ok(ponds);
    }
    [AllowAnonymous]
    [HttpGet("{id:int}")]
    public IActionResult GetById(int id)
    {
        // only admins can access other user records
        var pond =  _iotModuleService.GetById(id);
        return Ok(pond);
    }
    [HttpDelete("{id:int}")]
     public IActionResult Delete(int id)
    {
        // only admins can access other user

        var pond =  _iotModuleService.Delete(id);
        return Ok(pond);
    }
    [AllowAnonymous]
    [HttpPut("[action]")]
       public IActionResult Update(IOT_Module model)
    {
        // only admins can access other user records
        var pond =  _iotModuleService.Update(model);

        return Ok(pond);
    }
      [HttpPost("[action]")]
   public IActionResult SetPond(SetPond_ModuleRequest model)
    {
        var response = _iotModuleService.SetPond(model);
        return Ok(response);
    }
    [HttpGet("[action]")]
   public IActionResult getNotActive()
    {
        var response = _iotModuleService.getNotActive();
        return Ok(response);
    }
    [AllowAnonymous]
    [HttpPut("setConfig")]

     public IActionResult setModuleConfig(SetModuleConfigRequest model)
    {
        var response = _iotModuleService.SetModuleConfig(model);
        return Ok(response);
    }
}