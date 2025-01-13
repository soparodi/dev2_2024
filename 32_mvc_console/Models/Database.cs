using System.Data.SQLite;
class Database
{
    public SQLiteConnection _connection; // non deve essere accessibile dall'esterno
                                         // utilizziamo "_" per indcare che è una variabile privata

    public Database() // costruttore della classe database
    {
        _connection = new SQLiteConnection(@"Data Source=Data/database.db");
        _connection.Open();
        var command = new SQLiteCommand("CREATE TABLE IF NOT EXISTS users (id INTEGER PRIMARY KEY, name TEXT)", _connection);
        command.ExecuteNonQuery();
    }

    public void AddUser(string name)
    {
        var command = new SQLiteCommand($"INSERT INTO users (name) VALUES ('{name}')", _connection);
        command.ExecuteNonQuery();
    }

    public List<User> GetUsers()
    {
        var command = new SQLiteCommand("SELECT * FROM users", _connection);
        var reader = command.ExecuteReader();
        var users = new List<User>();
        while (reader.Read())
        {
            users.Add(new User
            {
                Id = reader.GetInt32(0),
                Name = reader.GetString(1)
            });
        }
        return users;
    }

    public void CloseConnection()
    {
        if (_connection.State != System.Data.ConnectionState.Closed)
        {
            _connection.Close();
        }
    }
}