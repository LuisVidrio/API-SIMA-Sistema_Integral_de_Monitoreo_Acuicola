namespace WebApi.Models.Users;

using WebApi.Entities;

public class NotificationToken_Response
{

    public string mssg { get; set; }
    public User user {get; set;}
    public NotificationToken_Response(string mssg,User user)
    {
        this.mssg = mssg;
        this.user = user;

    }
}