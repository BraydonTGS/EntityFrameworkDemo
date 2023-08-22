using EntityFrameworkDemo.Business.Interfaces;
using EntityFrameworkDemo.Business.Services;
using EntityFrameworkDemo.Business.Tests.Base;
using EntityFrameworkDemo.Business.Tests.PasswordTest;
using EntityFrameworkDemo.Business.Tests.UserTest;
using Microsoft.Extensions.DependencyInjection;

namespace EntityFrameworkDemo.Business.Tests.RegistrationTest
{
    [TestClass]
    public class RegistrationServiceTest : TestBase
    {

        private readonly IServiceCollection _services;
        private readonly IServiceProvider _serviceProvider;
        private readonly IRegistrationService _service;

        private readonly DatabaseSeeder _databaseSeeder;
        public RegistrationServiceTest()
        {
            _services = ConfigureServices(seedDatabase: true);
            _serviceProvider = _services.BuildServiceProvider();
            _service = _serviceProvider.GetRequiredService<IRegistrationService>();
            _databaseSeeder = _serviceProvider.GetRequiredService<DatabaseSeeder>();
        }

        [TestMethod]    
        public async Task RegisterNewUser_Success()
        {
            _databaseSeeder.Seed();

            var user = UserServiceTestHelper.GenerateDto();
            var password = PasswordServiceTestHelper.GeneratePassword();
            var results = await _service.RegisterNewUser(user, password);

            Assert.IsNotNull(results);
            Assert.IsTrue(results);

        }

    }
}
