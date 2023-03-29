using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPuntoVenta
{
    public class Cliente
    {
        private int idCliente;
        private string nombre;
        private string ap_pat;
        private string ap_mat;
        private string email;
        private string telefono;
        private int optSelect;

        public Cliente() { 
            
        }

        public Cliente(int idCliente ,string nombre, string ap_pat, string ap_mat, string email, string telefono)
        {
            this.idCliente = idCliente;
            this.nombre = nombre;
            this.ap_pat = ap_pat;
            this.ap_mat = ap_mat;
            this.email = email;
            this.telefono = telefono;
        }

        public Cliente(string nombre, string ap_pat, string ap_mat, string email, string telefono)
        {
            this.nombre = nombre;
            this.ap_pat = ap_pat;
            this.ap_mat = ap_mat;
            this.email = email;
            this.telefono = telefono;
        }

        public string getNombre()
        {
            return nombre;
        }
        public string getAptPat()
        {
            return ap_pat;
        }
        public string getAptMat()
        {
            return ap_mat;
        }
        public string getEmail()
        {
            return email;
        }
        public string getTelefono()
        {
            return telefono;
        }

        public void mostrarOpciones()
        {
            while (true)
            {
                Console.WriteLine("Seleccione una acción para Clientes");
                Console.WriteLine("Agregar (1)");
                Console.WriteLine("Mostrar (2)");
                Console.WriteLine("Regresar al menú anterior (3)");
                optSelect = Convert.ToInt32(Console.ReadLine());
                Console.Clear();

                switch (optSelect)
                {
                    case 1:
                        agregarCliente();
                        break;
                    case 2:
                        mostrarClientes();
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

        public void agregarCliente()
        {
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

        public void mostrarClientes()
        {
            ConsultasCliente consultas = new ConsultasCliente();
            List<Cliente> clientes = consultas.getClientes("");

            foreach (Cliente item in clientes)
            {
                Console.WriteLine("ID: {0}", item.idCliente);
                Console.WriteLine("Nombre: {0}", item.nombre);
                Console.WriteLine("Apellido Paterno: {0}", item.ap_pat);
                Console.WriteLine("Apellido Materno: {0}", item.ap_mat);
                Console.WriteLine("Email: {0}", item.email);
                Console.WriteLine("Telefono: {0}", item.telefono);

                Console.WriteLine();
            }

            Console.WriteLine("Si desea volver al menú anterior presione cualquier tecla");
            Console.ReadKey();
            Console.Clear();
            mostrarOpciones();
        }
    }
}
