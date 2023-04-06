using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPuntoVenta
{
    public class Vendedor : Cliente
    {
        private int comision;
        private decimal sueldoBase;

        public Vendedor() { }

        public Vendedor(int idCliente, string nombre, string ap_pat, string ap_mat, string email, string telefono, int comision, decimal sueldoBase)
            : base(idCliente, nombre, ap_pat, ap_mat, email, telefono)
        {
            this.comision = comision;
            this.sueldoBase = sueldoBase;
        }

        public Vendedor(string nombre, string ap_pat, string ap_mat, string email, string telefono, int comision, decimal sueldoBase)
            : base(nombre, ap_pat, ap_mat, email, telefono)
        {
            this.comision = comision;
            this.sueldoBase = sueldoBase;
        }

        public int getComision()
        {
            return comision;
        }

        public decimal getSueldoBase()
        {
            return sueldoBase;
        }

        public void setComision(int comision)
        {
            this.comision = comision;
        }

        public void setSueldoBase(decimal sueldoBase)
        {
            this.sueldoBase = sueldoBase;
        }

        public void mostrarOpcionesVendedor()
        {
            while (true)
            {
                Console.WriteLine("Seleccione una acción para Vendedores");
                Console.WriteLine("Agregar (1)");
                Console.WriteLine("Mostrar (2)");
                Console.WriteLine("Regresar al menú anterior (3)");
                optSelect = Convert.ToInt32(Console.ReadLine());
                Console.Clear();

                switch (optSelect)
                {
                    case 1:
                        agregarVendedor();
                        break;
                    case 2:
                        mostrarVendedores();
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

        public void agregarVendedor()
        {
            bool vendedor_existe;

            do
            {
                ConsultasVendedor consultas = new ConsultasVendedor();

                Console.WriteLine("Ingrese el nombre del vendedor: ");
                string nombre = Console.ReadLine();
                Console.WriteLine("Ingrese el apellido paterno del vendedor: ");
                string ap_pat = Console.ReadLine();
                Console.WriteLine("Ingrese el apellido materno del vendedor: ");
                string ap_mat = Console.ReadLine();

                vendedor_existe = consultas.vendedorExistente(nombre, ap_pat, ap_mat);

                if (vendedor_existe)
                {
                    Console.WriteLine();
                    Console.WriteLine("Este vendedor ya se encuentra registrado, por favor teclee cualquier tecla e ingrese otros datos");
                    Console.ReadKey();
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("Ingrese el correo electrónico del vendedor: ");
                    string email = Console.ReadLine();

                    Console.WriteLine("Ingrese el teléfono celular del vendedor: ");
                    string telefono = Console.ReadLine();

                    Console.WriteLine("Ingrese la comisión del vendedor: ");
                    int comision = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Ingrese el sueldo base del vendedor: ");
                    decimal sueldoBase = Convert.ToDecimal(Console.ReadLine());

                    Vendedor nuevoVendedor = new Vendedor(nombre, ap_pat, ap_mat, email, telefono, comision, sueldoBase);
                    consultas.agregarVendedor(nuevoVendedor);
                    Console.WriteLine("Si desea volver al menú anterior presione cualquier tecla");
                    Console.ReadKey();
                    Console.Clear();
                    mostrarOpcionesVendedor();
                }
            } while (vendedor_existe);
        }

        public void mostrarVendedores()
        {
            ConsultasVendedor consultas = new ConsultasVendedor();
            List<Vendedor> vendedores = consultas.getVendedores("");

            foreach (Vendedor item in vendedores)
            {
                Console.WriteLine("ID: {0}", item.idCliente);
                Console.WriteLine("Nombre: {0}", item.nombre);
                Console.WriteLine("Apellido Paterno: {0}", item.ap_pat);
                Console.WriteLine("Apellido Materno: {0}", item.ap_mat);
                Console.WriteLine("Email: {0}", item.email);
                Console.WriteLine("Telefono: {0}", item.telefono);
                Console.WriteLine("Sueldo Base: {0}", item.sueldoBase);
                Console.WriteLine("Comisióm: {0}", item.comision);

                Console.WriteLine();
            }

            Console.WriteLine("Si desea volver al menú anterior presione cualquier tecla");
            Console.ReadKey();
            Console.Clear();
            mostrarOpcionesVendedor();
        }
    }
}