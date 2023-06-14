using EntityFrameworkDemo.Business.Dto;

namespace EntityFrameworkDemo.Business.Interfaces
{
    public interface IUserService
    {
        Task<UserDto?> AddNewUser(UserDto user, string password);
        Task<bool> DeleteUser(int id);
        Task<UserDto?> GetUserById(int id);
        Task<IEnumerable<UserDto>?> GetAllUsers();

    }
}
