using EntityFrameworkDemo.Business.Interfaces;
using EntityFrameworkDemo.Business.Tests.Base;
using Microsoft.Extensions.DependencyInjection;

namespace EntityFrameworkDemo.Business.Tests.PasswordTest
{
    [TestClass]
    public class PasswordServiceTests : TestBase
    {
        private readonly IServiceCollection _services;
        private readonly IServiceProvider _serviceProvider;
        private readonly IPasswordService _service;
        private readonly DatabaseSeeder _databaseSeeder;

        public PasswordServiceTests()
        {
            _services = ConfigureServices(seedDatabase: true);
            _serviceProvider = _services.BuildServiceProvider();
            _service = _serviceProvider.GetRequiredService<IPasswordService>();
            _databaseSeeder = _serviceProvider.GetRequiredService<DatabaseSeeder>();
        }

        [TestMethod]
        public async Task CreateNewPassword_Success()
        {
            _databaseSeeder.Seed();
            var password = PasswordServiceTestHelper.GeneratePassword();
            var results = await _service.CreatePasswordAsync(password);

            Assert.IsNotNull(results);
            Assert.IsNotNull(results.Hash);
            Assert.IsNotNull(results.Salt);

            _databaseSeeder.Clear(); 
        }

        [TestMethod]

        public async Task DeletePassword_Success()
        {
            _databaseSeeder.Seed();
            var password = PasswordServiceTestHelper.GeneratePassword();
            var passwordDto = await _service.CreatePasswordAsync(password);

            Assert.IsNotNull(passwordDto);
            Assert.IsNotNull(passwordDto.Hash);
            Assert.IsNotNull(passwordDto.Salt);

            var results = await _service.DeletePasswordAsync(passwordDto.Id);

            Assert.IsNotNull(results);
            Assert.IsTrue(results);

            _databaseSeeder.Clear();
        }

    }
}
