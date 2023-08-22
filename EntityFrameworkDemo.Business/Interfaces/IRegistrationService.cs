using EntityFrameworkDemo.Business.Dto;

namespace EntityFrameworkDemo.Business.Interfaces
{
    public interface IRegistrationService
    {
        Task<bool> RegisterNewUser(UserDto user, string password);
    }
}