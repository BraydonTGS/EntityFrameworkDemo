namespace EntityFrameworkDemo.Business.Dto
{
    public class DeviceDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }

        public int SubSystemId { get; set; }

        public SubSystemDto? SubSystem { get; set; }
    }
}
