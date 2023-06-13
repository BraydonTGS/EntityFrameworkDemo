using EntityFrameworkDemo.Business.Dto;

namespace EntityFrameworkDemo.Business.Interfaces
{
    public interface IUserService
    {
        Task<UserDto?> AddNewUser(UserDto user);
        Task<bool> DeleteUser(int id);
        Task<UserDto?> GetUserById(int id);
        Task<IEnumerable<UserDto>?> GetAllUsers();

    }
}
