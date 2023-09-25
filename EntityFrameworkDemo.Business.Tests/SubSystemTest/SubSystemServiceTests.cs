using EntityFrameworkDemo.Business.Interfaces;
using EntityFrameworkDemo.Business.Tests.Base;
using EntityFrameworkDemo.Business.Tests.DeviceTest;
using Microsoft.Extensions.DependencyInjection;

namespace EntityFrameworkDemo.Business.Tests.SubSystemTest
{
    [TestClass]
    public class SubSystemServiceTests : TestBase
    {
        private readonly IServiceCollection _services;
        private readonly IServiceProvider _serviceProvider;
        private readonly ISubSystemService _service;
        private readonly DatabaseSeeder _databaseSeeder;
        public SubSystemServiceTests()
        {
            _services = ConfigureServices(seedDatabase: true);
            _serviceProvider = _services.BuildServiceProvider();
            _service = _serviceProvider.GetRequiredService<ISubSystemService>();
            _databaseSeeder = _serviceProvider.GetRequiredService<DatabaseSeeder>();
        }

        [TestMethod]
        public async Task GetAll_Success()
        {
            _databaseSeeder.Seed();
            var result = await _service.GetSubSystemsAsync();
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count());
            _databaseSeeder.Clear();
        }

        [TestMethod]
        public async Task GetById_Success()
        {
            _databaseSeeder.Seed();
            var result = await _service.GetByIdAsyncIncludeDevice(1);
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Id);
            Assert.AreEqual("SubSystem1", result.Name);
            Assert.AreEqual(3, result.Devices?.Count());
            _databaseSeeder.Clear();
        }

        [TestMethod]
        public async Task CreateNewSubSystem_Success()
        {
            _databaseSeeder.Seed();
            var dto = SubSystemServiceTestHelper.GenerateDto();
            var result = await _service.AddNewSubSystem(dto);
            Assert.IsNotNull(result);
            _databaseSeeder.Clear();
        }

        [TestMethod]
        public async Task CreateNewSubSystem_Failure_SubSystemAlreadyExists()
        {
            _databaseSeeder.Seed();
            var dto = SubSystemServiceTestHelper.GenerateDuplicateSubSystem();
            await Assert.ThrowsExceptionAsync<InvalidOperationException>(async () => await _service.AddNewSubSystem(dto));
            _databaseSeeder.Clear();
        }

        [TestMethod]
        public async Task DeleteSubSystemById_Success()
        {
            _databaseSeeder.Seed();
            var result = await _service.DeleteSubSystem(1);
            Assert.IsNotNull(result);
            Assert.IsTrue(result);
            _databaseSeeder.Clear();
        }

        [TestMethod]
        public async Task DeleteSubSystemById_Failure()
        {
            _databaseSeeder.Seed();
            var result = await _service.DeleteSubSystem(5);
            Assert.IsNotNull(result);
            Assert.IsFalse(result);
            _databaseSeeder.Clear();
        }
    }
}
