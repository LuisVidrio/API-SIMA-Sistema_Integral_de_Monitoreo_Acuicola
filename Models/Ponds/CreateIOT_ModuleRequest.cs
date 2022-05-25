namespace WebApi.Models.Ponds;

using System.ComponentModel.DataAnnotations;
using WebApi.Entities;


public class CreateIOT_ModuleRequest
{
    public string serialId { get; set; }
    public string version { get; set; }
    public string CPU {get; set; }

}