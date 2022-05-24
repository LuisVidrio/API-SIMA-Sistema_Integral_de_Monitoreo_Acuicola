namespace WebApi.Models.Ponds;

using System.ComponentModel.DataAnnotations;
using WebApi.Entities;
public class IOT_ValueResponse
{
      public decimal parameter_value { get; set; }
      public DateTime created_at { get; set; }

    public IOT_ValueResponse(IOT_Value value)
    {
        parameter_value = value.parameter_value;
        created_at = value.created_at;
    }
}