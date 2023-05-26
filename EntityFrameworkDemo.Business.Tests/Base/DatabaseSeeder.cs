﻿using EntityFrameworkDemo.Business.Context;
using EntityFrameworkDemo.Entity.Entities;

namespace EntityFrameworkDemo.Business.Tests.Base
{
    public class DatabaseSeeder
    {
        private readonly SubSystemDbContext _dbContext;

        public DatabaseSeeder(SubSystemDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async void Seed()
        {
            var system = new SubSystem()
            {
                Name = "SubSystem1",
                Description = "SubSystem1",
                Devices = new List<Device>()

            };

            var device1 = new Device { Name = "Device1", Description = "Device1" };
            var device2 = new Device { Name = "Device2", Description = "Device2" };
            var device3 = new Device { Name = "Device3", Description = "Device3" };

            system.Devices.Add(device1);
            system.Devices.Add(device2);
            system.Devices.Add(device3);

            _dbContext.SubSystems.Add(system);
            _dbContext.Devices.Add(device1);
            _dbContext.Devices.Add(device2);
            _dbContext.Devices.Add(device3);

            await _dbContext.SaveChangesAsync();
        }

        public async void Clear()
        {
            _dbContext.Devices.RemoveRange(_dbContext.Devices);
            _dbContext.SubSystems.RemoveRange(_dbContext.SubSystems);
            await _dbContext.SaveChangesAsync();
        }
    }
}
