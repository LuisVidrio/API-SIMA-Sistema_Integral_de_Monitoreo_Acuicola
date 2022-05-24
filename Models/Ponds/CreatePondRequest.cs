namespace WebApi.Models.Ponds;

using System.ComponentModel.DataAnnotations;
using WebApi.Entities;


public class CreatePondRequest
{
    [Required]
    public String Name { get; set; }

    [Required]
    public int Altitude { get; set; }

     [Required]
    public int Longitud { get; set; }

}