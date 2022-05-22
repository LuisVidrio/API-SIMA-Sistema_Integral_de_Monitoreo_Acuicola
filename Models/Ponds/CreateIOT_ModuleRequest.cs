namespace WebApi.Models.Ponds;

using System.ComponentModel.DataAnnotations;
using WebApi.Entities;


public class CreateIOT_ModuleRequest
{

    [Required]
    public int PondId { get; set; }

}