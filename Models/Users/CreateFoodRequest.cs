namespace WebApi.Models.Users;



public class CreateFoodRequest
{
    public int userId { get; set; }

    public string food_type { get; set; }

    public decimal food_cost { get; set; }

    public int food_quantity { get; set;}


}