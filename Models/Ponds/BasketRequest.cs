namespace WebApi.Models.Ponds;

using System.ComponentModel.DataAnnotations;
using WebApi.Entities;


public class BasketRequest
{
    public string Id { get; set; }
    public BasketMutation mutation { get; set; }

}