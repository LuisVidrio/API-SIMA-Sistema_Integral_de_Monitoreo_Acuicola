namespace WebApi.Services;

using BCrypt.Net;
using BCryptNet = BCrypt.Net.BCrypt;
using Microsoft.Extensions.Options;
using WebApi.Authorization;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Models.Users;

public interface IUserService
{
    AuthenticateResponse Authenticate(AuthenticateRequest model);
    AuthenticateResponse AuthenticateSingup(AuthenticateSingupRequest model);
    IEnumerable<User> GetAll();
    User GetById(int id);
    NotificationToken_Response setNotificationToken(NotificationToken_Request model);
    IEnumerable<Food> GetAllFood(HttpContext http);
    Food CreateFood(CreateFoodRequest model);

    User DeleteUser(int id);

    User Update( User model);



}

public class UserService : IUserService
{
    private DataContext _context;
    private IJwtUtils _jwtUtils;
    private readonly AppSettings _appSettings;


    public UserService(
        DataContext context,
        IJwtUtils jwtUtils,
        IOptions<AppSettings> appSettings
        )
    {
        _context = context;
        _jwtUtils = jwtUtils;
        _appSettings = appSettings.Value;
    }


    public AuthenticateResponse Authenticate(AuthenticateRequest model)
    {
        var user = _context.Users.SingleOrDefault(x => x.Username == model.Username);

        // validate
        if (user == null || !BCrypt.Verify(model.Password, user.PasswordHash))
            throw new AppException("Username or password is incorrect");

        // authentication successful so generate jwt token
        var jwtToken = _jwtUtils.GenerateJwtToken(user);

        return new AuthenticateResponse(user, jwtToken);
    }

     public AuthenticateResponse AuthenticateSingup(AuthenticateSingupRequest model)
    {
        var jwtToken = "";
        var user = _context.Users.SingleOrDefault(x => x.Username == model.Username);
        if( user != null )throw new AppException("Username exists");
        // validate
        if (user == null)
        {
            var newUser = new User {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Username = model.Username,
                PasswordHash = BCryptNet.HashPassword(model.Password),
                Role = model.Role
                };
            _context.Users.Add(newUser);
            _context.SaveChanges();
            jwtToken = _jwtUtils.GenerateJwtToken(newUser);
            user = _context.Users.SingleOrDefault(x => x.Username == model.Username);
        }


        // authentication successful so generate jwt token


        return new AuthenticateResponse(user, jwtToken);
    }

   public User DeleteUser(int id)
    {
        var user = _context.Users.SingleOrDefault(x => x.Id == id);
        _context.Users.Remove(user);
        _context.SaveChanges();
        return user;
    }


    public IEnumerable<User> GetAll()
    {
        return _context.Users;
    }

    public User GetById(int id) 
    {
        var user = _context.Users.Find(id);
        if (user == null) throw new KeyNotFoundException("User not found");
        return user;
    }

      public NotificationToken_Response setNotificationToken(NotificationToken_Request model)
    {
        var user = _context.Users.Find(model.id);
        if (user == null) throw new KeyNotFoundException("User not found");
        user.notificationToken = model.token;
        _context.Users.Attach(user).Property(r=>r.notificationToken).IsModified=true;
        _context.SaveChanges();
        user = _context.Users.Find(model.id);

        return new NotificationToken_Response("sucess",user);
    }

     public IEnumerable<Food> GetAllFood(HttpContext http){
                 var token = http.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
                var id = _jwtUtils.ValidateJwtToken(token);
           return _context.Foods.Where(Value => Value.UserId == id).Select(p => new Food{
                 Id = p.Id,
             UserId = p.UserId,
             food_type = p.food_type,
             food_cost = p.food_cost,
             food_quantity = p.food_quantity,
             existence  = p.existence

           });
    }

     public Food CreateFood(CreateFoodRequest model)
    {

            var newFood = new Food {
                UserId = model.userId,
                food_type = model.food_type,
                food_cost = model.food_cost,
                food_quantity = model.food_quantity,
                existence = model.food_quantity,
                };
            _context.Foods.Add(newFood);
            _context.SaveChanges();
        return newFood;
}

  public User Update( User model){
                    _context.Users.Update(model);
                    _context.SaveChanges();
                    var user =  _context.Users.Find(model.Id);
            return user;
    }

}