using EntityFrameworkDemo.Business.Dto;

namespace EntityFrameworkDemo.Business.Interfaces
{
    public interface IUserService
    {
        Task<UserDto?> AddNewUserAsync(UserDto user);
        Task<bool> DeleteUserAsync(int id);
        Task<UserDto?> GetUserByIdAsync(int id);
        Task<IEnumerable<UserDto>?> GetAllUsersAsync();

    }
}
