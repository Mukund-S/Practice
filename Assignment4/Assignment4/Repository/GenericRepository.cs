using Assignment4.DataModel;
using Assignment4.Repository.Interface;

namespace Assignment4.Repository;

public class GenericRepository: IRepository<Entity>
{
    private readonly List<Entity> _entities = new List<Entity>();

    public void Add(Entity item)
    {
        _entities.Add(item);
    }

    public void Remove(Entity item)
    {
        _entities.Remove(item);
    }

    public void Save()
    {
        Console.WriteLine("Saved to Database");
    }

    public IEnumerable<Entity> GetAll()
    {
        return _entities;
    }

    public Entity GetById(int id)
    {
        Entity lt = new Entity();
        for (int i = 0; i < _entities.Count(); i++)
        {
            if (_entities[i].Id == id)
            {
                return _entities[i];
            }
        }
        return null;
    }
}