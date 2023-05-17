namespace EntityFrameworkDemo.Business.Dto
{
    public class SubSystemDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        public ICollection<DeviceDto>? Devices { get; set; }
    }
}
