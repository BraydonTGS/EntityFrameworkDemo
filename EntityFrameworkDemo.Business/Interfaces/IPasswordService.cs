using EntityFrameworkDemo.Business.Dto;

namespace EntityFrameworkDemo.Business.Interfaces
{
    public interface IPasswordService
    {
        Task<PasswordDto?> GetPasswordAsync(int id);
        Task<PasswordDto?> CreatePasswordAsync(string password, int userId);
        Task<bool> DeletePasswordAsync(int id);  

    }
}
