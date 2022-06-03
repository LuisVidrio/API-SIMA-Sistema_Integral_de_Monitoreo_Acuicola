namespace WebApi.Entities;

using System.Text.Json.Serialization;

public class User
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }
    public Role Role { get; set; }
    public string notificationToken {get; set;}
    public string notificationUserTopic { get; set; }
    public List<Food> userFoods {get; set;}

    [JsonIgnore]
    public string PasswordHash { get; set; }

        public List<Pond> Ponds { get; set;}

}