namespace WebApi.Models.Users;

using System.ComponentModel.DataAnnotations;
using WebApi.Entities;


public class AuthenticateSingupRequest
{
    [Required]
    public string Username { get; set; }

    [Required]
    public string Password { get; set; }

     [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }

     [Required]
    public Role Role { get; set; }

}