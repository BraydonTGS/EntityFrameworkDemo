using EntityFrameworkDemo.Entity.Entities;

namespace EntityFrameworkDemo.Business.Interfaces
{
    public interface IEncryptPasswordService
    {
        Password EncryptPassword(string password);
        byte[] GenerateSalt();
        byte[] HashPassword(string password, byte[] salt);
    }
}
