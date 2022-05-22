namespace WebApi.Services;

using BCrypt.Net;
using BCryptNet = BCrypt.Net.BCrypt;
using Microsoft.Extensions.Options;
using WebApi.Authorization;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Models.Ponds;
using Microsoft.EntityFrameworkCore;


public interface I_IOT_DeviceService
{    CreateIOT_DeviceResponse Add(CreateIOT_DeviceRequest model);
    IEnumerable<IOT_Device> GetAll();
    IOT_Device GetById(int id);
    IOT_Device Delete(int id);
    CreateIOT_DeviceResponse Update(IOT_Device model);
}

public class IOT_DeviceService : I_IOT_DeviceService
{
    private DataContext _context;
    private IJwtUtils _jwtUtils;
    private readonly AppSettings _appSettings;

    public IOT_DeviceService(
        DataContext context,
        IJwtUtils jwtUtils,
        IOptions<AppSettings> appSettings)
    {
        _context = context;
        _jwtUtils = jwtUtils;
        _appSettings = appSettings.Value;
    }


    public CreateIOT_DeviceResponse Add(CreateIOT_DeviceRequest model)
    {
        var module = _context.IOT_Modules.Find(model.IOT_ModuleId);
        // validate
            if(module != null ){
                var newIOT_Device = new IOT_Device {
                IOT_ModuleId = model.IOT_ModuleId,
                IOT_Module = module,
                };
            _context.IOT_Devices.Add(newIOT_Device);
            _context.SaveChanges();
            var iotDevice = _context.IOT_Devices.FirstOrDefault(x => x.IOT_ModuleId == model.IOT_ModuleId);
            return new CreateIOT_DeviceResponse(iotDevice,"Created Sucessfully",null );

            }
        throw new KeyNotFoundException("Pond not found");
    }

    public IEnumerable<IOT_Device> GetAll()
    {
        return _context.IOT_Devices;
    }

    public IOT_Device GetById(int id)
    {
        var iotDevice = _context.IOT_Devices.Include(IOT_Device => IOT_Device.IOT_Module)
        .FirstOrDefault(x => x.Id == id);
        if (iotDevice == null) throw new KeyNotFoundException("User not found");
        return iotDevice;
    }

    public CreateIOT_DeviceResponse Update( IOT_Device model){
                    _context.IOT_Devices.Update(model);
                    _context.SaveChanges();
                    var pond =  _context.IOT_Devices.Find(model.Id);
            return new CreateIOT_DeviceResponse(pond,null,null);

    }

    public IOT_Device Delete(int id){
        var iotDevice = _context.IOT_Devices.Find(id);
        if (iotDevice == null) throw new KeyNotFoundException("User not found");
        _context.Remove(iotDevice);
        _context.SaveChanges();
        return iotDevice;

    }
}