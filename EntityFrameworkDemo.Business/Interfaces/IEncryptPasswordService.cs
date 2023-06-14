using EntityFrameworkDemo.Business.Dto;

namespace EntityFrameworkDemo.Business.Interfaces
{
    public interface IEncryptPasswordService
    {
        public PasswordDto EncryptPassword(string password);
    }
}
