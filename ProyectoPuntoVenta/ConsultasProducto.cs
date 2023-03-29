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
                    consulta += " WHERE " +
                        "id LIKE '%" + filtro + "%' OR " +
                        " nombre LIKE '%" + filtro + "%' OR" +
                        "precio LIKE '%" + filtro + "%';";
                }

                MySqlCommand comando = new MySqlCommand(consulta);
                comando.Connection = ConexionMySql.GetConnection();
                reader = comando.ExecuteReader();


                Producto producto = null;

                while (reader.Read())
                {
                    producto = new Producto();
                    producto.id_producto = (int)reader["id_producto"];
                    producto.nombre = (string)reader["nombre"];
                    producto.precio = (decimal)reader["precio"];
                    producto.existencia = (int)reader["existencia"];
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
                comando.Parameters.AddWithValue("@nombre", producto.nombre);
                comando.Parameters.AddWithValue("@precio", producto.precio);
                comando.Parameters.AddWithValue("@existencia", producto.existencia);
                comando.Connection = ConexionMySql.GetConnection();
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }


        }

        public void actualizarPrecioProducto(int id_producto, decimal nuevoPrecio)
        {
            string consulta = "UPDATE productos SET precio = @nuevoPrecio WHERE id_producto = @id_producto";

            try
            {
                MySqlCommand comando = new MySqlCommand(consulta);
                comando.Parameters.AddWithValue("@nuevoPrecio", nuevoPrecio);
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
