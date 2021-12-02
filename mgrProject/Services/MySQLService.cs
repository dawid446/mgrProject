using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Dapper;
using Microsoft.Data.SqlClient;
using MySqlConnector;
using System.Diagnostics;
using mgrProject.Models;
using Microsoft.Extensions.Options;
using mgrProject.Interfaces;

namespace mgrProject.Services
{
    public class MySQLService : IMySQLService
    {
        private readonly shopContext _context;
        private readonly MyConfiguration _myConfiguration;

        private string connectionString = "";
        public MySQLService(shopContext context, IOptions<MyConfiguration> myConfiguration)
        {
            _myConfiguration = myConfiguration.Value;
            _context = context;
        }

        public async Task<MySQLReturnValue> sql(string query)
        {
            var returnValue = new MySQLReturnValue();
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    var watch = System.Diagnostics.Stopwatch.StartNew();
                    var result = await connection.QueryAsync<dynamic>(query);
                    watch.Stop();
                    returnValue.result = result.ToList();
                    returnValue.timeQuery = watch.ElapsedMilliseconds;
                    return returnValue;
                }
               
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Dictionary<string, string>> TableInfoMySQLs(string query)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                var result = await connection.QueryAsync(query);
                return result.ToDictionary( row=> (string) row.TableName, row=> (string) row.TableRow);
            }
        }

        public List<TableInfoMySQL> tableInfoMySQLs(Dictionary<string,string> table, Dictionary<string,string> memory)
        {
            var result = table.Where(x => memory.ContainsKey(x.Key)).Select(s => new TableInfoMySQL {
            
                tableName = s.Key,
                count = s.Value,
                memoryUse = memory[s.Key].Replace(".",",")

            }).ToList();

            return result;
        }
        public bool IsServerConnected(ConnectionValue connectionV)
        {
            string connectionString = $"Server={connectionV.host};Port={connectionV.port};database={connectionV.database};user id={connectionV.username};password={connectionV.password}";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    return true;
                }
                catch (SqlException ex)
                {
                    return false;
                }
            }
        }
    }
}

