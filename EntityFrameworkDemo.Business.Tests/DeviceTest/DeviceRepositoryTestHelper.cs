using EntityFrameworkDemo.Business.Dto;
using EntityFrameworkDemo.Entity.Entities;

namespace EntityFrameworkDemo.Business.Tests.DeviceTest
{
    public static class DeviceRepositoryTestHelper
    {
        public static DeviceDto GenerateDto()
        {
            var dto = new DeviceDto()
            {
                Name = "Devic4",
                Description = "This is Device4", 
                SubSystemId = 1
            }; 
            return dto;
        }
    }
}
