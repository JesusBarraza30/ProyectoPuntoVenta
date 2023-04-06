﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ProyectoPuntoVenta
{
    internal class ConsultaVentas
    {
        private BD ConexionMySql;
        private List<Ventas> venta;
        public ConsultaVentas()
        {
            ConexionMySql = new BD();
            venta = new List<Ventas>();
        }

        public void agregarVentas(Ventas venta)
        {
            string consulta = "INSERT INTO ventas (id_cliente, id_vendedor, fecha_venta, subtotal, total)" +
                                "VALUES (@id_cliente, @id_vendedor, @fecha, @subtotal, @total)";
            try
            {
                MySqlCommand comando = new MySqlCommand(consulta);
                comando.Parameters.AddWithValue("@id_cliente", venta.getIdCliente());
                comando.Parameters.AddWithValue("@id_vendedor", venta.getIdVendedor());
                comando.Parameters.AddWithValue("@fecha", DateTime.Now);
                comando.Parameters.AddWithValue("@subtotal", venta.getSubTotalVenta());
                comando.Parameters.AddWithValue("@total", venta.getTotalVenta());
                comando.Connection = ConexionMySql.GetConnection();
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public int ultimaVenta()
        {
            int idVenta = 0;
            string consulta = "SELECT id_venta FROM ventas ORDER BY id_venta DESC LIMIT 1;";
            MySqlDataReader reader = null;
            try
            {
                MySqlCommand comando = new MySqlCommand(consulta);
                comando.Connection = ConexionMySql.GetConnection();
                reader = comando.ExecuteReader();

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

        public void agregarDetalle(int id_producto, int id_venta, int cantidad)
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

    }
}