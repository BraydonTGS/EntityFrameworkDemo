using EntityFrameworkDemo.Business.Repository;
using EntityFrameworkDemo.Business.Tests.Base;

namespace EntityFrameworkDemo.Business.Tests.Device
{
    [TestClass]
    public class DeviceRepositoryTests : TestBase
    {
        public DeviceRepositoryTests()
        {
            
        }

        [TestMethod]
        public async Task GetAll_Success()
        {
            var repository = GetService<DeviceRepository>();

            var result = await repository.GetAllAsync();

            Assert.IsNotNull(result);
        }
    }
}
