using EntityFrameworkDemo.Business.Dto;

namespace EntityFrameworkDemo.Business.Interfaces
{
    public interface ISubSystemService
    {
        Task<SubSystemDto?> MapDtoToEntity(SubSystemDto device);
    }
}
