using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProyectoPuntoVenta
{
    public class Producto
    {
        private String idProducto;
        private String nombre;
        private decimal precio;
        private int cantidadInvent;

        // metodos get y set para el id del producto
        public String getIdProducto()
        {
            return idProducto;
        }

        public void setIdProducto(String idProducto)
        {
            this.idProducto = idProducto;
        }

        // metodos get y set para el nombre del producto
        public String getNombre()
        {
            return nombre;
        }

        public void setNombre(String nombre)
        {
            this.nombre = nombre;
        }

        // metodos get y set para el precio del producto
        public decimal getPrecio()
        {
            return precio;
        }

        public void setPrecio(decimal precio)
        {
            this.precio = precio;
        }

        // metodos get y set para la cantidad en inventario del producto
        public int getCantidadInvent()
        {
            return cantidadInvent;
        }

        public void setCantidadInvent(int cantidadInvent)
        {
            this.cantidadInvent = cantidadInvent;
        }


        //Constructor por defecto
        public Producto()
        {

        }

        //Constructor con todos los atributos
        public Producto(String idProducto, String nombre, decimal precio, int cantidadInvent) {
            this.idProducto = idProducto;
            this.nombre = nombre;
            this.precio = precio;
            this.cantidadInvent = cantidadInvent;
        }

        //metodo para actualizar la cantidad del producto en el inventario
        public void actualizarCantidad(int nuevaCantidad) {
            cantidadInvent = nuevaCantidad;
        }

        //metodo para actualizar el precio del producto
        public void actualizarPrecio(int nuevoPrecio) {
            precio = nuevoPrecio;
        }

    }
}