namespace WebApi.Models.Users;

using System.ComponentModel.DataAnnotations;

public class NotificationToken_Request
{
    [Required]
    public int id { get; set; }

    [Required]
    public string token { get; set; }
}