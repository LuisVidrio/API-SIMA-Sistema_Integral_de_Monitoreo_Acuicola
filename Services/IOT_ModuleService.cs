namespace WebApi.Services;

using BCrypt.Net;
using BCryptNet = BCrypt.Net.BCrypt;
using Microsoft.Extensions.Options;
using WebApi.Authorization;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Models.Ponds;
using Microsoft.EntityFrameworkCore;

public interface I_IOT_ModuleService
{   CreateIOT_ModuleResponse Add(CreateIOT_ModuleRequest model);
    IEnumerable<IOT_Module> GetAll();
    IOT_Module GetById(int id);
    IOT_Module Delete(int id);
    CreateIOT_ModuleResponse Update(IOT_Module model);
    CreateIOT_ModuleResponse SetPond(SetPond_ModuleRequest model);
    IEnumerable<IOT_Module> getNotActive();
    CreateIOT_ModuleResponse SetModuleConfig(SetModuleConfigRequest model);

}

public class IOT_ModuleService : I_IOT_ModuleService
{
    private DataContext _context;
    private IJwtUtils _jwtUtils;
    private readonly AppSettings _appSettings;


    public IOT_ModuleService(
        DataContext context,
        IJwtUtils jwtUtils,
        IOptions<AppSettings> appSettings
        )
    {
        _context = context;
        _jwtUtils = jwtUtils;
        _appSettings = appSettings.Value;
    }


   public CreateIOT_ModuleResponse Add(CreateIOT_ModuleRequest model)
    {
        var iotModule = _context.IOT_Modules.FirstOrDefault(x => x.serialId == model.serialId);
            if(iotModule != null ) return new CreateIOT_ModuleResponse(iotModule,"found Module with the same id",null);
                var newIOT_Module = new IOT_Module {
                serialId = model.serialId,
                version = model.version,
                CPU = model.CPU
                };
            _context.IOT_Modules.Add(newIOT_Module);
            _context.SaveChanges();
            iotModule = _context.IOT_Modules.FirstOrDefault(x => x.serialId == model.serialId);
            return new CreateIOT_ModuleResponse(iotModule,"Created Sucessfully",null );

    }

    public CreateIOT_ModuleResponse SetPond(SetPond_ModuleRequest model){
    var iotModule = _context.IOT_Modules.FirstOrDefault(x => x.Id == model.Id);
    if(iotModule != null){
          iotModule.PondId = model.pondId;
    _context.IOT_Modules.Attach(iotModule).Property(r=>r.PondId).IsModified=true;
    _context.SaveChanges();
    iotModule = _context.IOT_Modules.FirstOrDefault(x => x.Id == model.Id);
    return new CreateIOT_ModuleResponse(iotModule,"the pond was set sucessfully",null);
    }
    return new CreateIOT_ModuleResponse(iotModule,"there was an error",null);
    }

    public IEnumerable<IOT_Module> GetAll()
    {
        return _context.IOT_Modules.Include(IO_Modules => IO_Modules.IOT_Devices).ToList();;
    }

     public IEnumerable<IOT_Module> getNotActive()
    {
            return _context.IOT_Modules.Where(Value => Value.PondId == null).Select(p => new IOT_Module{
                Id = p.Id,
                serialId = p.serialId,
                CPU = p.CPU,
                IOT_Devices = p.IOT_Devices,
            });
    }

    public IOT_Module GetById(int id)
    {
        var iotModule = _context.IOT_Modules.Include(IOT_Module => IOT_Module.Pond)
        .FirstOrDefault(x => x.Id == id);
        if (iotModule == null) throw new KeyNotFoundException("User not found");
        return iotModule;
    }

    public CreateIOT_ModuleResponse Update( IOT_Module model){
                    _context.IOT_Modules.Update(model);
                    _context.SaveChanges();
                    var pond =  _context.IOT_Modules.Find(model.Id);
            return new CreateIOT_ModuleResponse(pond,null,null);

    }

    public IOT_Module Delete(int id){
        var iotModule = _context.IOT_Modules.Find(id);
        Console.WriteLine("looking at pond",id);
        if (iotModule == null) throw new KeyNotFoundException("User not found");
        Console.WriteLine("looking at pond2",id);
        _context.Remove(iotModule);
        _context.SaveChanges();
        return iotModule;

    }

      public CreateIOT_ModuleResponse SetModuleConfig(SetModuleConfigRequest model){
    var iotModule = _context.IOT_Modules.FirstOrDefault(x => x.Id == model.Id);
    if(iotModule != null){

          iotModule.wifi_pass = model.wifi_pass;
          iotModule.wifi_type = model.wifi_type;
          iotModule.wifi_user = model.wifi_user;

    _context.IOT_Modules.Attach(iotModule).State=EntityState.Modified;
    _context.SaveChanges();
    iotModule = _context.IOT_Modules.FirstOrDefault(x => x.Id == model.Id);
    return new CreateIOT_ModuleResponse(iotModule,"the wifi was updated",null);
    }
    return new CreateIOT_ModuleResponse(iotModule,"there was an error",null);
    }
}