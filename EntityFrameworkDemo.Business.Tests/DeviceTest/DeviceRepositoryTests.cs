using AutoMapper;
using EntityFrameworkDemo.Business.Interfaces;
using EntityFrameworkDemo.Business.Tests.Base;
using Microsoft.Extensions.DependencyInjection;

namespace EntityFrameworkDemo.Business.Tests.DeviceTest
{
    [TestClass]
    public class DeviceRepositoryTests : TestBase
    {
        private readonly IServiceCollection _services;
        private readonly IServiceProvider _serviceProvider;
        private readonly IDeviceService _service;
        private readonly IMapper _mapper;
        private readonly DatabaseSeeder _databaseSeeder;
        public DeviceRepositoryTests()
        {
            _services = ConfigureServices(seedDatabase: true);
            _serviceProvider = _services.BuildServiceProvider();
            _service = _serviceProvider.GetRequiredService<IDeviceService>();
            _mapper = _serviceProvider.GetRequiredService<IMapper>();
            _databaseSeeder = _serviceProvider.GetRequiredService<DatabaseSeeder>();
        }

        [TestMethod]
        public async Task GetAll_Success()
        {
            _databaseSeeder.Seed();
            var result = await _service.GetDevicesAsync();
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count());
            _databaseSeeder.Clear();
        }
    }
}
