using EntityFrameworkDemo.Business.Dto;
using EntityFrameworkDemo.Entity.Entities;

namespace EntityFrameworkDemo.Business.Tests.DeviceTest
{
    public static class DeviceServiceTestHelper
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

        public static DeviceDto GenerateDuplicateDevice()
        {
            var dto = new DeviceDto()
            {
                Name = "Device1",
                Description = "This is Device1",
                SubSystemId = 1
            };
            return dto;
        }
    }
}
