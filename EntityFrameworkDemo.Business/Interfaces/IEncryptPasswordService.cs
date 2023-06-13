namespace EntityFrameworkDemo.Business.Interfaces
{
    public interface IEncryptPasswordService
    {
        byte[] GenerateSalt();
        byte[] HashPassword(string password, byte[] salt);
    }
}
