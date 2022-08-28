using Dapper;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Npgsql;

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mrpAccesLibrary
{
    public class SqlDataAccess : ISqlDataAccess
    {
        private readonly IConfiguration _config;

        public string ConnectionStringName { get; set; } = "Default";
        public SqlDataAccess(IConfiguration config)
        {
            _config = config;
        }
        public async Task<List<T>> Loaddata<T, U>(string sql, U paramaters)
        {
            string connectionString = _config.GetConnectionString(ConnectionStringName);
            using (IDbConnection connection = new NpgsqlConnection(connectionString))
            {
                
                var data = await connection.QueryAsync<T>(sql, paramaters);
               
                return data.ToList();

            }
        }
       
        public async Task SaveData<T>(string sql, T paramaters)
        {
            string connectionString = _config.GetConnectionString(ConnectionStringName);
            using (IDbConnection connection = new NpgsqlConnection(connectionString))
            {
                await connection.ExecuteAsync(sql, paramaters);


            }
        }
        public  List<T> veri_getir<T, U>(string sql, U paramaters)
        {
            string connectionString = _config.GetConnectionString(ConnectionStringName);
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                List<T> data =  (List<T>)  connection.Query<T>(sql, paramaters);
                return data;

            }
        }

    }
}
