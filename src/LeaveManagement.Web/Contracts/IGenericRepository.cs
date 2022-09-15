namespace LeaveManagement.Web.Contracts
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> AddAsync(T entity);
        Task<bool> Exists(int id);
        Task DeleteAsync(int id);
        Task<List<T>> GetAllAsync();
        Task<T?> GetAsync(int? id);
        Task<T?> GetByIdAsync(int? id);
        Task UpdateAsync(T entity);
    }
}
