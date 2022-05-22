namespace WebApi.Models.Ponds;

using System.ComponentModel.DataAnnotations;
using WebApi.Entities;


public class CreateIOT_DeviceRequest
{
    [Required]
    public int IOT_ModuleId { get; set; }

    public Parameter Parameter { get; set; }

}