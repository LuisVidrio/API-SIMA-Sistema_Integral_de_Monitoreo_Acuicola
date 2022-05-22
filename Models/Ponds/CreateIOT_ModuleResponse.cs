namespace WebApi.Models.Ponds;

using System.ComponentModel.DataAnnotations;
using WebApi.Entities;
public class CreateIOT_ModuleResponse
{
    public int Id { get; set; }

    public CreateIOT_ModuleResponse(IOT_Module iotModule, string mssg, string errorM)
    {
        Id = iotModule.Id;
    }
}