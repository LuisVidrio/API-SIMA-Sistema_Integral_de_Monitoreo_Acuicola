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
{    CreateIOT_ModuleResponse Add(CreateIOT_ModuleRequest model);
    IEnumerable<IOT_Module> GetAll();
    IOT_Module GetById(int id);
    IOT_Module Delete(int id);
    CreateIOT_ModuleResponse Update(IOT_Module model);
}

public class IOT_ModuleService : I_IOT_ModuleService
{
    private DataContext _context;
    private IJwtUtils _jwtUtils;
    private readonly AppSettings _appSettings;

    public IOT_ModuleService(
        DataContext context,
        IJwtUtils jwtUtils,
        IOptions<AppSettings> appSettings)
    {
        _context = context;
        _jwtUtils = jwtUtils;
        _appSettings = appSettings.Value;
    }


    public CreateIOT_ModuleResponse Add(CreateIOT_ModuleRequest model)
    {
        var pond = _context.Ponds.Find(model.PondId);
        // validate
            if(pond != null ){
                var newIOT_Module = new IOT_Module {
                PondId = model.PondId,
                Pond = pond,
                };
            _context.IOT_Modules.Add(newIOT_Module);
            _context.SaveChanges();
            var iotModule = _context.IOT_Modules.FirstOrDefault(x => x.PondId == model.PondId);
            return new CreateIOT_ModuleResponse(iotModule,"Created Sucessfully",null );

            }
        throw new KeyNotFoundException("Pond not found");





    }

    public IEnumerable<IOT_Module> GetAll()
    {
        return _context.IOT_Modules.Include(IO_Modules => IO_Modules.IOT_Devices).ToList();;
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
        _context.Remove(iotModule);
        _context.SaveChanges();
        return iotModule;

    }
}