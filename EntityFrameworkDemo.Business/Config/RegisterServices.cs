﻿using AutoMapper;
using EntityFrameworkDemo.Business.Context;
using EntityFrameworkDemo.Business.Interfaces;
using EntityFrameworkDemo.Business.Services;
using EntityFrameworkDemo.Business.Validations.Dto;
using EntityFrameworkDemo.Business.Validations.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace EntityFrameworkDemo.Business.Config
{
    public class RegisterServices
    {
        // Register Services Required for the Application //
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

            if (seedDatabase)
                services.AddScoped<DatabaseSeeder>();

            return services;
        }
}
