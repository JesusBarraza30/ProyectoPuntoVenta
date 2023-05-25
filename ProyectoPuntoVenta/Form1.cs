using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

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
            List<Cliente> listaClientes = consultas.getClientes("");

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
                List<Cliente> listaClientes = consultas.getClientes("");

                dataGridView1.DataSource = listaClientes;
            }

        }

        private void panel_vendedor_Paint(object sender, PaintEventArgs e)
        {
            gpbx_mostrar_vendedor.Show();

            ConsultasVendedor consultasVendedor = new ConsultasVendedor();
            List<Vendedor> listaVendedores = consultasVendedor.getVendedores("");
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
                List<Vendedor> listaVendedores = consultasVendedor.getVendedores("");
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

            MySqlConnection con = new MySqlConnection("server=localhost;database=mini_market_db;uid=root;pwd=Albertobc24;");

            string query = "select * from ventas";

            using (MySqlDataAdapter adpt = new MySqlDataAdapter(query, con))
            {

                DataSet dset = new DataSet();

                adpt.Fill(dset);

                dgv_ventas.DataSource = dset.Tables[0];

            }
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

            MySqlConnection con = new MySqlConnection("server=localhost;database=mini_market_db;uid=root;pwd=Albertobc24;");

            string query = "select * from ventas";

            using (MySqlDataAdapter adpt = new MySqlDataAdapter(query, con))
            {

                DataSet dset = new DataSet();

                adpt.Fill(dset);

                dgv_ventas.DataSource = dset.Tables[0];

            }

        }

        private void btn_registrar_ventas_Click(object sender, EventArgs e)
        {
            btn_consulta_ventas.Hide();
            btn_registrar_ventas.Hide();
            gpbx_registrar_venta.Show();
            gpbx_cons_ventas.Hide();

            MySqlConnection con = new MySqlConnection("server=localhost;database=mini_market_db;uid=root;pwd=Albertobc24;");

            string query = "select id_producto, nombre, precio from productos";

            using (MySqlDataAdapter adpt = new MySqlDataAdapter(query, con))
            {

                DataSet dset = new DataSet();

                adpt.Fill(dset);

                dgv_info_productos.DataSource = dset.Tables[0];

            }

            con.Open();
            MySqlCommand sc = new MySqlCommand("select id_producto from productos;", con);
            MySqlDataReader reader = sc.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("id_producto", typeof(string));
            dt.Load(reader);
            cmb_producto.ValueMember = "id_producto";
            cmb_producto.DataSource = dt;

            MySqlCommand scVendedor = new MySqlCommand("select id_vendedor from vendedores;", con);
            MySqlDataReader readerVendedor = scVendedor.ExecuteReader();
            DataTable dtVendedor = new DataTable();
            dtVendedor.Columns.Add("Id_Vendedor", typeof(string));
            dtVendedor.Load(readerVendedor);
            cmb_vendedor.ValueMember = "Id_Vendedor";
            cmb_vendedor.DataSource = dtVendedor;

            MySqlCommand scCliente = new MySqlCommand("select id_cliente from clientes;", con);
            MySqlDataReader readerCliente = scCliente.ExecuteReader();
            DataTable dtCliente = new DataTable();
            dtCliente.Columns.Add("Id_Cliente", typeof(string));
            dtCliente.Load(readerCliente);
            cmb_cliente.ValueMember = "Id_Cliente";
            cmb_cliente.DataSource = dtCliente;


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

                cliente_existe = consultasClt.clienteExistente(txt_nombre.Text, txt_ap_pat.Text, txt_ap_mat.Text);
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
                    consultasClt.agregarCliente(nuevoCliente);
                    MessageBox.Show("Cliente registrado con exito");
                    gpbx_registrar.Hide();
                    List<Cliente> listaClientes = consultasClt.getClientes("");
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

                vendedor_existe = consultas.vendedorExistente(txt_nom_vendedor.Text, txt_appat_vendedor.Text, txt_apmat_vendedor.Text);

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

                    consultas.agregarVendedor(nuevoVendedor);
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



        private void btn_agg_venta_Click(object sender, EventArgs e)
        {
            string consulta = "SELECT precio FROM productos WHERE id_producto = " + cmb_producto.Text;

            MySqlDataReader reader = null;
            BD ConexionMySql = new BD();
            MySqlCommand comando = new MySqlCommand(consulta);
            comando.Connection = ConexionMySql.GetConnection();
            reader = comando.ExecuteReader();
            reader.Read();
            decimal precio = (decimal)reader["precio"];

            lbl_producto.Text = cmb_producto.Text;
            lbl_precio.Text = "$" + Convert.ToString(precio);
            lbl_cant.Text = txt_cantidad.Text;

            decimal subtotal = precio * (Convert.ToInt32(lbl_cant.Text));
            string total = Convert.ToString(subtotal + (subtotal * (decimal)0.16));

            lbl_subtotal.Text = Convert.ToString(subtotal);
            lbl_total.Text = total;


        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                ConsultaVentas consultaVentas = new ConsultaVentas();

                int idCliente = Convert.ToInt32(cmb_cliente.Text);
                int idVendedor = Convert.ToInt32(cmb_vendedor.Text);
                int idProducto = Convert.ToInt32(cmb_producto.Text);
                int cantidad = Convert.ToInt32(txt_cantidad.Text);
                decimal subtotal = Convert.ToDecimal(lbl_subtotal.Text);
                decimal total = Convert.ToDecimal(lbl_total.Text);
                DateTime fechaVenta = DateTime.Now;


                Ventas nuevaVenta = new Ventas(idCliente, idVendedor, idProducto, cantidad, subtotal, total, fechaVenta);
                consultaVentas.agregarVentas(nuevaVenta);

                MessageBox.Show("Venta registrada con exito");

                txt_cantidad.Clear();
                lbl_precio.Text = "-";
                lbl_cant.Text = "-";
                lbl_producto.Text = "-";
                lbl_subtotal.Text = "";
                lbl_total.Text = "";

            }
            catch (Exception)
            {

                MessageBox.Show("La venta no pudo ser registrada");
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
            todosLosTextBoxesValidos =  ValidarTextBox(textBox, "alfa");
        }

        private void txt_precio_prod_Validated(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            todosLosTextBoxesValidos =  ValidarTextBox(textBox, "num");
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
    }
}
