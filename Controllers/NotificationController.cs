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

    public NotificationController(IMobileMessagingClient mobile)
    {
        messaging = mobile.getMessaging();
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
    [HttpGet]
    public IActionResult sendPush()
    {
        var result = messaging.SendAsync(CreateNotification("hi", "im sending a notification", "f5oCbVCKGvkzXfh6O_0lPQ:APA91bEIFHALNwIixOQyLth5U1ktO9jdKKAorRxEVQ8Sx-bKM0sFuu8kwSTK-mXrK60HEjnSi9yXSkEb5Rkoj3uA1uWj_5PtHSablpIV8K1tnSV9cSWZUhr1HnVhgLMYBQsVEF3nRw-V"));

        //var response = _pondService.Add(model);
        return Ok(result);
    }
  
}