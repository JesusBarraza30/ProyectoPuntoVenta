using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPuntoVenta
{
    class Vendedor
    {
        private String idVendedor;
        private String nombre;
        private String apellido;
        private decimal sueldo;
        private List<Ventas> ventas;


        //metodos get y set para el id del vendedor
        public String getIdCliente()
        {
            return idVendedor;
        }

        public void setIdCliente(String idVendedor)
        {
            this.idVendedor = idVendedor;
        }

        // metodos get y set para el nombre del vendedor
        public String getNombre()
        {
            return nombre;
        }

        public void setNombre(String nombre)
        {
            this.nombre = nombre;
        }

        // metodos get y set para el apellido del vendedor
        public String getApellido()
        {
            return apellido;
        }

        public void setApellido(String apellido)
        {
            this.apellido = apellido;
        }

        //metodos get y set para el sueldo del vendedor
        public decimal getSueldo() { 
            return sueldo;
        }

        public void setSueldo(decimal sueldo) {
            this.sueldo = sueldo;
        }



        //Constructor por defecto
        public Vendedor()
        {
        }

        //Constructos con todos los atributos
        public Vendedor(String idVendedor, String nombre, String apellido, decimal sueldo, List<Ventas> ventas)
        {
            this.idVendedor = idVendedor;
            this.nombre = nombre;
            this.apellido = apellido;
            this.sueldo = sueldo;
            this.ventas = new List<Ventas>();
        }

       
    }
}
