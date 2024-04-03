using Npgsql;

namespace WebApi.DataContext;

public class DapperContext
{
    private readonly string _connectionString =
        "Server=localhost;port=5432;Database=test_db;User Id=postgres;password=123456";

    public NpgsqlConnection Connection()
    {
        return new NpgsqlConnection(_connectionString); 
    }
}