using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPuntoVenta
{
    class Producto
    {
        public int id_producto;
        public string nombre;
        public decimal precio;
        public int existencia;

        public Producto() { 
            
        }

        public Producto(string nombre, decimal precio, int existencia) {
            this.nombre = nombre;
            this.precio = precio;
            this.existencia = existencia;
        }
    }
}
