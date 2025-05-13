using MySql.Data.MySqlClient;

namespace DatabaseService;

public class DatabaseConnection
{
    private DatabaseConnection() {}
 
    private string Server { get; set; }
    private string Schema { get; set; }
    private string User { get; set; }
    private string Password { get; set; }

    internal MySqlConnection Connection { get; set; }
    
    private static DatabaseConnection? _instance = null;
    public static DatabaseConnection Instance => _instance ??= new DatabaseConnection();

    internal bool IsConnected()
    {
        if (Connection != null) return true;
        
        if (String.IsNullOrEmpty(Schema))
            return false;
        var connectionString = $"Server={Server}; database={Schema}; UID={User}; password={Password}";
        Connection = new MySqlConnection(connectionString);
        Connection.Open();

        return true;
    }

    public void Close()
    {
        Connection.Close();
    }

    public void SetConnectionDetails(string server, string schema, string user, string password)
    {
        Server = server;
        Schema = schema;
        User = user;
        Password = password;
    }
}