using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPuntoVenta
{
   public class Principal
    {
        public static void Main(String[] args) {

            Producto p1 = new Producto("001", "Coca", 20, 100);
            Producto p2 = new Producto("002", "Agua Natural", 15, 134);
            Producto p3 = new Producto("002", "Jaztea", 19, 43);

            List<Producto> pv1 = new List<Producto>();
            pv1.Add(p1);
            pv1.Add(p2);
            pv1.Add(p3);

            List<int> cant = new List<int>();
            cant.Add(2);
            cant.Add(1);
            cant.Add(3);

            DateTime fec = new DateTime(10 / 02 / 2025);

            Ventas v1 = new Ventas("001", pv1, cant, fec );

            Console.WriteLine(v1.getSubtotal());
            Console.WriteLine(p1.getCantidadInvent());
            Console.ReadKey();

        }

    }
}
