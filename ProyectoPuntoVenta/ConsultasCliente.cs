using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ProyectoPuntoVenta
{
    internal class ConsultasCliente
    {
        private readonly BD ConexionMySql;
        private readonly List<Cliente> clientes;

        public ConsultasCliente()
        {
            ConexionMySql = new BD();
            clientes = new List<Cliente>();
        }

        public List<Cliente> GetClientes(string filtro)
        {
            string consulta = "SELECT * FROM clientes";
            try
            {
                if (filtro != "")
                {
                    consulta += " WHERE " +
                        "id LIKE '%" + filtro + "%' OR " +
                        " nombre LIKE '%" + filtro + "%' ;";
                }

                MySqlCommand comando = new MySqlCommand(consulta)
                {
                    Connection = ConexionMySql.GetConnection()
                };
                MySqlDataReader reader = comando.ExecuteReader();
                Cliente cliente = null;

                while (reader.Read())
                {
                    int idCliente = (int)reader["id_cliente"];
                    string nombre = (string)reader["nombre"];
                    string ap_pat = (string)reader["ap_pat"];
                    string ap_mat = (string)reader["ap_mat"];
                    string email = (string)reader["email"];
                    string telefono = (string)reader["telefono"];

                    cliente = new Cliente(idCliente, nombre, ap_pat, ap_mat, email, telefono);
                    clientes.Add(cliente);
                }

                reader.Close();
            }
            catch (Exception)
            {
                throw;
            }

            return clientes;
        }

        public List<Cliente> GetCliente(string id)
        {
            string consulta = "SELECT * FROM clientes WHERE id_cliente = " + id;
            try
            {
                MySqlCommand comando = new MySqlCommand(consulta)
                {
                    Connection = ConexionMySql.GetConnection()
                };
                MySqlDataReader reader = comando.ExecuteReader();
                Cliente cliente = null;

                while (reader.Read())
                {
                    int idCliente = (int)reader["id_cliente"];
                    string nombre = (string)reader["nombre"];
                    string ap_pat = (string)reader["ap_pat"];
                    string ap_mat = (string)reader["ap_mat"];
                    string email = (string)reader["email"];
                    string telefono = (string)reader["telefono"];

                    cliente = new Cliente(idCliente, nombre, ap_pat, ap_mat, email, telefono);
                    clientes.Add(cliente);
                }

                reader.Close();
            }
            catch (Exception)
            {
                throw;
            }

            return clientes;
        }

        public bool ClienteExistente(string nombre, string ap_pat, string ap_mat)
        {

            bool verificar;
            string consulta = "SELECT * FROM clientes";
            try
            {
                if (nombre != "" || ap_pat != "" || ap_mat != "")
                {
                    consulta += " WHERE " +
                        "nombre = '" + nombre + "' and " +
                        " ap_pat ='" + ap_pat + "' and " +
                        "ap_mat = '" + ap_mat + "' ;";
                }

                MySqlCommand comando = new MySqlCommand(consulta)
                {
                    Connection = ConexionMySql.GetConnection()
                };
                MySqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    verificar = true;
                }
                else
                {
                    verificar = false;
                }
            }
            catch (Exception)
            {
                throw;
            }

            return verificar;
        }

        public void AgregarCliente(Cliente cliente)
        {
            string consulta = "INSERT INTO clientes (nombre, ap_pat, ap_mat, email, telefono) " +
                              "VALUES (@nombre, @ap_pat, @ap_mat, @email, @telefono)";

            try
            {
                MySqlCommand comando = new MySqlCommand(consulta);
                comando.Parameters.AddWithValue("@nombre", cliente.Nombre);
                comando.Parameters.AddWithValue("@ap_pat", cliente.ApellidoMaterno);
                comando.Parameters.AddWithValue("@ap_mat", cliente.ApellidoPaterno);
                comando.Parameters.AddWithValue("@email", cliente.Email);
                comando.Parameters.AddWithValue("@telefono", cliente.Telefono);
                comando.Connection = ConexionMySql.GetConnection();
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
