using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPuntoVenta
{
    class Producto
    {
        private int optSelect;
        private int id_producto;
        private string nombre;
        private decimal precio;
        private int existencia;
        private ConsultasProducto consultas = new ConsultasProducto();

        public Producto() {

        }

        public Producto(int id_producto, string nombre, decimal precio, int existencia) {
            this.id_producto = id_producto;
            this.nombre = nombre;
            this.precio = precio;
            this.existencia = existencia;
        }

        public Producto(string nombre, decimal precio, int existencia)
        {
            this.nombre = nombre;
            this.precio = precio;
            this.existencia = existencia;
        }

        public string getNombre()
        {
            return nombre;
        }

        public decimal getPrecio()
        {
            return precio;
        }

        public int getExistencia()
        {
            return existencia;
        }

        public void mostrarOpciones()
        {
            while (true)
            {
                Console.WriteLine("Seleccione una acción para Productos");
                Console.WriteLine("Agregar (1)");
                Console.WriteLine("Mostrar (2)");
                Console.WriteLine("Actualizar Precio(3)");
                Console.WriteLine("Regresar al menú anterior (4)");
                optSelect = Convert.ToInt32(Console.ReadLine());
                Console.Clear();

                switch (optSelect)
                {
                    case 1:
                        agregarProducto();
                        break;
                    case 2:
                        mostrarProductos();
                        break;
                    case 3:
                        actualizarPrecio();
                        break;
                    case 4:
                        return;
                    default:
                        Console.WriteLine("Opción inválida, intente de nuevo.");
                        continue;
                }
                break;
            }
        }

        public void agregarProducto(){
            ConsultasProducto consultas = new ConsultasProducto();

            Console.WriteLine("Ingrese el nombre del producto: ");
            string nombre = Console.ReadLine();
            Console.WriteLine("Ingrese el precio del producto: ");
            decimal precio = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Ingrese la cantidad en existencia del producto: ");
            int existencia = Convert.ToInt32(Console.ReadLine());

            Producto productoNuevo = new Producto(nombre, precio, existencia);

            consultas.agregarProductos(productoNuevo);

            Console.WriteLine("Si desea volver al menú anterior presione cualquier tecla");
            Console.ReadKey();
            Console.Clear();
            mostrarOpciones();
        }

        public void mostrarProductos()
        {
            ConsultasProducto consultas = new ConsultasProducto();
            List<Producto> productos = consultas.getProductos("");

            foreach (Producto item in productos)
            {
                Console.WriteLine("ID: {0}", item.id_producto);
                Console.WriteLine("Nombre: {0}", item.nombre);
                Console.WriteLine("Precio: ${0}", item.precio);
                Console.WriteLine("Existencia: {0}", item.existencia);
                Console.WriteLine();
            }

            Console.WriteLine("Si desea volver al menú anterior presione cualquier tecla");
            Console.ReadKey();
            Console.Clear();
            mostrarOpciones();
        }

        public void actualizarPrecio()
        {
            Console.WriteLine("Ingrese el ID del producto que desea actualizar: ");
            int id_producto = Convert.ToInt32(Console.ReadLine());
            ConsultasProducto consultas = new ConsultasProducto();
            List<Producto> producto = consultas.getProducto(id_producto.ToString());
            Console.WriteLine();


            if (producto.Count() > 0)
            {
                foreach (Producto item in producto)
                {
                    Console.WriteLine("ID: {0}", item.id_producto);
                    Console.WriteLine("Nombre: {0}", item.nombre);
                    Console.WriteLine("Precio: ${0}", item.precio);
                    Console.WriteLine("Existencia: {0}", item.existencia);
                    Console.WriteLine();
                }

                Console.WriteLine("Ingrese el nuevo precio para el producto {0} :", id_producto);
                decimal nuevoPrecio = Convert.ToDecimal(Console.ReadLine());

                consultas.actualizarPrecioProducto(id_producto, nuevoPrecio);

                Console.WriteLine("Precio actualizado con éxito, presione cualquier tecla para regresar al menu anterior");
                Console.ReadKey();
                Console.Clear();
                mostrarOpciones();
            }
            else
            {
                Console.WriteLine("El ID ingresado no se encuentra en uso, presione cualquier tecla para regresar al menu anterior");
                Console.ReadKey();
                Console.Clear();
                mostrarOpciones();
            }
        }
    }
}
