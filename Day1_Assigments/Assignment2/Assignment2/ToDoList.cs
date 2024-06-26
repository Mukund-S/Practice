namespace Assignment2;

public class ToDoList
{
    public ToDoList()
    {
        List<string> items = new List<string>();
        while (true)
        {
            Console.WriteLine("Current List");
            foreach(string item in items)
            {
                Console.WriteLine(item);        
            }
            Console.WriteLine("Enter command (+ item, - item, or -- to clear)):");
            string val = Console.ReadLine();
            if (val.StartsWith("+"))
            {
                items.Add(val.Substring(2));
            }else if (val=="--")
            {
                items.Clear();
            }
            else if (val.StartsWith("-"))
            {
                items.Remove(val.Substring(2));
            }
            else
            {
                Console.WriteLine("Invalid Input");
            }
        }
    }
}