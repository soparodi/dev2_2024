using System.Data.SQLite;

class UserController
{
    public Database _db;
    public UserView _view;

    public UserController(Database db, UserView view)
    {
        _db = db;
        _view = view;
    }

    public void MainMenu()
    {
        while (true)
        {
            _view.ShowMainMenu();
            var input = _view.GetInput();
            if (input == "1")
            {
                AddUser();
            }
            else if (input == "2")
            {
                ShowUsers();
            }
            else if (input == "3")
            {
                _db.CloseConnection();
                break;
            }
        }
    }

    private void AddUser()
    {
        var name = _view.GetUserName();
        _db.AddUser(name);
    }

    private void ShowUsers()
    {
        var users = _db.GetUsers();
        _view.ShowUsers(users);
    }
}