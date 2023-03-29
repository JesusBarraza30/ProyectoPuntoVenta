﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPuntoVenta
{
   public class Principal
    {
        static void Main(string[] args)
        {
            int opt = 0;

            while (true)
            {
                Console.WriteLine("Seleccione un módulo del Sistema");
                Console.WriteLine("Cliente (1)");
                Console.WriteLine("Vendedor (2)");
                Console.WriteLine("Productos (3)");
                Console.WriteLine("Ventas (4)");
                opt = Convert.ToInt32(Console.ReadLine());
                Console.Clear();

                switch (opt)
                {
                    case 1:
                        Cliente cliente = new Cliente();
                        cliente.mostrarOpciones();
                        break;
                    case 2:
                        break;
                    case 3:
                        Producto producto = new Producto();
                        producto.mostrarOpciones();
                        break;
                    case 4:
                        return;
                    default:
                        Console.WriteLine("Opción inválida, intente de nuevo.");
                        continue;
                }
            }
        }

    }

}
