using Assignment4.DataModel;
using Assignment4.Repository;

namespace Assignment4.Presentation;

public class ManageCRUD
{
    private GenericRepository _genericRepository = new GenericRepository();

    public void CreateRecord(int id,string name,string email)
    {
        Entity entity = new Entity();
        entity.Id = id;
        entity.Name = name;
        entity.email = email;
        _genericRepository.Add(entity);
    }

    public void ReadRecord()
    {
        IEnumerable<Entity> lt = _genericRepository.GetAll();
        Console.WriteLine("Records Present:");
        foreach (var val in lt)
        {
            Console.WriteLine(val.Id+"\t"+val.Name+"\t"+val.email);
        }
    }

    public void GetNameById(int index)
    {
        Entity entity = _genericRepository.GetById(index);
        if(entity!=null)
        {
            Console.WriteLine(entity.Name);
        }
        else
        {
            Console.WriteLine("Record not present");
        }
    }

    public void DeleteRecordById(int index)
    {
        Entity entity = _genericRepository.GetById(index);
        if (entity != null)
        {
            Console.WriteLine("Record Removed");
            _genericRepository.Remove(entity);
        }
        else
        {
            Console.WriteLine("Record Not Present");
        }
        
    }
    
}