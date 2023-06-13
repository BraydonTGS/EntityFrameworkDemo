using System.Globalization;

namespace EntityFrameworkDemo.Business.Dto
{
    public class PasswordDto
    {
        public int Id { get; set; } 
        public byte[] Hash { get; set; } = new byte[0];
        public byte[] Salt { get; set; } = new byte[0]; 
    }
}
