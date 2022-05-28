namespace WebApi.Entities;

using System.Text.Json.Serialization;

public class Pond
{
    public int Id { get; set; }
    public int Altitude { get; set; }
    public int Longitud { get; set; }
    public string Name { get; set; }

    public List<IOT_Module> IOT_Modules { get; set;}

}
public class IOT_Module
{
    public int Id { get; set; }
    public int? PondId { get; set; }
    public string serialId { get; set; }

    public string release {get; set; }

    public string version { get; set; }
    public string CPU {get; set; }
    public Pond? Pond { get; set; }

    public List<IOT_Device>? IOT_Devices { get; set;}
}

public enum Parameter
{
    ox,temp,ph
}

public class IOT_Device
{
    public string Id { get; set; }
    public int? IOT_ModuleId { get; set; }

    public Parameter? Parameter { get; set; }
    public IOT_Module? IOT_Module { get; set; }

    public string deviceType { get; set; }

    public List<IOT_Value> IOT_Values { get; set;}
}

public class IOT_Value
{
    public string IOT_DeviceId { get; set;}
    public IOT_Device IOT_Device { get; set;}
    public decimal parameter_value { get; set; }
    public Parameter Parameter {get; set;}
    public DateTime created_at { get; set; }
}