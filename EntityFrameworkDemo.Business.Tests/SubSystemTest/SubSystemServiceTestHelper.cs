using EntityFrameworkDemo.Business.Dto;

namespace EntityFrameworkDemo.Business.Tests.SubSystemTest
{
    public class SubSystemServiceTestHelper
    {
        public static SubSystemDto GenerateDto()
        {
            var dto = new SubSystemDto()
            {
                Name = "SubSystem2",
                Description = "This is System2",
            };
            return dto;
        }

        public static SubSystemDto GenerateDuplicateDevice()
        {
            var dto = new SubSystemDto()
            {
                Name = "SubSystem1",
                Description = "This is System1",
            };
            return dto;
        }
    }
}
