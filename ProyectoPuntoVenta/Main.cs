using System;
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
                        int opt_clt = 0;
                        while (true)
                        {
                            Console.WriteLine("Seleccione una acción para Clientes");
                            Console.WriteLine("Registrar (1)");
                            Console.WriteLine("Mostrar Clientes (2)");
                            Console.WriteLine("Compras Realizadas (3)");
                            opt_clt = Convert.ToInt32(Console.ReadLine());
                            Console.Clear();

                            switch (opt_clt)
                            {
                                case 1:
                                    ConsultasCliente consultasClt = new ConsultasCliente();

                                    Console.WriteLine("Ingrese el nombre del cliente: ");
                                    string nombre = Console.ReadLine();
                                    Console.WriteLine("Ingrese el apellido paterno del cliente: ");
                                    string ap_pat = Console.ReadLine();
                                    Console.WriteLine("Ingrese el apellido materno del cliente: ");
                                    string ap_mat = Console.ReadLine();
                                    Console.WriteLine("Ingrese el correo electronico del cliente: ");
                                    string email = Console.ReadLine();
                                    Console.WriteLine("Ingrese el telefono celular del cliente: ");
                                    string telefono = Console.ReadLine();

                                    Cliente nuevoCliente = new Cliente(nombre, ap_pat, ap_mat, email, telefono);
                                    consultasClt.agregarCliente(nuevoCliente);

                                    break;
                                case 2:
                                    ConsultasCliente cliente = new ConsultasCliente();

                                    List<Cliente> clientes = cliente.getClientes("");

                                    for (int i = 0; i < clientes.Count(); i++)
                                    {
                                        Console.WriteLine("ID: {0}", clientes[i].idCliente);
                                        Console.WriteLine("Nombre: {0}", clientes[i].nombre);
                                        Console.WriteLine("Apellido Paterno: {0}", clientes[i].ap_pat);
                                        Console.WriteLine("Apellido Materno: {0}", clientes[i].ap_mat);
                                        Console.WriteLine("Correo electronico: {0}", clientes[i].email);
                                        Console.WriteLine("Apellido telefono: {0}", clientes[i].telefono);
                                        Console.WriteLine();
                                    }
                                    break;
                                case 3:
                                    Console.WriteLine("Aqui hace codigo que muestra las compras de un cliente");
                                    break;
                                default:
                                    Console.WriteLine("Opción inválida, intente de nuevo.");
                                    continue;
                            }
                            break;
                        }
                        break;
                    case 2:
                        Console.WriteLine("Entra y muestra las opciones para el modulo Vendedor");
                        break;
                    case 3:
                        int opt_pro = 0;
                        while (true)
                        {
                            Console.WriteLine("Seleccione una acción para Productos");
                            Console.WriteLine("Agregar (1)");
                            Console.WriteLine("Mostrar (2)");
                            Console.WriteLine("Actualizar Precio(3)");
                            opt_pro = Convert.ToInt32(Console.ReadLine());
                            Console.Clear();

                            switch (opt_pro)
                            {
                                case 1:
                                    ConsultasProducto consultas = new ConsultasProducto();

                                    Console.WriteLine("Ingrese el nombre del producto: ");
                                    string nombre = Console.ReadLine();
                                    Console.WriteLine("Ingrese el precio del producto: ");
                                    decimal precio = Convert.ToDecimal(Console.ReadLine());
                                    Console.WriteLine("Ingrese la cantidad en existencia del producto: ");
                                    int existencia = Convert.ToInt32(Console.ReadLine());

                                    Producto productoNuevo = new Producto(nombre, precio, existencia);
                                    consultas.agregarProductos(productoNuevo);

                                    break;
                                case 2:
                                    ConsultasProducto producto = new ConsultasProducto();

                                    List<Producto> productos = producto.getProductos("");

                                    for (int i = 0; i < productos.Count(); i++)
                                    {
                                        Console.WriteLine("ID: {0}", productos[i].id_producto);
                                        Console.WriteLine("Nombre: {0}", productos[i].nombre);
                                        Console.WriteLine("Precio: ${0}", productos[i].precio);
                                        Console.WriteLine("Existencia: {0}", productos[i].existencia);
                                        Console.WriteLine();
                                    }

                                    break;
                                case 3:

                                    break;
                                default:
                                    Console.WriteLine("Opción inválida, intente de nuevo.");
                                    continue;
                            }
                            break;
                        }
                        break;
                    case 4:
                        Console.WriteLine("Entra y muestra las opciones para el modulo Ventas");
                        break;
                    default:
                        Console.WriteLine("Opción inválida, intente de nuevo.");
                        continue;
                }

                break;
            }


            /*
                        ConsultasProducto  producto = new ConsultasProducto();

                        List<Producto> productos = producto.getProductos("");

                        for (int i = 0; i < productos.Count(); i++)
                        {
                            Console.WriteLine("ID: {0}", productos[i].id_producto);
                            Console.WriteLine("Nombre: {0}", productos[i].nombre);
                            Console.WriteLine("Precio: ${0}", productos[i].precio);
                            Console.WriteLine("Existencia: {0}", productos[i].existencia);
                            Console.WriteLine();
                        }
            */
        }

    }
}
