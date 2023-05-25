using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPuntoVenta
{
    public class Cliente
    {
        public Cliente(int idCliente, string nombre, string apellidoPaterno, string apellidoMaterno, string email, string telefono)
        {
            IdCliente = idCliente;
            Nombre = nombre;
            ApellidoPaterno = apellidoPaterno;
            ApellidoMaterno = apellidoMaterno;
            Email = email;
            Telefono = telefono;
        }
        public Cliente(string nombre, string apellidoPaterno, string apellidoMaterno, string email, string telefono)
        {
            Nombre = nombre;
            ApellidoPaterno = apellidoPaterno;
            ApellidoMaterno = apellidoMaterno;
            Email = email;
            Telefono = telefono;
        }
        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
    }  
}
