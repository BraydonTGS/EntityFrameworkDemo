using EntityFrameworkDemo.Business.Interfaces;
using EntityFrameworkDemo.Business.Tests.Base;
using EntityFrameworkDemo.Business.Tests.SubSystemTest;
using Microsoft.Extensions.DependencyInjection;

namespace EntityFrameworkDemo.Business.Tests.UserTest
{
    [TestClass]
    public class UserServiceTest : TestBase
    {
        private readonly IServiceCollection _services;
        private readonly IServiceProvider _serviceProvider;
        private readonly IUserService _service;
        private readonly DatabaseSeeder _databaseSeeder;

        public UserServiceTest()
        {
            _services = ConfigureServices(seedDatabase: true);
            _serviceProvider = _services.BuildServiceProvider();
            _service = _serviceProvider.GetRequiredService<IUserService>();
            _databaseSeeder = _serviceProvider.GetRequiredService<DatabaseSeeder>();
        }

        [TestMethod]
        public async Task GetAll_Success()
        {
            _databaseSeeder.Seed();
            var result = await _service.GetAllUsersAsync();
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
            _databaseSeeder.Clear();
        }

        [TestMethod]
        public async Task GetById_Success()
        {
            _databaseSeeder.Seed();
            var result = await _service.GetUserByIdAsync(1);
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Id);
            Assert.AreEqual("Sally", result.FirstName);
            Assert.AreEqual("Sutherland", result.LastName);
            _databaseSeeder.Clear();
        }

        [TestMethod]
        public async Task CreateNewDevice_Success()
        {
            _databaseSeeder.Seed();
            var dto = UserServiceTestHelper.GenerateDto();
            var result = await _service.AddNewUserAsync(dto);
            Assert.IsNotNull(result);
            _databaseSeeder.Clear();
        }

        [TestMethod]
        public async Task CreateNewDevice_Failure_DeviceAlreadyExistsWithinSubSystem()
        {
            _databaseSeeder.Seed();
            var dto = UserServiceTestHelper.GenerateDuplicateUser();
            await Assert.ThrowsExceptionAsync<InvalidOperationException>(async () => await _service.AddNewUserAsync(dto));
            _databaseSeeder.Clear();
        }

        [TestMethod]
        public async Task DeleteDeviceById_Success()
        {
            _databaseSeeder.Seed();
            var result = await _service.DeleteUserAsync(1);
            Assert.IsNotNull(result);
            Assert.IsTrue(result);
            _databaseSeeder.Clear();
        }

        [TestMethod]
        public async Task DeleteDeviceById_Failure()
        {
            _databaseSeeder.Seed();
            var result = await _service.DeleteUserAsync(5);
            Assert.IsNotNull(result);
            Assert.IsFalse(result);
            _databaseSeeder.Clear();
        }
    }
}
