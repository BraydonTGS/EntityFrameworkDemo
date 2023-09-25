using EntityFrameworkDemo.Business.Dto;

namespace EntityFrameworkDemo.Business.Interfaces
{
    public interface ISubSystemService
    {
        Task<SubSystemDto?> AddNewSubSystem(SubSystemDto subSystem);
        Task<bool> DeleteSubSystem(int id);
        Task<SubSystemDto?> GetByIdAsyncIncludeDevice(int id);
        Task<IEnumerable<SubSystemDto>?> GetSubSystemsAsync();
    }
}
