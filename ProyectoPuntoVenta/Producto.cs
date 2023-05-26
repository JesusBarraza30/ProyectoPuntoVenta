using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPuntoVenta
{
    public class Producto
    {
        public Producto(string nombre, decimal precio, int existencia)
        {
            Nombre = nombre;
            Precio = precio;
            Existencia = existencia;
        }

        public Producto(int id_producto, string nombre, decimal precio, int existencia)
        {
            IdProducto = id_producto;
            Nombre = nombre;
            Precio = precio;
            Existencia = existencia;
        } 
        public Producto(int id_producto, string nombre, int existencia, decimal cantidad)
        {
            IdProducto = id_producto;
            Nombre = nombre;
            Existencia = existencia;
            Cantidad = cantidad;
        }
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Existencia { get; set; }
        public decimal Cantidad { get; set; }
    }

}
