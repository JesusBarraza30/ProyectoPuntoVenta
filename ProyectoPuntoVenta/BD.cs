using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.IO;

namespace ProyectoPuntoVenta
{
    internal class BD
    {

        public MySqlConnection GetConnection()
        {
            string connectionString = "server=localhost;database=mini_market_db;uid=root;pwd=Albertobc24;";
            MySqlConnection connection = new MySqlConnection(connectionString);

            try
            {
                if (connection.State != System.Data.ConnectionState.Open)
                {
                    connection.Open();

                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al conectar a la base de datos: " + e.Message);
            }
            return connection;
        }
    }
}
