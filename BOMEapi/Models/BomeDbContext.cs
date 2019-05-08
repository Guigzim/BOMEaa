using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BOMEapi.Models;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Data;

namespace BOMEapi.Models
{
    public class BomeDbContext : IDisposable
    {
        public static IConfigurationRoot Configuration { get; private set; }
        private string ConnectionString;
        private MySqlConnection Connection;

        public BomeDbContext()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            Configuration = builder.Build();
            ConnectionString = Configuration["ConnectionString"];
            Connection = new MySqlConnection(ConnectionString);
            Connection.Open();
        }
        public void Dispose()
        {
            Connection.Close();
        }


        public void InsertData(string sql)
        {
            MySqlCommand command = new MySqlCommand(sql, Connection);
            command.ExecuteNonQuery();           
            
        }

        public DataTable getData(string sql)
        {
            MySqlCommand command = new MySqlCommand(sql, Connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }
    }
}
