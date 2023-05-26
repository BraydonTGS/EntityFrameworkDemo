namespace EntityFrameworkDemo.Business.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        public Task<IEnumerable<TEntity>?> GetAllAsync();
        public Task<TEntity?> GetByIdAsync(object id);
        public Task<TEntity?> CreateAsync(TEntity entity);
        public Task<TEntity?> UpdateAsync(TEntity entity);
        public Task<bool> DeleteAsync(object id);
    }
}
