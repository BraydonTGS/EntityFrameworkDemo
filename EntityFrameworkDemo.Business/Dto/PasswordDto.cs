using System.Globalization;

namespace EntityFrameworkDemo.Business.Dto
{
    public class PasswordDto
    {
        public int Id { get; set; } 
        public byte[] Hash { get; set; } = Array.Empty<byte>();
        public byte[] Salt { get; set; } = Array.Empty<byte>(); 
    }
}
