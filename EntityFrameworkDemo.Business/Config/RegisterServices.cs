using AutoMapper;
using EntityFrameworkDemo.Business.Connection;
using EntityFrameworkDemo.Business.Context;
using EntityFrameworkDemo.Business.Interfaces;
using EntityFrameworkDemo.Business.MappingProfile;
using EntityFrameworkDemo.Business.Repository;
using EntityFrameworkDemo.Business.Services;
using EntityFrameworkDemo.Business.Validations.Dto;
using EntityFrameworkDemo.Business.Validations.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;


namespace EntityFrameworkDemo.Business.Config
{
    public class RegisterServices
    {
        // Register Services Required for the Application //
        public virtual IServiceCollection ConfigureServices()
        {
            var services = new ServiceCollection();

            services.AddDbContext<SubSystemDbContext>(options =>
            {
                options.UseSqlServer(Hidden.GetConnectionString());
            }, ServiceLifetime.Transient);

            services.AddDbContextFactory<SubSystemDbContext>();

            var mapperConfig = new MapperConfiguration(map =>
            {
                map.AddProfile<MappingProfiles>();
            });
            services.AddLogging(builder =>
            {
                builder.ClearProviders().AddSerilog();
            });
            services.AddSingleton(mapperConfig.CreateMapper());
            services.AddScoped<DeviceRepository>();
            services.AddScoped<SubSystemRepository>();
            services.AddScoped<IDeviceService, DeviceService>();
            services.AddScoped<ISubSystemService, SubSystemService>();
            services.AddScoped<IDbContextValidationHelper, DbContextValidationHelper>();
            services.AddScoped<SubSystemDtoValidator>();
            services.AddScoped<DeviceDtoValidator>();

            return services;
        }
    }
}
