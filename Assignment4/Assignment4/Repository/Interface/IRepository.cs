using Assignment4.DataModel;

namespace Assignment4.Repository.Interface;

public interface IRepository<T> where T: Entity
{
    void Add(T item);
    void Remove(T item);
    void Save();
    IEnumerable<T> GetAll();
    T GetById(int id);
}