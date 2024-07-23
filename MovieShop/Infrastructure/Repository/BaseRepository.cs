using ApplicationCore.Contracts.Repository;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class BaseRepository<T>: IRepository<T> where T: class
{
    private readonly MovieShopDbContext _movieShopDbContext;

    public BaseRepository(MovieShopDbContext movieShopDbContext)
    {
        _movieShopDbContext = movieShopDbContext;
    }

    public int Insert(T entity)
    {
        _movieShopDbContext.Set<T>().Add(entity);
        return _movieShopDbContext.SaveChanges();
    }

    public int Update(T entity)
    {
        _movieShopDbContext.Set<T>().Entry(entity).State = EntityState.Modified;
        return _movieShopDbContext.SaveChanges();
    }

    public int Delete(int id)
    {
        T entity = GetById(id);
        if (entity != null)
        {
            _movieShopDbContext.Set<T>().Remove(entity);
            return 1;
        }

        return 0;
    }

    public IEnumerable<T> GetAll()
    {
        return _movieShopDbContext.Set<T>().ToList();
    }

    public virtual T GetById(int id)
    {
        return _movieShopDbContext.Set<T>().Find(id);
    }

    public async Task<int> InsertAsync(T entity)
    {
        _movieShopDbContext.Set<T>().Add(entity);
        return await _movieShopDbContext.SaveChangesAsync();
    }

    public async Task<int> UpdateAsync(T entity)
    {
        _movieShopDbContext.Set<T>().Entry(entity).State = EntityState.Modified;
        return await _movieShopDbContext.SaveChangesAsync();
    }

    public async Task<int> DeleteAsync(int id)
    {
        T entity = await GetByIdAsync(id);
        if (entity != null)
        {
            _movieShopDbContext.Set<T>().Remove(entity);
            return 1;
        }

        return 0;
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _movieShopDbContext.Set<T>().ToListAsync();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _movieShopDbContext.Set<T>().FindAsync(id);
    }
}