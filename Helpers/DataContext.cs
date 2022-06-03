namespace WebApi.Helpers;

using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

public class DataContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Pond> Ponds { get; set; }
    public DbSet<IOT_Module> IOT_Modules { get; set; }

    public DbSet<IOT_Device> IOT_Devices { get; set; }
    public DbSet<IOT_Value> IOT_Values { get; set; }

    public DbSet<FoodBasket> FoodBaskets { get; set; }

    public DbSet<Parameter_range> parameter_ranges {get; set;}

     public DbSet<Food> Foods {get; set;}




    private readonly IConfiguration Configuration;

    public DataContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
       var connectionString = Configuration.GetConnectionString("SIMA");
        options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<IOT_Value>()
           .Property(c => c.created_at)
           .HasColumnType("datetime(3)")
           .IsRequired();
        modelBuilder.Entity<IOT_Value>()
            .HasKey(c => new { c.IOT_DeviceId, c.created_at });
    }
}