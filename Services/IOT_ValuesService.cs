namespace WebApi.Services;

using BCrypt.Net;
using BCryptNet = BCrypt.Net.BCrypt;
using Microsoft.Extensions.Options;
using WebApi.Authorization;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Models.Ponds;
using Microsoft.EntityFrameworkCore;


public interface I_IOT_ValuesService
{    //CreateIOT_ValuesResponse Add(CreateIOT_ValuesRequest model);
//  IEnumerable<IOT_Values> GetAll();
 //   IOT_Values GetById(int id);
   //  IOT_Values Delete(int id);
  //  CreateIOT_ValuesResponse Update(IOT_Values model);
    IEnumerable<IOT_ValueResponse> GetByPondId(int id);
}

public class IOT_ValuesService : I_IOT_ValuesService
{
    private DataContext _context;
    private IJwtUtils _jwtUtils;


    private readonly AppSettings _appSettings;

    public IOT_ValuesService(
        DataContext context,
        IJwtUtils jwtUtils,
        IOptions<AppSettings> appSettings)
    {
        _context = context;
        _jwtUtils = jwtUtils;
        _appSettings = appSettings.Value;
    }

        public IEnumerable<IOT_ValueResponse> GetByPondId(int id){
                        Console.WriteLine("weps1");
           var  IOT_Module = _context.IOT_Modules.FirstOrDefault(x=>x.PondId == id);
                       Console.WriteLine("weps2");
           var IOT_Device = _context.IOT_Devices.FirstOrDefault(x => x.IOT_ModuleId == IOT_Module.Id);
            Console.WriteLine("weps3");
            return _context.IOT_Values.Where(Value => Value.IOT_DeviceId == IOT_Device.Id).Select(p => new IOT_ValueResponse(p));
        }


  /*  public CreateIOT_ValuesResponse Add(CreateIOT_ValuesRequest model)
    {
        var module = _context.IOT_Modules.Find(model.IOT_ModuleId);
        // validate
            if(module != null ){
                var newIOT_Values = new IOT_Values {
                IOT_ModuleId = model.IOT_ModuleId,
                IOT_Module = module,
                };
            _context.IOT_Valuess.Add(newIOT_Values);
            _context.SaveChanges();
            var iotValues = _context.IOT_Valuess.FirstOrDefault(x => x.IOT_ModuleId == model.IOT_ModuleId);
            return new CreateIOT_ValuesResponse(iotValues,"Created Sucessfully",null );

            }
        throw new KeyNotFoundException("Pond not found");
    }
    public IEnumerable<IOT_Values> GetAll()
    {
        return _context.IOT_Valuess;
    }

    public IOT_Values GetById(int id)
    {
        var iotValues = _context.IOT_Valuess.Include(IOT_Values => IOT_Values.IOT_Module)
        .FirstOrDefault(x => x.Id == id);
        if (iotValues == null) throw new KeyNotFoundException("User not found");
        return iotValues;
    }

    public CreateIOT_ValuesResponse Update( IOT_Values model){
                    _context.IOT_Valuess.Update(model);
                    _context.SaveChanges();
                    var pond =  _context.IOT_Valuess.Find(model.Id);
            return new CreateIOT_ValuesResponse(pond,null,null);

    }

    public IOT_Values Delete(int id){
        var iotValues = _context.IOT_Valuess.Find(id);
        if (iotValues == null) throw new KeyNotFoundException("User not found");
        _context.Remove(iotValues);
        _context.SaveChanges();
        return iotValues;

    }*/
}