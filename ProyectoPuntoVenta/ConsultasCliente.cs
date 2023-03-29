using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPuntoVenta
{
    internal class ConsultasCliente
    {
        private BD ConexionMySql;
        private List<Cliente> clientes;

        public ConsultasCliente()
        {
            ConexionMySql = new BD();
            clientes = new List<Cliente>();
        }



    }
}
