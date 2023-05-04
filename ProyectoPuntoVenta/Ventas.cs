using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPuntoVenta
{

    internal class Ventas
    {
        private int idVenta;
        private int idCliente;
        private int idVendedor;
        private int idProducto;
        private int cantidad;
        private decimal subtotal;
        private decimal total;
        private int optSelect;
        private DateTime fechaVenta;

        public Ventas()
        {

        }

        public Ventas(int idVenta, int idCliente, int idVendedor, decimal subtotal, decimal total)
        {
            this.idVenta = idVenta;
            this.idCliente = idCliente;
            this.idVendedor = idVendedor;
            this.subtotal = subtotal;
            this.total = total;
        }

        public Ventas(int idCliente, int idVendedor, int idProducto, int cantidad,  decimal subtotal, decimal total, DateTime fechaVenta)
        {
            this.idCliente = idCliente;
            this.idVendedor = idVendedor;
            this.idProducto = idProducto;
            this.cantidad = cantidad;
            this.subtotal = subtotal;
            this.total = total;
            this.fechaVenta = fechaVenta;
        }

        public Ventas(int idCliente, int idVendedor, decimal subtotal, decimal total)
        {
            this.idCliente = idCliente;
            this.idVendedor = idVendedor;
            this.subtotal = subtotal;
            this.total = total;
        }

        public int getIdCliente()
        {
            return idCliente;
        }
        public int getIdVendedor()
        {
            return idVendedor;
        }

        public int getIdProd()
        {
            return idProducto;
        }

        public int getCantidad() 
        {
            return cantidad;
        }
        public decimal getSubTotalVenta()
        {
            return subtotal;
        }

        public decimal getTotalVenta()
        {
            double iva = (double)subtotal * 0.16; ;
            decimal total = subtotal + (decimal)iva;
            return total;
        }

        public void mostrarOpciones()
        {
            while (true)
            {
                Console.WriteLine("Seleccione una acción para Ventas");
                Console.WriteLine("Registrar (1)");
                Console.WriteLine("Mostrar (2)");
                Console.WriteLine("Regresar al menú anterior (3)");
                optSelect = Convert.ToInt32(Console.ReadLine());
                Console.Clear();

                switch (optSelect)
                {
                    case 1:
                        registrarVenta();
                        break;
                    case 2:
                       // mostrarVentas();
                        break;
                    case 3:
                        return;
                    default:
                        Console.WriteLine("Opción inválida, intente de nuevo.");
                        continue;
                }
                break;
            }
        }

        public void registrarVenta()
        {

            ConsultaVentas consultaVentas = new ConsultaVentas();
            int idUltimaVenta = consultaVentas.ultimaVenta();

            if (idUltimaVenta == 0 )
            {
                idUltimaVenta = 1;
            }



            List<Producto> carrito = new List<Producto>();

            ConsultasProducto consultaProducto = new ConsultasProducto();
            List<Producto> productoStock = consultaProducto.getProductos("");

            decimal subtotal = 0;

            while (true)
            {
                Console.WriteLine("Lista de productos disponibles:");
                foreach (Producto item in productoStock)
                {
                    if(item.getExistencia() > 0)
                    {
                        Console.WriteLine("ID: {0}", item.getId());
                        Console.WriteLine("Nombre: {0}", item.getNombre());
                        Console.WriteLine("Precio: ${0}", item.getPrecio());
                        Console.WriteLine("Existencia: {0}", item.getExistencia());
                        Console.WriteLine();
                    }
                }

                Console.Write("Ingrese el ID del producto que desea comprar: ");
                string idProducto = Console.ReadLine();

                Producto productoSeleccionado = productoStock.Find(p => p.getId().ToString() == idProducto);

                if (productoSeleccionado == null)
                {
                    Console.WriteLine("No se encontró el producto con el ID especificado.");
                    Console.WriteLine();
                    continue;
                }

                Console.Write("Ingrese la cantidad de productos que desea comprar: ");
                int cantidad = int.Parse(Console.ReadLine());

                if (cantidad > productoSeleccionado.getExistencia())
                {
                    Console.WriteLine("La cantidad ingresada es mayor a la cantidad disponible del producto. Presione cualquier tecla para continuar");
                    Console.ReadKey();
                    Console.WriteLine();
                }
                else
                {
                    decimal precioTotal = productoSeleccionado.getPrecio() * cantidad;
                    
                    Producto productoVendido = new Producto(productoSeleccionado.getId(), productoSeleccionado.getNombre(), cantidad, precioTotal);

                    carrito.Add(productoVendido);

                    carrito.Add(productoSeleccionado);
                    productoSeleccionado.setExistencia(productoSeleccionado.getExistencia() - cantidad);

                    subtotal += precioTotal;
                }

                Console.WriteLine("Si desea continuar comprando ingrese 1, si desea terminar su compra ingrese 0");
                string continuar = Console.ReadLine();
                if (continuar == "0")
                {
                    break;
                }
                else
                {
                    continue;
                }
            }

            if (carrito.Count == 0)
            {
                Console.WriteLine("No se registró ninguna venta.");
                Console.WriteLine();
                return;
            }

            Console.Clear();
            ConsultasCliente consultasCliente = new ConsultasCliente();

            Console.WriteLine("Lista de clientes disponibles:");
            Console.WriteLine();
            List<Cliente> clientesDisponibles = consultasCliente.getClientes("");
            foreach (Cliente item in clientesDisponibles)
            {
                Console.WriteLine("{0} - {1} {2} {3}", item.getId(), item.getNombre(), item.getAptPat(), item.getAptMat());
            }

            Console.Write("Seleccione el ID del cliente que está realizando la compra: ");
            int idCliente = int.Parse(Console.ReadLine());

            Cliente clienteSeleccionado = clientesDisponibles.Find(c => c.getId() == idCliente);

            if (clienteSeleccionado == null)
            {
                Console.WriteLine("El ID de cliente ingresado no es válido.");
                return;
            }

            Console.Clear();
            ConsultasVendedor consultasVendedor = new ConsultasVendedor();

            Console.WriteLine("Lista de vendedores disponibles:");
            Console.WriteLine();
            List<Vendedor> vendedoresDisponibles = consultasVendedor.getVendedores("");
            foreach (Vendedor item in vendedoresDisponibles)
            {
                Console.WriteLine("{0} - {1} {2} {3}", item.getId(), item.getNombre(), item.getAptPat(), item.getAptMat());
            }

            Console.Write("Seleccione el ID del vendedor que está realizando la venta: ");
            int idVendedor = int.Parse(Console.ReadLine());

            Vendedor vendedorSeleccionado = vendedoresDisponibles.Find(v => v.getId() == idVendedor);

            if (vendedorSeleccionado == null)
            {
                Console.WriteLine("El ID de vendedor ingresado no es válido.");
                return;
            }

            Console.Clear();
            Console.WriteLine("Resumen de venta");
            Console.WriteLine("-----Cliente-----");
            Console.WriteLine("{0} - {1} {2} {3}", clienteSeleccionado.getId(), clienteSeleccionado.getNombre(), clienteSeleccionado.getAptPat(), clienteSeleccionado.getAptMat());
            Console.WriteLine("-----Vendedor-----");
            Console.WriteLine("{0} - {1} {2} {3}", vendedorSeleccionado.getId(), vendedorSeleccionado.getNombre(), vendedorSeleccionado.getAptPat(), vendedorSeleccionado.getAptMat());
            Console.WriteLine("-----Productos-----");
            foreach (Producto item in carrito)
            {
                if(item.getCantidad() > 0)
                {
                Console.WriteLine("ID: {0}", item.getId());
                Console.WriteLine("Nombre: {0}", item.getNombre());
                Console.WriteLine("Cantidad: {0}", item.getCantidad());
                Console.WriteLine("Total: ${0}", item.getTotal());
                Console.WriteLine();
                }

            }

            Console.WriteLine("-----Subtotal Venta-----");
            Console.WriteLine(subtotal);
            Console.WriteLine("-----Total Venta-----");
            double iva = (double)subtotal * 0.16; ;
            decimal total = subtotal + (decimal)iva;
            Console.WriteLine(total);
            Console.ReadKey();
            Console.Clear();

            Ventas nuevaVenta = new Ventas(idCliente, idVendedor, subtotal, total);
            consultaVentas.agregarVentas(nuevaVenta);
        }



       /* public void mostrarVentas()
        {
            ConsultaVentas consultas = new ConsultaVentas();
            List<Ventas> ventas = consultas.getVentas("");

            foreach (Ventas item in ventas)
            {
                Console.WriteLine("ID venta: {0}", item.idVenta);
                Console.WriteLine("ID Cliente: {0}", item.idCliente);
                Console.WriteLine("ID Vendedor: {0}", item.idVendedor);
                Console.WriteLine("Fecha: {0}", item.fechaVenta);
                Console.WriteLine("Subtotal: {0}", item.subtotal);
                Console.WriteLine("Total: {0}", item.total);


                Console.WriteLine();
            }

            Console.WriteLine("Si desea volver al menú anterior presione cualquier tecla");
            Console.ReadKey();
            Console.Clear();
            mostrarOpciones();
        }*/
    }
    
}