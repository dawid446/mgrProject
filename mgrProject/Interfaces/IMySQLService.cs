using mgrProject.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace mgrProject.Interfaces
{
    public interface IMySQLService
    {
        Task<MySQLReturnValue> sql(string query);
        Task<Dictionary<string,string>> TableInfoMySQLs(string query);
        List<TableInfoMySQL> tableInfoMySQLs(Dictionary<string, string> table, Dictionary<string, string> memory);
        bool IsServerConnected(ConnectionValue connectionString);
    }
}