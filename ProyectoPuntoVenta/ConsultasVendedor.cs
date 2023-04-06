using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ProyectoPuntoVenta
{
    internal class ConsultasVendedor
    {
        private BD ConexionMySql;
        private List<Vendedor> vendedores;

        public ConsultasVendedor()
        {
            ConexionMySql = new BD();
            vendedores = new List<Vendedor>();
        }

        public List<Vendedor> getVendedores(string filtro)
        {
            string consulta = "SELECT * FROM vendedores";

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


                Vendedor vendedor = null;

                while (reader.Read())
                {
                    int idCliente = (int)reader["id_vendedor"];
                    string nombre = (string)reader["nombre"];
                    string ap_pat = (string)reader["ap_pat"];
                    string ap_mat = (string)reader["ap_mat"];
                    string email = (string)reader["email"];
                    string telefono = (string)reader["telefono"];
                    decimal sueldoBase = (decimal)reader["sueldo_base"];
                    int comision = (int)reader["comision"];

                    vendedor = new Vendedor(idCliente, nombre, ap_pat, ap_mat, email, telefono, comision, sueldoBase);
                    vendedores.Add(vendedor);
                }

                reader.Close();
            }
            catch (Exception)
            {
                throw;
            }

            return vendedores;
        }

        public bool vendedorExistente(string nombre, string ap_pat, string ap_mat)
        {

            bool verificar;
            string consulta = "SELECT * FROM vendedores";

            MySqlDataReader reader = null;

            try
            {
                if (nombre != "" || ap_pat != "" || ap_mat != "")
                {
                    consulta += " WHERE " +
                        "nombre = '" + nombre + "' and " +
                        " ap_pat ='" + ap_pat + "' and " +
                        "ap_mat = '" + ap_mat + "' ;";
                }

                MySqlCommand comando = new MySqlCommand(consulta);
                comando.Connection = ConexionMySql.GetConnection();
                reader = comando.ExecuteReader();

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

        public void agregarVendedor(Vendedor vendedor)
        {
            string consulta = "INSERT INTO vendedores (nombre, ap_pat, ap_mat, email, telefono, sueldo_base, comision) " +
                              "VALUES (@nombre, @ap_pat, @ap_mat, @email, @telefono, @sueldoBase, @comision)";

            try
            {
                MySqlCommand comando = new MySqlCommand(consulta);
                comando.Parameters.AddWithValue("@nombre", vendedor.getNombre());
                comando.Parameters.AddWithValue("@ap_pat", vendedor.getAptPat());
                comando.Parameters.AddWithValue("@ap_mat", vendedor.getAptMat());
                comando.Parameters.AddWithValue("@email", vendedor.getEmail());
                comando.Parameters.AddWithValue("@telefono", vendedor.getTelefono());
                comando.Parameters.AddWithValue("@sueldoBase", vendedor.getSueldoBase());
                comando.Parameters.AddWithValue("@comision", vendedor.getComision());
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
