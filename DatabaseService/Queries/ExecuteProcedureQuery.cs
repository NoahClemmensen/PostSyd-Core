using MySql.Data.MySqlClient;

namespace DatabaseService.Queries;

public class ExecuteProcedureQuery(string procedureName, MySqlParameter[] parameters) : IProcedureQueryObject
{
    public string Query { get; } = MakeQuery(procedureName, parameters);
    public MySqlParameter[] Parameters { get; } = parameters;
    
    private static string MakeQuery(string procedureName, MySqlParameter[] parameters)
    {
        return $"CALL {procedureName}({string.Join(",", Enumerable.Repeat("?", parameters.Length))});";
    }
}