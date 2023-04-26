
namespace ProyectoPuntoVenta
{
    partial class FormCliente
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_selec = new System.Windows.Forms.Button();
            this.rdbtn_mostrar_clientes = new System.Windows.Forms.RadioButton();
            this.rdbtn_agregar_cliente = new System.Windows.Forms.RadioButton();
            this.gpbx_registrar = new System.Windows.Forms.GroupBox();
            this.txt_correo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_registrar = new System.Windows.Forms.Button();
            this.txt_ap_mat = new System.Windows.Forms.TextBox();
            this.txt_ap_pat = new System.Windows.Forms.TextBox();
            this.txt_nombre = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_telefono = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.lbl_info_nombre = new System.Windows.Forms.Label();
            this.lbl_info_appat = new System.Windows.Forms.Label();
            this.lbl_info_apmat = new System.Windows.Forms.Label();
            this.lbl_info_correo = new System.Windows.Forms.Label();
            this.lbl_info_telefono = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.gpbx_registrar.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(707, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cliente";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.btn_selec);
            this.groupBox1.Controls.Add(this.rdbtn_mostrar_clientes);
            this.groupBox1.Controls.Add(this.rdbtn_agregar_cliente);
            this.groupBox1.Location = new System.Drawing.Point(16, 57);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(171, 157);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Opciones";
            // 
            // btn_selec
            // 
            this.btn_selec.Location = new System.Drawing.Point(45, 113);
            this.btn_selec.Name = "btn_selec";
            this.btn_selec.Size = new System.Drawing.Size(75, 23);
            this.btn_selec.TabIndex = 2;
            this.btn_selec.Text = "Seleccionar";
            this.btn_selec.UseVisualStyleBackColor = true;
            this.btn_selec.Click += new System.EventHandler(this.btn_selec_Click);
            // 
            // rdbtn_mostrar_clientes
            // 
            this.rdbtn_mostrar_clientes.AutoSize = true;
            this.rdbtn_mostrar_clientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.rdbtn_mostrar_clientes.Location = new System.Drawing.Point(21, 68);
            this.rdbtn_mostrar_clientes.Name = "rdbtn_mostrar_clientes";
            this.rdbtn_mostrar_clientes.Size = new System.Drawing.Size(126, 21);
            this.rdbtn_mostrar_clientes.TabIndex = 1;
            this.rdbtn_mostrar_clientes.TabStop = true;
            this.rdbtn_mostrar_clientes.Text = "Mostrar clientes";
            this.rdbtn_mostrar_clientes.UseVisualStyleBackColor = true;
            // 
            // rdbtn_agregar_cliente
            // 
            this.rdbtn_agregar_cliente.AutoSize = true;
            this.rdbtn_agregar_cliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.rdbtn_agregar_cliente.Location = new System.Drawing.Point(20, 35);
            this.rdbtn_agregar_cliente.Name = "rdbtn_agregar_cliente";
            this.rdbtn_agregar_cliente.Size = new System.Drawing.Size(129, 21);
            this.rdbtn_agregar_cliente.TabIndex = 0;
            this.rdbtn_agregar_cliente.TabStop = true;
            this.rdbtn_agregar_cliente.Text = "Registrar cliente";
            this.rdbtn_agregar_cliente.UseVisualStyleBackColor = true;
            // 
            // gpbx_registrar
            // 
            this.gpbx_registrar.BackColor = System.Drawing.SystemColors.Control;
            this.gpbx_registrar.Controls.Add(this.txt_telefono);
            this.gpbx_registrar.Controls.Add(this.label6);
            this.gpbx_registrar.Controls.Add(this.txt_correo);
            this.gpbx_registrar.Controls.Add(this.label5);
            this.gpbx_registrar.Controls.Add(this.btn_registrar);
            this.gpbx_registrar.Controls.Add(this.txt_ap_mat);
            this.gpbx_registrar.Controls.Add(this.txt_ap_pat);
            this.gpbx_registrar.Controls.Add(this.txt_nombre);
            this.gpbx_registrar.Controls.Add(this.label4);
            this.gpbx_registrar.Controls.Add(this.label3);
            this.gpbx_registrar.Controls.Add(this.label2);
            this.gpbx_registrar.Location = new System.Drawing.Point(214, 57);
            this.gpbx_registrar.Name = "gpbx_registrar";
            this.gpbx_registrar.Size = new System.Drawing.Size(505, 381);
            this.gpbx_registrar.TabIndex = 2;
            this.gpbx_registrar.TabStop = false;
            this.gpbx_registrar.Text = "Registrar";
            // 
            // txt_correo
            // 
            this.txt_correo.Location = new System.Drawing.Point(264, 187);
            this.txt_correo.Name = "txt_correo";
            this.txt_correo.Size = new System.Drawing.Size(195, 20);
            this.txt_correo.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.label5.Location = new System.Drawing.Point(59, 187);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(146, 18);
            this.label5.TabIndex = 7;
            this.label5.Text = "Correo electronio:";
            // 
            // btn_registrar
            // 
            this.btn_registrar.Location = new System.Drawing.Point(188, 297);
            this.btn_registrar.Name = "btn_registrar";
            this.btn_registrar.Size = new System.Drawing.Size(114, 23);
            this.btn_registrar.TabIndex = 6;
            this.btn_registrar.Text = "Registrar";
            this.btn_registrar.UseVisualStyleBackColor = true;
            // 
            // txt_ap_mat
            // 
            this.txt_ap_mat.Location = new System.Drawing.Point(264, 149);
            this.txt_ap_mat.Name = "txt_ap_mat";
            this.txt_ap_mat.Size = new System.Drawing.Size(195, 20);
            this.txt_ap_mat.TabIndex = 5;
            // 
            // txt_ap_pat
            // 
            this.txt_ap_pat.Location = new System.Drawing.Point(264, 113);
            this.txt_ap_pat.Name = "txt_ap_pat";
            this.txt_ap_pat.Size = new System.Drawing.Size(195, 20);
            this.txt_ap_pat.TabIndex = 4;
            // 
            // txt_nombre
            // 
            this.txt_nombre.Location = new System.Drawing.Point(264, 80);
            this.txt_nombre.Name = "txt_nombre";
            this.txt_nombre.Size = new System.Drawing.Size(195, 20);
            this.txt_nombre.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.label4.Location = new System.Drawing.Point(59, 151);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(139, 18);
            this.label4.TabIndex = 2;
            this.label4.Text = "Apellido materno:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.label3.Location = new System.Drawing.Point(59, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 18);
            this.label3.TabIndex = 1;
            this.label3.Text = "Apellido paterno:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.label2.Location = new System.Drawing.Point(59, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "Nombre:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.label6.Location = new System.Drawing.Point(59, 221);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 18);
            this.label6.TabIndex = 9;
            this.label6.Text = "Telefono:";
            // 
            // txt_telefono
            // 
            this.txt_telefono.Location = new System.Drawing.Point(264, 222);
            this.txt_telefono.Name = "txt_telefono";
            this.txt_telefono.Size = new System.Drawing.Size(195, 20);
            this.txt_telefono.TabIndex = 10;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.lbl_info_telefono);
            this.groupBox2.Controls.Add(this.lbl_info_correo);
            this.groupBox2.Controls.Add(this.lbl_info_apmat);
            this.groupBox2.Controls.Add(this.lbl_info_appat);
            this.groupBox2.Controls.Add(this.lbl_info_nombre);
            this.groupBox2.Controls.Add(this.comboBox1);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Location = new System.Drawing.Point(214, 57);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(505, 381);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Clientes registrados";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.label7.Location = new System.Drawing.Point(76, 319);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 18);
            this.label7.TabIndex = 9;
            this.label7.Text = "Telefono:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.label8.Location = new System.Drawing.Point(76, 285);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(146, 18);
            this.label8.TabIndex = 7;
            this.label8.Text = "Correo electronio:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.label9.Location = new System.Drawing.Point(76, 249);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(139, 18);
            this.label9.TabIndex = 2;
            this.label9.Text = "Apellido materno:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.label10.Location = new System.Drawing.Point(76, 210);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(134, 18);
            this.label10.TabIndex = 1;
            this.label10.Text = "Apellido paterno:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.label11.Location = new System.Drawing.Point(76, 178);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(73, 18);
            this.label11.TabIndex = 0;
            this.label11.Text = "Nombre:";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(160, 69);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(209, 21);
            this.comboBox1.TabIndex = 10;
            // 
            // lbl_info_nombre
            // 
            this.lbl_info_nombre.AutoSize = true;
            this.lbl_info_nombre.Location = new System.Drawing.Point(271, 182);
            this.lbl_info_nombre.Name = "lbl_info_nombre";
            this.lbl_info_nombre.Size = new System.Drawing.Size(214, 13);
            this.lbl_info_nombre.TabIndex = 11;
            this.lbl_info_nombre.Text = "---------------------------------------------------------------------";
            // 
            // lbl_info_appat
            // 
            this.lbl_info_appat.AutoSize = true;
            this.lbl_info_appat.Location = new System.Drawing.Point(271, 215);
            this.lbl_info_appat.Name = "lbl_info_appat";
            this.lbl_info_appat.Size = new System.Drawing.Size(214, 13);
            this.lbl_info_appat.TabIndex = 12;
            this.lbl_info_appat.Text = "---------------------------------------------------------------------";
            // 
            // lbl_info_apmat
            // 
            this.lbl_info_apmat.AutoSize = true;
            this.lbl_info_apmat.Location = new System.Drawing.Point(271, 249);
            this.lbl_info_apmat.Name = "lbl_info_apmat";
            this.lbl_info_apmat.Size = new System.Drawing.Size(214, 13);
            this.lbl_info_apmat.TabIndex = 13;
            this.lbl_info_apmat.Text = "---------------------------------------------------------------------";
            // 
            // lbl_info_correo
            // 
            this.lbl_info_correo.AutoSize = true;
            this.lbl_info_correo.Location = new System.Drawing.Point(271, 285);
            this.lbl_info_correo.Name = "lbl_info_correo";
            this.lbl_info_correo.Size = new System.Drawing.Size(214, 13);
            this.lbl_info_correo.TabIndex = 14;
            this.lbl_info_correo.Text = "---------------------------------------------------------------------";
            // 
            // lbl_info_telefono
            // 
            this.lbl_info_telefono.AutoSize = true;
            this.lbl_info_telefono.Location = new System.Drawing.Point(271, 319);
            this.lbl_info_telefono.Name = "lbl_info_telefono";
            this.lbl_info_telefono.Size = new System.Drawing.Size(214, 13);
            this.lbl_info_telefono.TabIndex = 15;
            this.lbl_info_telefono.Text = "---------------------------------------------------------------------";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.label12.Location = new System.Drawing.Point(198, 35);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(138, 18);
            this.label12.TabIndex = 16;
            this.label12.Text = "Lista de Clientes:";
            // 
            // FormCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(731, 450);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gpbx_registrar);
            this.Name = "FormCliente";
            this.Text = "FormCliente";
            this.Load += new System.EventHandler(this.FormCliente_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gpbx_registrar.ResumeLayout(false);
            this.gpbx_registrar.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_selec;
        private System.Windows.Forms.RadioButton rdbtn_mostrar_clientes;
        private System.Windows.Forms.RadioButton rdbtn_agregar_cliente;
        private System.Windows.Forms.GroupBox gpbx_registrar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_ap_mat;
        private System.Windows.Forms.TextBox txt_ap_pat;
        private System.Windows.Forms.TextBox txt_nombre;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_registrar;
        private System.Windows.Forms.TextBox txt_correo;
        private System.Windows.Forms.TextBox txt_telefono;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lbl_info_telefono;
        private System.Windows.Forms.Label lbl_info_correo;
        private System.Windows.Forms.Label lbl_info_apmat;
        private System.Windows.Forms.Label lbl_info_appat;
        private System.Windows.Forms.Label lbl_info_nombre;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
    }
}