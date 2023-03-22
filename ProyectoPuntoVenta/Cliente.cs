using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPuntoVenta
{
    public class Cliente
    {
        private String idCliente;
        private String nombre;
        private String apellido;
        private List<Ventas> compras;


        //metodos get y set para el id del cliente
        public String getIdCliente()
        {
            return idCliente;
        }

        public void setIdCliente(String idCliente)
        {
            this.idCliente = idCliente;
        }

        // metodos get y set para el nombre del cliente
        public String getNombre()
        {
            return nombre;
        }

        public void setNombre(String nombre)
        {
            this.nombre = nombre;
        }

        // metodos get y set para el apellido del cliente
        public String getApellido()
        {
            return apellido;
        }

        public void setApellido(String apellido)
        {
            this.apellido = apellido;
        }



        //Constructor por defecto
        public Cliente() {
        
        }



        //Constructor con todos los atributos
        public Cliente(String idCliente, String nombre, String apellido ,List<Ventas> compras)
        {
            this.idCliente = idCliente;
            this.nombre = nombre;
            this.apellido = apellido;
            this.compras = new List<Ventas>();
        }






    }
}
