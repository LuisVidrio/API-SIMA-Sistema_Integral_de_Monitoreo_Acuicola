namespace WebApi.Models.Ponds;

using System.ComponentModel.DataAnnotations;
using WebApi.Entities;
public class BasketResponse
{
    public int Id { get; set; }
    public int PondId { get; set; }
    public BasketMutation mutation  { get; set; }

    public BasketResponse(FoodBasket basket, string mssg, string errorM)
    {
        Id = basket.Id;

        PondId = basket.PondId;

        mutation = basket.mutation;

      
    }
}