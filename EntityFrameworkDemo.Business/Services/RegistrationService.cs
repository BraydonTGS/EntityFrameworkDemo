using EntityFrameworkDemo.Business.Interfaces;

namespace EntityFrameworkDemo.Business.Services
{
    public class RegistrationService
    {
        IPasswordService _passwordService;
        IUserService _userService;
        public RegistrationService(IPasswordService passwordService, IUserService userService)
        {
            _passwordService = passwordService;
            _userService = userService;

        }
    }
}
