namespace WebApi.Models.Ponds;

using System.ComponentModel.DataAnnotations;
using WebApi.Entities;
public class CreatePondResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Altitude { get; set; }
    public int Longitud { get; set; }
    public string mssg { get; set; }
    public string error { get; set; }

    public CreatePondResponse(Pond pond, string mssg, string errorM)
    {
        Id = pond.Id;
        Name = pond.Name;
        Altitude = pond.Altitude;
        Longitud = pond.Longitud;
        error = errorM;
        mssg = mssg;
    }
}