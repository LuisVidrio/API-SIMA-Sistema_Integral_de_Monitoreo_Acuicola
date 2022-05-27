namespace WebApi.Models.Ponds;

using System.ComponentModel.DataAnnotations;
using WebApi.Entities;
public class CreateIOT_DeviceResponse
{
    public string Id { get; set; }

    public CreateIOT_DeviceResponse(IOT_Device iotDevice, string mssg, string errorM)
    {
        Id = iotDevice.Id;
    }
}