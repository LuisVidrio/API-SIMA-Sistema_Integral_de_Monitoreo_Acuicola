namespace WebApi.Models.Ponds;

using System.ComponentModel.DataAnnotations;
using WebApi.Entities;


public class ParameterRangeRequest
{

    public int pondId {get; set;}

    public Parameter parameter {get; set;}

    public decimal low {get; set;}

    public decimal high {get; set; }


}