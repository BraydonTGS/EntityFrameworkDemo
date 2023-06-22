using EntityFrameworkDemo.Business.Dto;

namespace EntityFrameworkDemo.Business.Tests.UserTest
{
    public class UserServiceTestHelper
    {
        public static UserDto GenerateDto()
        {
            var dto = new UserDto()
            {
                FirstName = "Braydon",
                LastName = "Sutherland",
                UserName = "GeoMatix",
                Email = "BradonTGS@gmail.com"
            }; 
            return dto;
        }

        public static UserDto GenerateDuplicateUser()
        {
            var dto = new UserDto()
            {
                FirstName = "Braydon",
                LastName = "Sutherland",
                UserName = "GeoMatix",
                Email = "BradonTGS@gmail.com"
            };
            return dto;
        }
    }
}
