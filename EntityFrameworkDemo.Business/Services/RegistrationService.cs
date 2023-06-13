using EntityFrameworkDemo.Business.Interfaces;

namespace EntityFrameworkDemo.Business.Services
{
    public class RegistrationService
    {
        IEncryptPasswordService _encryptService;
        IUserService _userService;
        public RegistrationService(IEncryptPasswordService encryptService, IUserService userService)
        {
            _encryptService = encryptService;
            _userService = userService;

        }
    }
}
