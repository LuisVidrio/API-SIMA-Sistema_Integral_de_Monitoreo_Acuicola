namespace WebApi.Services;

using BCrypt.Net;
using BCryptNet = BCrypt.Net.BCrypt;
using Microsoft.Extensions.Options;
using WebApi.Authorization;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Models.Ponds;
using Microsoft.EntityFrameworkCore;


public interface IPondService
{   CreatePondResponse Add(CreatePondRequest model);
    IEnumerable<Pond> GetAll();
    Pond GetById(int id);
    Pond Delete(int id);
    CreatePondResponse Update(Pond model);
    IEnumerable<Pond> getPondsByUser(int id);
    CreatePondResponse CreateFoodBasket(int id);
    IEnumerable<FoodBasket>  GetBasketbyPond(int id);

    BasketResponse UpdateBasket(FoodBasket model);
    BasketResponse DeleteFoodBasket(int id);

    Parameter_range CreateParameterRange(ParameterRangeRequest model);

    IEnumerable<Parameter_range> GetParameter_Ranges(int pondId);

    Parameter_range DeleteParameter(DeleteParameterRequest model);


}

public class PondService : IPondService
{
    private DataContext _context;
    private IJwtUtils _jwtUtils;
    private readonly AppSettings _appSettings;

    public PondService(
        DataContext context,
        IJwtUtils jwtUtils,
        IOptions<AppSettings> appSettings)
    {
        _context = context;
        _jwtUtils = jwtUtils;
        _appSettings = appSettings.Value;
    }


    public CreatePondResponse Add(CreatePondRequest model)
    {
        var pond = _context.Ponds.SingleOrDefault(x => x.Name == model.Name);
        // validate
        if (pond != null )
            throw new AppException("Pond name exists");
        if (pond == null)
        {
            var newPond = new Pond {
                UserId = model.userId,
                Name = model.Name,
                Altitude = model.Altitude,
                Longitud = model.Longitud,
                };
            _context.Ponds.Add(newPond);
            _context.SaveChanges();
            pond = _context.Ponds.SingleOrDefault(x => x.Name == model.Name);
        }

        return new CreatePondResponse(pond,"Created Sucessfully",null );
    }
     public  CreatePondResponse CreateFoodBasket(int id)
    {
        var pond = _context.Ponds.SingleOrDefault(x => x.Id == id);
            BasketMutation createMutation = 0;
        // validate
        if (pond == null )
            throw new AppException("el estanque no existe");
        if (pond != null)
        {
            var newFoodbasket = new FoodBasket {
                    PondId = id,
                    mutation = createMutation,
                };
            _context.FoodBaskets.Add(newFoodbasket);
            _context.SaveChanges();
            pond = _context.Ponds.SingleOrDefault(x => x.Id == id);
        }

        return new CreatePondResponse(pond,"Created Sucessfully",null );
    }

    public Parameter_range CreateParameterRange(ParameterRangeRequest model)
    {
       var parameter_rantes = _context.parameter_ranges.Where(Value => Value.PondId == model.pondId).Select(p => new Parameter_range{
                Id = p.Id,
                PondId = p.PondId,
                Parameter = p.Parameter,
                low = p.low,
                high = p.high,
            }).ToArray();

        if(parameter_rantes.Length == 0){
          var newParameter = new Parameter_range {
                Parameter = model.parameter,
                PondId = model.pondId,
                low = model.low,
                high = model.high
                };
            _context.parameter_ranges.Add(newParameter);
            _context.SaveChanges();
        return newParameter;

        }
            var flag = true;
            foreach(var parameter in parameter_rantes){
                Console.WriteLine($"{model.parameter} and {parameter.Parameter} {parameter.Id}");
                if(parameter.Parameter == model.parameter){
                  flag = false;
                  Console.WriteLine("it exists");
                }
            }
        // validate
        if ( flag )
       {
            var newParameter = new Parameter_range {
                Parameter = model.parameter,
                PondId = model.pondId,
                low = model.low,
                high = model.high
                };
            _context.parameter_ranges.Add(newParameter);
            _context.SaveChanges();
        return newParameter;

        }
                throw new AppException("el parametro existe");
    }

    public IEnumerable<Parameter_range> GetParameter_Ranges(int pondId)
    {
        return _context.parameter_ranges.Where(x => x.PondId == pondId).Select(p => new Parameter_range{
            Id = p.Id,
            Parameter = p.Parameter,
            low = p.low,
            high = p.high
            } );
    }
    public Parameter_range DeleteParameter(DeleteParameterRequest model)
    {
        var paramter_range = _context.parameter_ranges.SingleOrDefault(x => x.Id == model.Id);
        _context.parameter_ranges.Remove(paramter_range);
        _context.SaveChanges();
        return paramter_range;
    }




    public IEnumerable<Pond> GetAll()
    {
        return _context.Ponds.Include(Pond => Pond.IOT_Modules).ToList();
    }

     public IEnumerable<Pond> getPondsByUser(int id)
    {
          return _context.Ponds.Where(Value => Value.UserId == id).Select(p => new Pond{
                Id = p.Id,
                Name = p.Name,
                Altitude = p.Altitude,
                Longitud = p.Longitud,
                UserId = p.UserId,
            });
    }

    public Pond GetById(int id)
    {
        var pond = _context.Ponds.Find(id);
        Console.WriteLine(pond);
        if (pond == null) throw new KeyNotFoundException("User not found");
        return pond;
    }

    public CreatePondResponse Update( Pond model){
                    _context.Ponds.Update(model);
                    _context.SaveChanges();
                    var pond =  _context.Ponds.Find(model.Id);
            return new CreatePondResponse(pond,null,null);

    }

    public Pond Delete(int id){
        var pond = _context.Ponds.Find(id);
        Console.WriteLine("looking at pond",id);
        if (pond == null) throw new KeyNotFoundException("User not found");
        _context.Remove(pond);
        _context.SaveChanges();
        return pond;

    }
    public BasketResponse DeleteFoodBasket(int id){
        var basket = _context.FoodBaskets.Find(id);
        if (basket == null) throw new KeyNotFoundException("User not found");
        _context.Remove(basket);
        _context.SaveChanges();
        return new BasketResponse(basket,"delete sucessfully",null);
    }
     public  IEnumerable<FoodBasket>  GetBasketbyPond(int id)
    {
           return _context.FoodBaskets.Where(Value => Value.PondId == id).Select(p => new FoodBasket{
                 Id = p.Id,
                 PondId = p.PondId,
                 mutation = p.mutation,
           });
    }

    public BasketResponse UpdateBasket(FoodBasket model){
               _context.FoodBaskets.Update(model);
                    _context.SaveChanges();
                    var basket =  _context.FoodBaskets.Find(model.Id);
            return new BasketResponse(basket,"canastilla actualizada",null);
    }

}