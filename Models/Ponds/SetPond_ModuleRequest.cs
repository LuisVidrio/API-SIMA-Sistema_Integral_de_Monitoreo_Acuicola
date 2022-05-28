namespace WebApi.Models.Ponds;

using System.ComponentModel.DataAnnotations;
using WebApi.Entities;


public class SetPond_ModuleRequest
{
    [Required]
    public int Id {get;set;}
    public int pondId {get; set;}

}