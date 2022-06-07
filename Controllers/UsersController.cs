namespace WebApi.Controllers;

using Microsoft.AspNetCore.Mvc;
using WebApi.Authorization;
using WebApi.Entities;
using WebApi.Models.Users;
using WebApi.Services;

[Authorize]
[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [AllowAnonymous]
    [HttpPost("[action]")]
    public IActionResult Authenticate(AuthenticateRequest model)
    {
        var response = _userService.Authenticate(model);
        return Ok(response);
    }

    [AllowAnonymous]
    [HttpPost("[action]")]
    public IActionResult AuthenticateSingup(AuthenticateSingupRequest model)
    {
        var response = _userService.AuthenticateSingup(model);
        return Ok(response);
    }

    [Authorize(Role.Admin)]
    [HttpGet]
    public IActionResult GetAll()
    {
        var users = _userService.GetAll();
        return Ok(users);
    }

    [AllowAnonymous]
    public IActionResult GetById(int id)
    {
        // only admins can access other user records
        var user =  _userService.GetById(id);

        return Ok(user);
    }


    [AllowAnonymous]
    [HttpPost("[action]")]
    public IActionResult setNotificationToken(NotificationToken_Request model)
    {
        // only admins can access other user records
        var user =  _userService.setNotificationToken(model);

        return Ok(user);
    }
    [HttpGet("[action]")]
    public IActionResult GetAllFood()
    {
        Console.Write("helllo");
        var food =  _userService.GetAllFood(HttpContext);
        return Ok(food);
    }

     [HttpPost("createfood")]
    public IActionResult CreateFood(CreateFoodRequest model)
    {
        Console.Write("helllo");
        var food =  _userService.CreateFood(model);
        return Ok(food);
    }


     [HttpDelete("Delete/{userId:int}")]
    public IActionResult DeleteUser(int userId )
    {
        Console.Write("helllo");
        var food =  _userService.DeleteUser(userId);
        return Ok(food);
    }

     [HttpPut("update")]
    public IActionResult UpdateUser(User model)
    {
        Console.Write("helllo");
        var food =  _userService.Update(model);
        return Ok(food);
    }


}