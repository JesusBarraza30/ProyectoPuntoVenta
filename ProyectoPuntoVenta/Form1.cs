using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Apitron.PDF.Rasterizer;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using MySql.Data.MySqlClient;
using PDFUtility;

namespace ProyectoPuntoVenta
{
    public partial class Form1 : Form
    {
        private List<User> listausers = new List<User>();
        private bool todosLosTextBoxesValidos = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listausers.Add(new User("ADMIN", "ADMIN"));

            menuStrip1.Hide();
            //panel_inicio_sesion.Show();
            panel_cliente.Hide();
            panel_vendedor.Hide();
            panel_productos.Hide();
            panel_ventas.Hide();
            groupBox7.Hide();
            //pdfViewer1.Hide();
        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel_cliente.Show();
            panel_vendedor.Hide();
            panel_productos.Hide();
            panel_ventas.Hide();
            panel_inicio_sesion.Hide();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            gpbx_mostrar.Show();

            ConsultasCliente consultas = new ConsultasCliente();
            List<Cliente> listaClientes = consultas.GetClientes("");

            dataGridView1.DataSource = listaClientes;

            gpbx_registrar.Hide();
        }

        private void btn_selec_Click(object sender, EventArgs e)
        {
            if (rdbtn_agregar_cliente.Checked)
            {
                gpbx_registrar.Show();
                gpbx_mostrar.Hide();
            }
            if (rdbtn_mostrar_clientes.Checked)
            {
                gpbx_mostrar.Show();
                gpbx_registrar.Hide();

                ConsultasCliente consultas = new ConsultasCliente();
                List<Cliente> listaClientes = consultas.GetClientes("");

                dataGridView1.DataSource = listaClientes;
            }

        }

        private void panel_vendedor_Paint(object sender, PaintEventArgs e)
        {
            gpbx_mostrar_vendedor.Show();

            ConsultasVendedor consultasVendedor = new ConsultasVendedor();
            List<Vendedor> listaVendedores = consultasVendedor.GetVendedores("");
            dataGridView2.DataSource = listaVendedores;

            gpbx_registrar_vendedor.Hide();
        }

        private void btn_seleccionar_Click(object sender, EventArgs e)
        {
            if (rdbtn_mostrar_vendedor.Checked)
            {
                gpbx_mostrar_vendedor.Show();
                gpbx_registrar_vendedor.Hide();

                ConsultasVendedor consultasVendedor = new ConsultasVendedor();
                List<Vendedor> listaVendedores = consultasVendedor.GetVendedores("");
                dataGridView2.DataSource = listaVendedores;
            }
            if (rdbtn_registrar_vendedor.Checked)
            {
                gpbx_registrar_vendedor.Show();
                gpbx_mostrar_vendedor.Hide();
            }
        }

        private void vendedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel_vendedor.Show();
            panel_cliente.Hide();
            panel_productos.Hide();
            panel_ventas.Hide();
            panel_inicio_sesion.Hide();

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void btn_aceptar_Click(object sender, EventArgs e)
        {
            //User usuario = listausers.FirstOrDefault(x => x.pUserName.Equals(txt_user.Text) && x.pPassWord.Equals(txt_pass.Text));
            //if (usuario != null)
            //{
            menuStrip1.Show();
            groupBox3.Hide();
            groupBox7.Show();

            //}
            //if (usuario == null)
            //{
            //    MessageBox.Show("El usuario y/o contraseña ingresados son incorrectos", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            //}
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel_productos.Show();
            panel_cliente.Hide();
            panel_vendedor.Hide();
            panel_ventas.Hide();
            panel_inicio_sesion.Hide();
            gpbx_agregar_producto.Hide();


        }

        private void ventasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel_ventas.Show();
            panel_cliente.Hide();
            panel_productos.Hide();
            panel_vendedor.Hide();
            panel_inicio_sesion.Hide();
            gpbx_registrar_venta.Hide();
            gpbx_cons_ventas.Show();

            ConsultaVentas consultas = new ConsultaVentas();
            List<Ventas> listaVentas = consultas.GetVentas("");

            dgv_ventas.DataSource = listaVentas;
        }

        private void panel_productos_Paint(object sender, PaintEventArgs e)
        {
            ConsultasProducto consultas = new ConsultasProducto();
            List<Producto> listaProductos = consultas.getProductos("");

            dataGridView3.DataSource = listaProductos;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            gpbx_cons_ventas.Show();
            gpbx_registrar_venta.Hide();

            ConsultaVentas consultas = new ConsultaVentas();
            List<Ventas> listaVentas = consultas.GetVentas("");

            dgv_ventas.DataSource = listaVentas;

        }

        private void btn_registrar_ventas_Click(object sender, EventArgs e)
        {
            btn_consulta_ventas.Hide();
            btn_registrar_ventas.Hide();
            gpbx_registrar_venta.Show();
            gpbx_cons_ventas.Hide();

            ConsultasProducto consultas = new ConsultasProducto();
            List<Producto> listaProductos = consultas.getProductos("");

            ConsultasCliente consultasClt = new ConsultasCliente();
            List<Cliente> listaClientes = consultasClt.GetClientes("");

            ConsultasVendedor consultasVdor = new ConsultasVendedor();
            List<Vendedor> listaVendedores = consultasVdor.GetVendedores("");

            dgv_info_productos.AutoGenerateColumns = false;

            dgv_info_productos.Columns.Add("IdProducto", "Id Producto");
            dgv_info_productos.Columns.Add("Nombre", "Nombre");
            dgv_info_productos.Columns.Add("Precio", "Precio");
            dgv_info_productos.Columns.Add("Existencia", "Existencia");
            dgv_info_productos.Columns["IdProducto"].DataPropertyName = "IdProducto";
            dgv_info_productos.Columns["Nombre"].DataPropertyName = "Nombre";
            dgv_info_productos.Columns["Precio"].DataPropertyName = "Precio";
            dgv_info_productos.Columns["Existencia"].DataPropertyName = "Existencia";
            dgv_info_productos.DataSource = listaProductos;

            cmb_producto.DataSource = listaProductos;
            cmb_producto.DisplayMember = "IdProducto";

            cmb_cliente.DataSource = listaClientes;
            cmb_cliente.DisplayMember = "IdCliente";

            cmb_vendedor.DataSource = listaVendedores;
            cmb_vendedor.DisplayMember = "IdCliente";
        }

        private void panel_ventas_Paint(object sender, PaintEventArgs e)
        {
            btn_consulta_ventas.Show();
            btn_registrar_ventas.Show();

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void gpbx_registrar_ventas_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void gpbx_registrar_venta_Enter(object sender, EventArgs e)
        {

        }

        private void btn_registrar_Click(object sender, EventArgs e)
        {

            bool cliente_existe;
            ConsultasCliente consultasClt = new ConsultasCliente();

            cliente_existe = consultasClt.ClienteExistente(txt_nombre.Text, txt_ap_pat.Text, txt_ap_mat.Text);
            if (todosLosTextBoxesValidos)
            {
                if (cliente_existe)
                {
                    MessageBox.Show("Este cliente ya se encuentra registrado, por favor ingrese otros datos");
                    txt_nombre.Clear();
                    txt_ap_pat.Clear();
                    txt_ap_mat.Clear();
                    txt_correo.Clear();
                    txt_telefono.Clear();
                }
                else
                {
                    Cliente nuevoCliente = new Cliente(txt_nombre.Text, txt_ap_pat.Text, txt_ap_mat.Text, txt_correo.Text, txt_telefono.Text);
                    consultasClt.AgregarCliente(nuevoCliente);
                    MessageBox.Show("Cliente registrado con exito");
                    gpbx_registrar.Hide();
                    List<Cliente> listaClientes = consultasClt.GetClientes("");
                    dataGridView1.DataSource = listaClientes;
                }
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            bool vendedor_existe;

            do
            {
                ConsultasVendedor consultas = new ConsultasVendedor();

                vendedor_existe = consultas.VendedorExistente(txt_nom_vendedor.Text, txt_appat_vendedor.Text, txt_apmat_vendedor.Text);

                if (vendedor_existe)
                {
                    MessageBox.Show("Este vendedor ya se encuentra registrado, por favor ingrese otros datos");
                    txt_nom_vendedor.Clear();
                    txt_appat_vendedor.Clear();
                    txt_apmat_vendedor.Clear();
                    break;
                }
                else
                {

                    Vendedor nuevoVendedor = new Vendedor(txt_nom_vendedor.Text, txt_appat_vendedor.Text, txt_apmat_vendedor.Text, txt_correo_vendedor.Text, txt_telefono_vendedor.Text, 5, Convert.ToDecimal(txt_sueldo_vendedor.Text));

                    consultas.AgregarVendedor(nuevoVendedor);
                    MessageBox.Show("Vendedor registrado con exito");
                }

            } while (vendedor_existe);
        }

        private void btn_buscar_producto_Click(object sender, EventArgs e)
        {
            gpbx_agregar_producto.Hide();


            ConsultasProducto consultas = new ConsultasProducto();

            List<Producto> listaProductos = consultas.getProductos(txt_filtro.Text);

            dataGridView3.DataSource = listaProductos;
        }

        private void btn_agregarprod_Click(object sender, EventArgs e)
        {
            gpbx_agregar_producto.Show();
        }

        private void btn_agregar_producto_Click(object sender, EventArgs e)
        {
            if (todosLosTextBoxesValidos)
            {
                ConsultasProducto consultas = new ConsultasProducto();
                Producto productoNuevo = new Producto(txt_nombre_prod.Text, Convert.ToDecimal(txt_precio_prod.Text), Convert.ToInt32(txt_existencia_prod.Text));
                consultas.agregarProductos(productoNuevo);
                MessageBox.Show("Producto agregado con exito");
                List<Producto> listaProductos = consultas.getProductos(txt_filtro.Text);
                dataGridView3.DataSource = listaProductos;
                gpbx_agregar_producto.Hide();
            }
        }


        private List<int> listaIdsProductos = new List<int>();
        private List<int> listaCantidadProductos = new List<int>();
        private decimal subtotal = 0;
        private List<int> existencia = new List<int>();
        private void btn_agg_venta_Click(object sender, EventArgs e)
        {
            if (todosLosTextBoxesValidos)
            {
                int idProducto = Convert.ToInt32(cmb_producto.Text);
                Console.WriteLine("Id: {0}", idProducto);
                if (listaIdsProductos.Contains(idProducto))
                {
                    MessageBox.Show("El producto ya ha sido agregado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                ConsultasProducto consultas = new ConsultasProducto();
                List<Producto> producto = consultas.getProducto(Convert.ToString(idProducto));

                Console.WriteLine("Producto: {0}", producto[0].Existencia);
                int cantidadDisponible = producto[0].Existencia;
                if (cantidadDisponible <= Convert.ToInt32(txt_cantidad.Text))
                {
                    MessageBox.Show("El producto no tiene suficiente cantidad disponible.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DataGridViewRow filaProducto = dgv_info_productos.Rows
                   .Cast<DataGridViewRow>()
                    .FirstOrDefault(r => Convert.ToInt32(r.Cells["IdProducto"].Value) == idProducto);

                if (filaProducto != null)
                {
                    if (Convert.ToInt32(txt_cantidad.Text) < cantidadDisponible)
                    {
                        filaProducto.Cells["Existencia"].Value = cantidadDisponible - Convert.ToInt32(txt_cantidad.Text);
                        existencia.Add(cantidadDisponible - Convert.ToInt32(txt_cantidad.Text));
                        filaProducto.DefaultCellStyle.BackColor = Color.Lime;
                    }
                    else
                    {
                        MessageBox.Show("No se puede agregar más del producto seleccionado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                listaIdsProductos.Add(idProducto);
                listaCantidadProductos.Add(Convert.ToInt32(txt_cantidad.Text));
                dgv_info_productos.Refresh();


                decimal subtotal_individual = producto[0].Precio * (Convert.ToInt32(txt_cantidad.Text));
                subtotal += subtotal_individual;
                string total = Convert.ToString(subtotal + (subtotal * (decimal)0.16));

                lbl_subtotal.Text = Convert.ToString(subtotal);
                lbl_total.Text = total;
                txt_cantidad.Text = string.Empty;
            }
            else
            {
                MessageBox.Show("Debe agregar la cantidad del producto seleccionado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ConsultaVentas consultaVentas = new ConsultaVentas();
            consultaVentas.UltimaVenta();
            int idVtaActual = consultaVentas.UltimaVenta() + 1;

            if (listaIdsProductos.Any())
            {
                Console.WriteLine("Contiene Informacion");
                Ventas ventaNueva = new Ventas(Convert.ToInt32(cmb_cliente.Text), Convert.ToInt32(cmb_vendedor.Text), subtotal, Convert.ToDecimal(lbl_total.Text), DateTime.Now);
                consultaVentas.AgregarVentas(ventaNueva);

                for (var i = 0; i < listaIdsProductos.Count; i++)
                {
                    var id_producto = listaIdsProductos[i];
                    var cantidad = listaCantidadProductos[i];
                    consultaVentas.AgregarDetalle(id_producto, idVtaActual, cantidad);
                    ConsultasProducto producto = new ConsultasProducto();
                    producto.ActualizarExistencia(id_producto, existencia[i]);
                }

                MessageBox.Show("Venta guardada correctamente.", "Registro Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarDatos();
                gpbx_cons_ventas.Show();
                gpbx_registrar_venta.Hide();
            }
            else
            {
                MessageBox.Show("Se debe agregar almenos un producto.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void gpbx_cons_ventas_Enter(object sender, EventArgs e)
        {

        }

        private void label30_Click(object sender, EventArgs e)
        {

        }

        private void txt_nombre_TextChanged(object sender, EventArgs e)
        {

        }
        private bool EsEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }


        private bool ValidarTextBox(TextBox textBox, string tipoValidacion)
        {
            bool textBoxesValidos = true;


            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                errorProvider.SetError(textBox, "El campo está vacío. Por favor, ingrese un valor.");
                textBoxesValidos = false;
            }
            else if (tipoValidacion == "alfa" && !textBox.Text.Replace(" ", string.Empty).All(char.IsLetter))
            {
                errorProvider.SetError(textBox, "El campo solo debe contener letras. Por favor, corrija el valor.");
                textBoxesValidos = false;
            }
            else if (tipoValidacion == "num" && !textBox.Text.All(char.IsDigit))
            {
                errorProvider.SetError(textBox, "El campo solo debe contener números. Por favor, corrija el valor.");
                textBoxesValidos = false;
            }
            else if (tipoValidacion == "correo" && !EsEmail(textBox.Text))
            {
                errorProvider.SetError(textBox, "El campo debe contener un correo electrónico válido. Por favor, corrija el valor.");
                textBoxesValidos = false;
            }

            else
            {
                errorProvider.SetError(textBox, string.Empty);
            }

            return textBoxesValidos;
        }

        private void txt_nombre_prod_Validated(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            todosLosTextBoxesValidos = ValidarTextBox(textBox, "alfa");
        }

        private void txt_precio_prod_Validated(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            todosLosTextBoxesValidos = ValidarTextBox(textBox, "num");
        }

        private void txt_existencia_prod_Validated(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            todosLosTextBoxesValidos = ValidarTextBox(textBox, "num");
        }

        private void txt_nombre_Validated(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            todosLosTextBoxesValidos = ValidarTextBox(textBox, "alfa");
        }

        private void txt_ap_pat_Validated(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            todosLosTextBoxesValidos = ValidarTextBox(textBox, "alfa");
        }

        private void txt_ap_mat_Validated(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            todosLosTextBoxesValidos = ValidarTextBox(textBox, "alfa");
        }

        private void txt_correo_Validated(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            todosLosTextBoxesValidos = ValidarTextBox(textBox, "correo");
        }

        private void txt_telefono_Validated(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            todosLosTextBoxesValidos = ValidarTextBox(textBox, "num");
        }

        private void groupBox6_Enter(object sender, EventArgs e)
        {

        }

        private void txt_cantidad_Validating(object sender, CancelEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            todosLosTextBoxesValidos = ValidarTextBox(textBox, "num");
        }

        private void cmb_cliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            LimpiarDatos();
        }
        private void LimpiarDatos()
        {
            lbl_subtotal.Text = string.Empty;
            lbl_total.Text = string.Empty;
            txt_cantidad.Text = string.Empty;
            listaCantidadProductos.Clear();
            listaIdsProductos.Clear();
            ConsultasProducto consultas = new ConsultasProducto();
            List<Producto> listaProductos = consultas.getProductos("");

            dgv_info_productos.AutoGenerateColumns = false;
            dgv_info_productos.Columns.Add("IdProducto", "Id Producto");
            dgv_info_productos.Columns.Add("Nombre", "Nombre");
            dgv_info_productos.Columns.Add("Precio", "Precio");
            dgv_info_productos.Columns.Add("Existencia", "Existencia");
            dgv_info_productos.Columns["IdProducto"].DataPropertyName = "IdProducto";
            dgv_info_productos.Columns["Nombre"].DataPropertyName = "Nombre";
            dgv_info_productos.Columns["Precio"].DataPropertyName = "Precio";
            dgv_info_productos.Columns["Existencia"].DataPropertyName = "Existencia";
            dgv_info_productos.DataSource = listaProductos;
        }

        private void reporteToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ventToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = "D:\\Documentos\\Reporte de Ventas.pdf";
            var document = Utility.CreatePDF(path);
            string[] encabezado = { "ID Venta", "ID Vendedor", "ID Cliente", "Fecha de Venta", "Subtotal", "Total", "ID Producto", "Cantidad" };
            Utility.EncabezadoPDF(document, "Mini Market", "Reporte de Ventas");
            var tabla = Utility.EncabezadoTabla(encabezado);
            ConsultaVentas consultas = new ConsultaVentas();
            List<Ventas> listaVentas = consultas.GetVentaDetalle();

            foreach (var item in listaVentas)
            {
                tabla.AddCell(item.IdVenta.ToString());
                tabla.AddCell(item.IdVendedor.ToString());
                tabla.AddCell(item.IdCliente.ToString());
                tabla.AddCell(item.FechaVenta.ToString());
                tabla.AddCell(item.Subtotal.ToString());
                tabla.AddCell(item.Total.ToString());
                tabla.AddCell(item.iDProducto.ToString());
                tabla.AddCell(item.Cantidad.ToString());
            }
            document.Add(tabla);
            document.Close();

            Form2 form2 = new Form2();
            form2._path = path;
            form2.Show();
        }

        private void inventarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var document = Utility.CreatePDF("D:\\Documentos\\Inventario de Productos.pdf");
            string[] encabezado = { "ID Producto", "Nombre", "Existencia", "Cantidad Vendidos" };
            Utility.EncabezadoPDF(document, "Mini Market", "Inventario de Productos");
            var tabla = Utility.EncabezadoTabla(encabezado);
            ConsultasProducto consultas = new ConsultasProducto();
            List<Producto> listaProductos = consultas.GetInventario();

            foreach (var item in listaProductos)
            {
                tabla.AddCell(item.IdProducto.ToString());
                tabla.AddCell(item.Nombre.ToString());
                tabla.AddCell(item.Existencia.ToString());
                tabla.AddCell(item.Cantidad.ToString());
            }
            document.Add(tabla);
            document.Close();
        }
    }
}
