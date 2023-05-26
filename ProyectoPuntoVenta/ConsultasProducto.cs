using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ProyectoPuntoVenta
{
    internal class ConsultasProducto
    {
        private BD ConexionMySql;
        private List<Producto> productos;

        public ConsultasProducto()
        {
            ConexionMySql = new BD();
            productos = new List<Producto>();
        }

        public List<Producto> getProductos(string filtro)
        {
            string consulta = "SELECT * FROM productos";

            MySqlDataReader reader = null;

            try
            {
                if (filtro != "")
                {
                    consulta += " WHERE existencia > 0 AND " +
                        "id_producto LIKE '%" + filtro + "%' OR " +
                        " nombre LIKE '%" + filtro + "%';";
                }

                MySqlCommand comando = new MySqlCommand(consulta);
                comando.Connection = ConexionMySql.GetConnection();
                reader = comando.ExecuteReader();


                Producto producto = null;

                while (reader.Read())
                {
                    int id_producto = (int)reader["id_producto"];
                    string nombre = (string)reader["nombre"];
                    decimal precio = (decimal)reader["precio"];
                    int existencia = (int)reader["existencia"];

                    producto = new Producto(id_producto, nombre, precio, existencia);
                    productos.Add(producto);
                }

                reader.Close();
            }
            catch (Exception)
            {

                throw;
            }

            return productos;
        }

         public List<Producto> getProducto(string filtro)
        {
            string consulta = "SELECT * FROM productos";

            MySqlDataReader reader = null;

            try
            {
                if (filtro != "")
                {
                    consulta += " WHERE " +
                        "id_producto = " + filtro + ";";
                }

                MySqlCommand comando = new MySqlCommand(consulta);
                comando.Connection = ConexionMySql.GetConnection();
                reader = comando.ExecuteReader();


                Producto producto = null;

                while (reader.Read())
                {
                    int id_producto = (int)reader["id_producto"];
                    string nombre = (string)reader["nombre"];
                    decimal precio = (decimal)reader["precio"];
                    int existencia = (int)reader["existencia"];
                    producto = new Producto(id_producto, nombre, precio, existencia);

                    productos.Add(producto);
                }

                reader.Close();
            }
            catch (Exception)
            {

                throw;
            }

            return productos;
        }
        public void agregarProductos(Producto producto)
        {
            string consulta = "INSERT INTO productos (nombre, precio, existencia)" +
                                "VALUES (@nombre, @precio, @existencia)";

            

            try
            {
                MySqlCommand comando = new MySqlCommand(consulta);
                comando.Parameters.AddWithValue("@nombre", producto.Nombre);
                comando.Parameters.AddWithValue("@precio", producto.Precio);
                comando.Parameters.AddWithValue("@existencia", producto.Existencia);
                comando.Connection = ConexionMySql.GetConnection();
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Producto> GetInventario()
        {
            string consulta = "SELECT P.*, COALESCE(DV.CANTIDAD, 0) AS 'vendidos' FROM PRODUCTOS " +
                "P LEFT JOIN " +
                "(SELECT id_producto, SUM(CANTIDAD) AS CANTIDAD FROM detalle_ventas GROUP BY id_producto) "+
                "DV ON DV.id_producto = P.ID_PRODUCTO ORDER BY id_producto;";

            MySqlDataReader reader = null;

            try
            {
                MySqlCommand comando = new MySqlCommand(consulta);
                comando.Connection = ConexionMySql.GetConnection();
                reader = comando.ExecuteReader();


                Producto producto = null;

                while (reader.Read())
                {
                    int id_producto = (int)reader["id_producto"];
                    string nombre = (string)reader["nombre"];
                    int existencia = (int)reader["existencia"];
                    decimal vendidos = (decimal)reader["vendidos"];
                    producto = new Producto(id_producto, nombre, existencia, vendidos);

                    productos.Add(producto);
                }

                reader.Close();
            }
            catch (Exception)
            {

                throw;
            }

            return productos;
        }

        public void ActualizarExistencia(int id_producto, int cantidad)
        {
            string consulta = "UPDATE productos SET existencia = @cantidad WHERE id_producto = @id_producto";

            try
            {
                MySqlCommand comando = new MySqlCommand(consulta);
                comando.Parameters.AddWithValue("@cantidad", cantidad);
                comando.Parameters.AddWithValue("@id_producto", id_producto);
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
