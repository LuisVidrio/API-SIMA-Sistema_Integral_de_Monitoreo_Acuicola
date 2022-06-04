namespace WebApi.Models.Ponds;




public class SetModuleConfigRequest
{
    public int Id { get; set; }
    public string wifi_user { get; set; }
    public string wifi_pass {get; set; }
    public string wifi_type {get; set; }

}