using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using SmartParkingLotManagement.Repositories;
using SmartParkingLotManagement.Services;

namespace SmartParkingLotManagement.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            
            services.AddSingleton<IMongoClient, MongoClient>(sp =>
            {
                var connectionString = "mongodb://localhost:27017/";
                return new MongoClient(connectionString);
            });

            services.AddScoped(sp =>
            {
                var client = sp.GetRequiredService<IMongoClient>();
                return client.GetDatabase("SmartParkingLotManagement");
            });

            services.AddScoped<IParkingSpotRepository, ParkingSpotRepository>();
            services.AddScoped<IDeviceRepository, DeviceRepository>();
            services.AddScoped<ParkingSpotService>();
            services.AddScoped<DeviceService>();
        }
    }
}