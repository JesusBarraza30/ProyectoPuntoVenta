using Apitron.PDF.Rasterizer;
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

namespace ProyectoPuntoVenta
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public string _path;

        private void Form2_Load(object sender, EventArgs e)
        {
            this.Hide();

            try
            {
                FileStream fs = new FileStream(_path, FileMode.Open);
                pdfViewer1.Document = new Document(fs);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void pdfViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
