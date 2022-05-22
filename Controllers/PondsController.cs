namespace WebApi.Controllers;

using Microsoft.AspNetCore.Mvc;
using WebApi.Authorization;
using WebApi.Entities;
using WebApi.Models.Ponds;
using WebApi.Services;

[Authorize]
[ApiController]
[Route("[controller]")]
public class PondsController : ControllerBase
{
    private IPondService _pondService;

    public PondsController(IPondService pondService)
    {
        _pondService = pondService;
    }

    [AllowAnonymous]
    [HttpPost("[action]")]
    public IActionResult Create(CreatePondRequest model)
    {
        Console.WriteLine("in CREATE");
        var response = _pondService.Add(model);
        return Ok(response);
    }
    [HttpGet]
    public IActionResult GetAll()
    {
        var ponds = _pondService.GetAll();
        return Ok(ponds);
    }
    [AllowAnonymous]
    [HttpGet("{id:int}")]
    public IActionResult GetById(int id)
    {
        // only admins can access other user records
        var pond =  _pondService.GetById(id);
        return Ok(pond);
    }
    [HttpDelete("{id:int}")]
     public IActionResult Delete(int id)
    {
        // only admins can access other user

        var pond =  _pondService.Delete(id);
        return Ok(pond);
    }
    [AllowAnonymous]
    [HttpPut("[action]")]
       public IActionResult Update(Pond model)
    {
        // only admins can access other user records
        var pond =  _pondService.Update(model);

        return Ok(pond);
    }
}