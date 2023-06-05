using AutoMapper;
using EntityFrameworkDemo.Business.Context;
using EntityFrameworkDemo.Business.Interfaces;
using EntityFrameworkDemo.Business.Logging;
using EntityFrameworkDemo.Business.MappingProfile;
using EntityFrameworkDemo.Business.Repository;
using EntityFrameworkDemo.Business.Services;
using EntityFrameworkDemo.Business.Validations.Dto;
using EntityFrameworkDemo.Business.Validations.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;

namespace EntityFrameworkDemo.Business.Tests.Base
{
    public class TestBase
    {
        // Register Services Required for Unit Tests //
        public virtual IServiceCollection ConfigureServices(bool seedDatabase = false)
        {
            var services = new ServiceCollection();

            services.AddDbContext<SubSystemDbContext>(options =>
            {
                options.UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString());
                options.UseLazyLoadingProxies();
            }, ServiceLifetime.Transient);

            services.AddDbContextFactory<SubSystemDbContext>();

            var mapperConfig = new MapperConfiguration(map =>
            {
                map.AddProfile<MappingProfiles>();
            });

            services.AddSingleton(mapperConfig.CreateMapper());
            services.AddScoped<DeviceRepository>();
            services.AddScoped<SubSystemRepository>();
            services.AddScoped<IDeviceService, DeviceService>();
            services.AddScoped<ISubSystemService, SubSystemService>();
            services.AddScoped<IDbContextValidationHelper, DbContextValidationHelper>();
            services.AddScoped<SubSystemDtoValidator>();
            services.AddScoped<DeviceDtoValidator>();

            // Configure Logging //
            var loggerFactory = LoggingConfig.ConfigureLogging(services);
            services.AddSingleton(loggerFactory);

            if (seedDatabase)
                services.AddScoped<DatabaseSeeder>();

            return services;
        }
    }
}
