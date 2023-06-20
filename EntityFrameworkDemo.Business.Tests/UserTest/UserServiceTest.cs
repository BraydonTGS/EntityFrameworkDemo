using EntityFrameworkDemo.Business.Interfaces;
using EntityFrameworkDemo.Business.Tests.Base;
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
        public async Task RegisterNewUser_Success()
        {
            _databaseSeeder.Seed();
            var dto = UserServiceTestHelper.GenerateDto();
            var result = await _service.AddNewUser(dto, "Testing");
            Assert.IsNotNull(result);   
            _databaseSeeder.Clear();
        }
    }
}
