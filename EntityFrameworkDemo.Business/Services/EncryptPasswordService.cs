using EntityFrameworkDemo.Business.Dto;
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

        #region EncryptPassword
        public PasswordDto EncryptPassword(string password)
        {
            PasswordDto passwordDto = new PasswordDto();
            passwordDto.Salt = GenerateSalt();
            passwordDto.Hash = HashPassword(password, passwordDto.Salt);
            return passwordDto;
        }
        #endregion

        #region GenerateSalt
        private byte[] GenerateSalt()
        {
            byte[] salt = new byte[16];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            return salt;
        }
        #endregion


        #region HashPassword
        private byte[] HashPassword(string password, byte[] salt)
        {
            using (var hmac = new HMACSHA512(salt))
            {
                return hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }
        #endregion

    }
}
