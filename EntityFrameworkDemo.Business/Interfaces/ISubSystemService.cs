using EntityFrameworkDemo.Business.Dto;

namespace EntityFrameworkDemo.Business.Interfaces
{
    public interface ISubSystemService
    {
        Task<SubSystemDto?> AddNewSubSystem(SubSystemDto subSystem);
        Task<bool> DeleteSubSystem(int id);
        Task<SubSystemDto?> GetSubSystemById(int id);
        Task<IEnumerable<SubSystemDto>?> GetSubSystemsAsync();
    }
}
