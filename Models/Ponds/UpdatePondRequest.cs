namespace WebApi.Models.Ponds;

using System.ComponentModel.DataAnnotations;
using WebApi.Entities;


public class UpdatePondRequest
{
    [Required]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }

    [Required]
    public int Altitude { get; set; }

     [Required]
    public int Longitud { get; set; }

}