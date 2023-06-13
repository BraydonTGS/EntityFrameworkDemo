using EntityFrameworkDemo.Business.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace EntityFrameworkDemo.Business.Services
{
    public class EncryptPasswordService : IEncryptPasswordService
    {
        public EncryptPasswordService()
        {

        }
        public byte[] GenerateSalt()
        {
            byte[] salt = new byte[16];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            return salt;
        }

        public byte[] HashPassword(string password, byte[] salt)
        {
            using (var hmac = new HMACSHA512(salt))
            {
                return hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
