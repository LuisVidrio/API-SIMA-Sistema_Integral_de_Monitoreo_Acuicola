namespace WebApi.Controllers;

using Microsoft.AspNetCore.Mvc;
using WebApi.Authorization;
using WebApi.Entities;
using WebApi.Models.Ponds;
using WebApi.Services;
using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;
using WebApi.Helpers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class NotificationController : ControllerBase
{
   // private IPondService _pondService;
    private  MobileMessagingClient _mobile;
    public FirebaseMessaging messaging;
    public DataContext _context;

    public NotificationController(IMobileMessagingClient mobile,DataContext context)
    {
        messaging = mobile.getMessaging();
        _context = context;
    }

    private Message CreateNotification(string title, string notificationBody, string token)
{
    return new Message()
    {
        Token = token,
        Notification = new Notification()
        {
            Body = notificationBody,
            Title = title
        }
    };
}

    [AllowAnonymous]
    [HttpGet("sendpush/{pondId:int}")]
    public IActionResult sendPush(int pondId)
    {
        Console.WriteLine("1");
        var message = "im sending a push notification";
        var topic = "Warning/Critic/Good";
        Console.WriteLine("2");
        var userId = _context.Ponds.FirstOrDefault(x => x.Id == pondId).UserId;
        Console.WriteLine("3");
        var notificationToken = _context.Users.FirstOrDefault(x => x.Id == userId).notificationToken;
        Console.WriteLine("4");
        var result = messaging.SendAsync(CreateNotification(topic, message, notificationToken));
        Console.WriteLine("5");


        return Ok(result);
    }
  
}