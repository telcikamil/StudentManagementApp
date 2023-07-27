namespace StudentManagementApp.DAL.Repositories.Abstract;

public interface IRepository<T> where T : class
{
    Task<T> AddAsync(T entity);
    Task<List<T>> GetAllAsync(bool tracking = true);
    Task<T> UpdateAsync(T entity);
    Task DeleteAsync(T entity);
    Task<T?> GetByIdAsync(Guid id, bool tracking = true);
}
