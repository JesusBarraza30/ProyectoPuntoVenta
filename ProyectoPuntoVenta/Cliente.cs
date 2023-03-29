using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPuntoVenta
{
    public class Cliente
    {
        public string idCliente;
        public string nombre;
        public string ap_pat;
        public string ap_mat;
        public string email;
        public string telefono;

        public Cliente() { 
            
        }

        public Cliente(string nombre, string ap_pat, string ap_mat, string email, string telefono) {
            this.nombre = nombre;
            this.ap_pat = ap_pat;
            this.ap_mat = ap_mat;
            this.email = email;
            this.telefono = telefono;
        }

    }
}
