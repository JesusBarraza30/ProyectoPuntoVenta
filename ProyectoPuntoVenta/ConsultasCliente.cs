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
        private BD ConexionMySql;
        private List<Cliente> clientes;

        public ConsultasCliente()
        {
            ConexionMySql = new BD();
            clientes = new List<Cliente>();
        }

        public List<Cliente> getClientes(string filtro)
        {
            string consulta = "SELECT * FROM clientes";

            MySqlDataReader reader = null;

            try
            {
                if (filtro != "")
                {
                    consulta += " WHERE " +
                        "id LIKE '%" + filtro + "%' OR " +
                        " nombre LIKE '%" + filtro + "%' ;";
                }

                MySqlCommand comando = new MySqlCommand(consulta);
                comando.Connection = ConexionMySql.GetConnection();
                reader = comando.ExecuteReader();


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

        public void agregarCliente(Cliente cliente)
        {
            string consulta = "INSERT INTO clientes (nombre, ap_pat, ap_mat, email, telefono) " +
                              "VALUES (@nombre, @ap_pat, @ap_mat, @email, @telefono)";

            try
            {
                MySqlCommand comando = new MySqlCommand(consulta);
                comando.Parameters.AddWithValue("@nombre", cliente.getNombre());
                comando.Parameters.AddWithValue("@ap_pat", cliente.getAptPat());
                comando.Parameters.AddWithValue("@ap_mat", cliente.getAptMat());
                comando.Parameters.AddWithValue("@email", cliente.getEmail());
                comando.Parameters.AddWithValue("@telefono", cliente.getTelefono());
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
