using EntityFrameworkDemo.Business.Dto;
using EntityFrameworkDemo.Business.Interfaces;

namespace EntityFrameworkDemo.Business.Services
{
    public class RegistrationService : IRegistrationService
    {
        IPasswordService _passwordService;
        IUserService _userService;
        public RegistrationService(IPasswordService passwordService, IUserService userService)
        {
            _passwordService = passwordService;
            _userService = userService;

        }

        /// <summary>
        /// Todo: Add Logging, Exception Handling, Method Summary
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<bool> RegisterNewUser(UserDto user, string password)
        {
            var userDto = await _userService.AddNewUserAsync(user);

            if (userDto == null) return false;

            var passwordDto = await _passwordService.CreatePasswordAsync(password, userDto.Id);

            if (passwordDto == null) return false;

            return true;
        }
    }
}
