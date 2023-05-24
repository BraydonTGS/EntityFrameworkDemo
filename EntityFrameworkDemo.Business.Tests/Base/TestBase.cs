﻿using EntityFrameworkDemo.Business.Context;
using EntityFrameworkDemo.Business.Interfaces;
using EntityFrameworkDemo.Business.Repository;
using EntityFrameworkDemo.Business.Services;
using EntityFrameworkDemo.Business.Validations.Dto;
using EntityFrameworkDemo.Business.Validations.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EntityFrameworkDemo.Business.Tests.Base
{
    public class TestBase
    {
        protected readonly IServiceCollection services;
        protected readonly ServiceProvider serviceProvider;
        public TestBase()
        {
            services = new ServiceCollection();
            ConfigureServices();
            serviceProvider = services.BuildServiceProvider();
        }

        public virtual void ConfigureServices()
        {
            services.AddDbContext<SubSystemDbContext>(options =>
            {
                options.UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString());
                options.UseLazyLoadingProxies();
            }, ServiceLifetime.Transient);

            services.AddTransient<DeviceRepository>();
            services.AddTransient<SubSystemRepository>();
            services.AddTransient<IDeviceService, DeviceService>();
            services.AddTransient<ISubSystemService, SubSystemService>();
            services.AddTransient<SubSystemDtoValidator>(); 
            services.AddTransient<DeviceDtoValidator>();


        }

        protected TService GetService<TService>()
        {
            var service = serviceProvider.GetService<TService>();
            if (service == null)
            {
                throw new Exception("Service Not Found");
            }
            return service;
        }
    }
}
