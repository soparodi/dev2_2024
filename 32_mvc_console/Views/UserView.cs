using System.Data.SQLite;
class UserView
{
    public Database _db;

    public UserView(Database db)
    {
        _db = db;
    }

    public void ShowMainMenu()
    {
        Console.WriteLine("1. Aggiungi user");
        Console.WriteLine("2. Leggi user");
        Console.WriteLine("3. Esci");
    }

    public void ShowUsers(List<User> users)
    {
        foreach (var user in users)
        {
            Console.WriteLine($"{user.Id} - {user.Name}");
        }
    }


    public string GetUserName()
    {
        Console.WriteLine("Enter user name:");
        return Console.ReadLine();
    }
    public string GetInput()
    {
        return Console.ReadLine();
    }
}