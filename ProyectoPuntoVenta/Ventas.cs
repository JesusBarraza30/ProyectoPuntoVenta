using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPuntoVenta
{
    public class Ventas 
    {
        private String idVenta;
        private List<Producto> productos;
        private List<int> cantidades;
        private decimal subtotal;
        private decimal total;
        private DateTime fecha;

        //metodos get y set para el id de la venta
        public String getIdVenta()
        {
            return idVenta;
        }

        public void setIdVenta(String idVenta)
        {
            this.idVenta = idVenta;
        }

        //metodos get y set para la fecha de la venta

        public DateTime getFecha()
        {
            return fecha;
        }

        public void setFecha(DateTime fecha) {
            this.fecha = fecha;
        }


        //Constructor por defecto
        public Ventas() { 
        
        }

        //Constructos con todos los atributos
        public Ventas(String idVenta, List<Producto> productos, List<int> cantidades, DateTime fecha) {
            this.idVenta = idVenta;
            this.productos = productos;
            this.cantidades = cantidades;
            this.fecha = fecha;
            
        }

        //metodo que calcula el subtotal de la venta iterando en la lista de productos y de precios
        public decimal getSubtotal() {
            decimal total = 0;
            for (int i = 0; i < productos.Count; i++) { 
                total += ((productos[i].getPrecio()) * (cantidades[i]));
                productos[i].actualizarPrecio(((productos[i].getCantidadInvent()) - cantidades[i]));
            }

            return total;
        }

        //metodo que calcula el total final de la venta añadiendo el 16% de IVA
        public decimal getTotal() {
            decimal total = subtotal * 1.16m;
            return total;
        }



    }
}