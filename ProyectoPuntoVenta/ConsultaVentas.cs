using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ProyectoPuntoVenta
{
    internal class ConsultaVentas
    {
        private readonly BD ConexionMySql;
        private readonly List<Ventas> venta;
        public ConsultaVentas()
        {
            ConexionMySql = new BD();
            venta = new List<Ventas>();
        }

        public void AgregarVentas(Ventas venta)
        {
            string consulta = "INSERT INTO ventas (id_cliente, id_vendedor,  subtotal, total, fecha_venta)" +
                                "VALUES (@id_cliente, @id_vendedor, @subtotal, @total, @fecha)";
            try
            {
                MySqlCommand comando = new MySqlCommand(consulta);
                comando.Parameters.AddWithValue("@id_cliente", venta.IdCliente);
                comando.Parameters.AddWithValue("@id_vendedor", venta.IdVendedor);
                comando.Parameters.AddWithValue("@subtotal", venta.Subtotal);
                comando.Parameters.AddWithValue("@total", venta.Total);
                comando.Parameters.AddWithValue("@fecha", venta.FechaVenta);
                comando.Connection = ConexionMySql.GetConnection();
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public int UltimaVenta()
        {
            int idVenta = 0;
            string consulta = "SELECT id_venta FROM ventas ORDER BY id_venta DESC LIMIT 1;";
            
            try
            {
                MySqlCommand comando = new MySqlCommand(consulta)
                {
                    Connection = ConexionMySql.GetConnection()
                };
                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    idVenta = (int)reader["id_venta"];
                }
                reader.Close();
            }

            catch (Exception)
            {
                throw;
            }

            return idVenta;
        }

        public void AgregarDetalle(int id_producto, int id_venta, int cantidad)
        {
            string consulta = "INSERT INTO detalle_ventas (id_producto, id_venta, cantidad)" +
                                "VALUES (@id_producto, @id_venta, @cantidad)";
            try
            {
                MySqlCommand comando = new MySqlCommand(consulta);
                comando.Parameters.AddWithValue("@id_producto", id_producto);
                comando.Parameters.AddWithValue("@id_venta", id_venta);
                comando.Parameters.AddWithValue("@cantidad", cantidad);
                comando.Connection = ConexionMySql.GetConnection();
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Ventas> GetVentas(string filtro)
        {
            string consulta = "SELECT * FROM ventas";
            try
            {
                if (filtro != "")
                {
                    consulta += " WHERE " +
                        "id_venta = " + filtro + ";";
                }

                MySqlCommand comando = new MySqlCommand(consulta)
                {
                    Connection = ConexionMySql.GetConnection()
                };
                MySqlDataReader reader = comando.ExecuteReader();
                Ventas ventan = null;

                while (reader.Read())
                {
                    int id_venta = (int)reader["id_venta"];
                    int id_cliente = (int)reader["id_cliente"];
                    int id_vendedor = (int)reader["id_vendedor"];
                    DateTime fechaVenta = (DateTime)reader["fecha_venta"];
                    decimal subtotal = (decimal)reader["subtotal"];
                    decimal total = (decimal)reader["total"];

                    ventan = new Ventas(id_venta, id_cliente, id_vendedor, subtotal, total, fechaVenta);
                    venta.Add(ventan);
                }

                reader.Close();
            }
            catch (Exception)
            {
                throw;
            }

            return venta;
        }

        public List<Ventas> GetVentaDetalle()
        {
            string consulta = "SELECT * FROM ventas v inner join detalle_ventas dv on dv.id_venta = v.id_venta;";
            try
            {
                MySqlCommand comando = new MySqlCommand(consulta)
                {
                    Connection = ConexionMySql.GetConnection()
                };
                MySqlDataReader reader = comando.ExecuteReader();
                Ventas ventan = null;

                while (reader.Read())
                {
                    int id_venta = (int)reader["id_venta"];
                    int id_cliente = (int)reader["id_cliente"];
                    int id_vendedor = (int)reader["id_vendedor"];
                    DateTime fechaVenta = (DateTime)reader["fecha_venta"];
                    decimal subtotal = (decimal)reader["subtotal"];
                    decimal total = (decimal)reader["total"];
                    int id_producto = (int)reader["id_producto"];
                    int cantidad = (int)reader["cantidad"];
                    
                    ventan = new Ventas(id_venta, id_cliente, id_vendedor, subtotal, total, fechaVenta, id_producto, cantidad);
                    venta.Add(ventan);
                }

                reader.Close();
            }
            catch (Exception)
            {
                throw;
            }

            return venta;
        }
    }
}
