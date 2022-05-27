namespace WebApi.Models.Ponds;

using System.ComponentModel.DataAnnotations;
using WebApi.Entities;


public class CreateIOT_DeviceRequest
{
    [Required]
    public string id { get; set; }
    public Parameter parameter { get; set; }
    public string deviceType {get; set;}
    public int IOT_ModuleId {get;set;}

}