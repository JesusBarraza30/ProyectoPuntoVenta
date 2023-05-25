using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPuntoVenta
{
    public class Vendedor : Cliente
    {
        public Vendedor(int idCliente, string nombre, string ap_pat, string ap_mat, string email, string telefono, int comision, decimal sueldoBase)
            : base(idCliente, nombre, ap_pat, ap_mat, email, telefono)
        {
            Comision = comision;
            SueldoBase = sueldoBase;
        }

        public Vendedor(string nombre, string ap_pat, string ap_mat, string email, string telefono, int comision, decimal sueldoBase)
          : base(nombre, ap_pat, ap_mat, email, telefono)
        {
            Comision = comision;
            SueldoBase = sueldoBase;
        }
        public int Comision { get; set; }
        public decimal SueldoBase { get; set; }
    }
}