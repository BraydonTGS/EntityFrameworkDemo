using EntityFrameworkDemo.Business.Dto;
using EntityFrameworkDemo.Business.Interfaces;
using Microsoft.Extensions.Logging;

namespace EntityFrameworkDemo.Business.Services
{
    public class RegistrationService : IRegistrationService
    {
        IPasswordService _passwordService;
        IUserService _userService;
        private readonly ILogger<RegistrationService> _logger;
        public RegistrationService(IPasswordService passwordService, IUserService userService, ILoggerFactory loggerFactory)
        {
            _passwordService = passwordService;
            _userService = userService;
            _logger = loggerFactory.CreateLogger<RegistrationService>();
        }

        /// <summary>
        /// Register a New User within the application
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<bool> RegisterNewUser(UserDto user, string password)
        {
            try
            {
                using (_logger.BeginScope("RegisterNewUser"));
                var userDto = await _userService.AddNewUserAsync(user);

                if (userDto == null) return false;

                var passwordDto = await _passwordService.CreatePasswordAsync(password, userDto.Id);

                if (passwordDto == null) return false;

                _logger.LogInformation($"Successfully Registered User: {user.UserName}");
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occured in RegisterNewUser method: {ex.Message}");
                throw;
            }
        }
    }
}
