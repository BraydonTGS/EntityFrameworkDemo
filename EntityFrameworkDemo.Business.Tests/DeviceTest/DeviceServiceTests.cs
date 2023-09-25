using AutoMapper;
using EntityFrameworkDemo.Business.Interfaces;
using EntityFrameworkDemo.Business.Tests.Base;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace EntityFrameworkDemo.Business.Tests.DeviceTest
{
    [TestClass]
    public class DeviceServiceTests : TestBase
    {
        private readonly IServiceCollection _services;
        private readonly IServiceProvider _serviceProvider;
        private readonly IDeviceService _service;
        private readonly DatabaseSeeder _databaseSeeder;
        public DeviceServiceTests()
        {
            _services = ConfigureServices(seedDatabase: true);
            _serviceProvider = _services.BuildServiceProvider();
            _service = _serviceProvider.GetRequiredService<IDeviceService>();
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

        [TestMethod]
        public async Task GetById_Success()
        {
            _databaseSeeder.Seed();
            var result = await _service.GetDeviceById(1);
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Id);
            Assert.AreEqual("Device1", result.Name);
            Assert.AreEqual(1, result.SubSystemId);
            _databaseSeeder.Clear();
        }

        [TestMethod]
        public async Task CreateNewDevice_Success()
        {
            _databaseSeeder.Seed();
            var dto = DeviceServiceTestHelper.GenerateDto();
            var result = await _service.AddNewDevice(dto);
            Assert.IsNotNull(result);
            _databaseSeeder.Clear();
        }

        [TestMethod]
        public async Task CreateNewDevice_Failure_DeviceAlreadyExistsWithinSubSystem()
        {
            _databaseSeeder.Seed();
            var dto = DeviceServiceTestHelper.GenerateDuplicateDevice();
            await Assert.ThrowsExceptionAsync<InvalidOperationException>(async () => await _service.AddNewDevice(dto));
            _databaseSeeder.Clear();
        }

        [TestMethod]
        public async Task DeleteDeviceById_Success()
        {
            _databaseSeeder.Seed();
            var result = await _service.DeleteDevice(1); 
            Assert.IsNotNull(result);
            Assert.IsTrue(result); 
            _databaseSeeder.Clear();
        }

        [TestMethod]
        public async Task DeleteDeviceById_Failure()
        {
            _databaseSeeder.Seed();
            var result = await _service.DeleteDevice(5);
            Assert.IsNotNull(result);
            Assert.IsFalse(result);
            _databaseSeeder.Clear();
        }

    }
}
