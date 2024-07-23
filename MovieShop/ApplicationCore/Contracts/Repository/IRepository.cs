namespace ApplicationCore.Contracts.Repository;

public interface IRepository<T> where T: class
{
    int Insert(T entity);
    int Update(T entity);
    int Delete(int id);
    IEnumerable<T> GetAll();
    T GetById(int id);
    Task<int> InsertAsync(T entity);
    Task<int> UpdateAsync(T entity);
    Task<int> DeleteAsync(int id);
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetByIdAsync(int id);
}