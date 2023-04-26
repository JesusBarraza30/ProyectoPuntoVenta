using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoPuntoVenta
{
    public partial class FormCliente : Form
    {
        public FormCliente()
        {
            InitializeComponent();
        }

        private void Opciones_cliente_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void FormCliente_Load(object sender, EventArgs e)
        {
            groupBox1.Hide();
            groupBox2.Hide();
        }

        private void btn_selec_Click(object sender, EventArgs e)
        {
            if (rdbtn_agregar_cliente.Checked) {
                groupBox1.Show();
                groupBox2.Hide();
            }
            if (rdbtn_mostrar_clientes.Checked) {
                groupBox1.Hide();
                groupBox2.Show();
            }
        }
    }
}
