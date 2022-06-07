namespace WebApi.Models.Users;

using System.ComponentModel.DataAnnotations;
using WebApi.Entities;


public class AuthenticateSingupRequest
{

    public string Username { get; set; }

    public string Password { get; set; }


    public string FirstName { get; set; }


    public string LastName { get; set; }


    public Role Role { get; set; }

}