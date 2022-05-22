namespace WebApi.Controllers;

using Microsoft.AspNetCore.Mvc;
using WebApi.Authorization;
using WebApi.Entities;
using WebApi.Models.Ponds;
using WebApi.Services;

[Authorize]
[ApiController]
[Route("[controller]")]
public class IOT_DeviceController : ControllerBase
{
    private I_IOT_DeviceService _iotDeviceService;

    public IOT_DeviceController(I_IOT_DeviceService iotDeviceService)
    {
        _iotDeviceService = iotDeviceService;
    }

    [AllowAnonymous]
    [HttpPost("[action]")]
    public IActionResult Create(CreateIOT_DeviceRequest model)
    {
        Console.WriteLine("in CREATE");
        var response = _iotDeviceService.Add(model);
        return Ok(response);
    }
    [HttpGet]
    public IActionResult GetAll()
    {
        var ponds = _iotDeviceService.GetAll();
        return Ok(ponds);
    }
    [AllowAnonymous]
    [HttpGet("{id:int}")]
    public IActionResult GetById(int id)
    {
        // only admins can access other user records
        var pond =  _iotDeviceService.GetById(id);
        return Ok(pond);
    }
    [HttpDelete("{id:int}")]
     public IActionResult Delete(int id)
    {
        // only admins can access other user

        var pond =  _iotDeviceService.Delete(id);
        return Ok(pond);
    }
    [AllowAnonymous]
    [HttpPut("[action]")]
       public IActionResult Update(IOT_Device model)
    {
        // only admins can access other user records
        var pond =  _iotDeviceService.Update(model);

        return Ok(pond);
    }
}