// See https://aka.ms/new-console-template for more information

using Assignment4;
using Assignment4.Presentation;

//Question 1
Console.WriteLine("Question 1");
Console.WriteLine("\n");
MyStack<int> myStack = new MyStack<int>();
myStack.Push(2);
myStack.Push(4);
Console.WriteLine("The count of elements: "+myStack.Count());
Console.WriteLine("The popping out top element: "+ myStack.Pop());

//Question 2
Console.WriteLine("\n\n\n");
Console.WriteLine("Question 2");
Console.WriteLine("\n");
GenericList<int> genericList = new GenericList<int>();

genericList.Add(1);
genericList.Add(2);
genericList.Add(3);

Console.WriteLine("Contains 2: " + genericList.Contains(2)); 
Console.WriteLine("Find at index 1: " + genericList.Find(1)); 

genericList.InsertAt(4, 1);
Console.WriteLine("Find at index 1 after insert: " + genericList.Find(1));

genericList.DeleteAt(2);
Console.WriteLine("Find at index 2 after delete: " + genericList.Find(2));

Console.WriteLine("Remove at index 0: " + genericList.Remove(0)); 

genericList.Clear();
Console.WriteLine("List cleared"); 

// Question 3
Console.WriteLine("\n\n\n");
Console.WriteLine("Question 3");
Console.WriteLine("\n");
ManageCRUD manageCrud = new ManageCRUD();
while (true)
{
    Console.WriteLine("Operation List");
    Console.WriteLine("1: To add a new entry enter 1.");
    Console.WriteLine("2: To Read all entries enter 2.");
    Console.WriteLine("3: To Get Name By Id enter 3.");
    Console.WriteLine("4: To Delete en entry enter 4.");
    Console.WriteLine("Please enter number to perform operation");
    int choice = Convert.ToInt32(Console.ReadLine());
    if (choice == 1)
    {
        Console.WriteLine("Enter Id:");
        int id = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter Name: ");
        string name = Console.ReadLine();
        Console.WriteLine("Enter Email: ");
        string email = Console.ReadLine();
        manageCrud.CreateRecord(id,name,email);
        Console.WriteLine("Record Added");
    }
    else if (choice == 2)
    {
        manageCrud.ReadRecord();
    }
    else if (choice == 3)
    {
        Console.WriteLine("Enter id:");
        int id = Convert.ToInt32(Console.ReadLine());
        manageCrud.GetNameById(id);
    }
    else if (choice == 4)
    {
        Console.WriteLine("Enter id to delete:");
        int id = Convert.ToInt32(Console.ReadLine());
        manageCrud.DeleteRecordById(id);
    }
    else
    {
        Console.WriteLine("Invalid Choice");
        break;
    }
}