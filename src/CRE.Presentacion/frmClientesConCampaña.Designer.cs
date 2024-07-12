namespace CRE.Presentacion
{
    partial class frmClientesConCampaña
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmClientesConCampaña));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cboCampania = new GEN.ControlesBase.cboBase(this.components);
            this.cboRegion = new GEN.ControlesBase.cboBase(this.components);
            this.cboOficina = new GEN.ControlesBase.cboBase(this.components);
            this.cboEstablecimiento = new GEN.ControlesBase.cboBase(this.components);
            this.dtgOfertasCre = new System.Windows.Forms.DataGridView();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.label6 = new System.Windows.Forms.Label();
            this.cboAsesor = new GEN.ControlesBase.cboBase(this.components);
            this.btnBuscarOfertas = new GEN.BotonesBase.btnBusqueda();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblBase10 = new GEN.ControlesBase.lblBase();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblDireccion = new GEN.ControlesBase.lblBase();
            this.lblRContacto = new GEN.ControlesBase.lblBase();
            this.lblTContacto = new GEN.ControlesBase.lblBase();
            this.lblCorreo = new GEN.ControlesBase.lblBase();
            this.lblTelefono = new GEN.ControlesBase.lblBase();
            this.lblNombre = new GEN.ControlesBase.lblBase();
            this.lblBase9 = new GEN.ControlesBase.lblBase();
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.txtCliente = new GEN.ControlesBase.txtBase(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.btnBuscarCliente = new GEN.BotonesBase.btnMiniBusqueda(this.components);
            this.btnBloquear = new GEN.BotonesBase.btnBlanco();
            ((System.ComponentModel.ISupportInitialize)(this.dtgOfertasCre)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Campaña: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(283, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Región: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(551, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Oficina: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Establec.: ";
            // 
            // cboCampania
            // 
            this.cboCampania.FormattingEnabled = true;
            this.cboCampania.Location = new System.Drawing.Point(60, 9);
            this.cboCampania.Name = "cboCampania";
            this.cboCampania.Size = new System.Drawing.Size(219, 21);
            this.cboCampania.TabIndex = 7;
            this.cboCampania.SelectedIndexChanged += new System.EventHandler(this.cboCampania_SelectedIndexChanged);
            // 
            // cboRegion
            // 
            this.cboRegion.FormattingEnabled = true;
            this.cboRegion.Location = new System.Drawing.Point(326, 10);
            this.cboRegion.Name = "cboRegion";
            this.cboRegion.Size = new System.Drawing.Size(219, 21);
            this.cboRegion.TabIndex = 8;
            this.cboRegion.SelectedIndexChanged += new System.EventHandler(this.cboRegion_SelectedIndexChanged);
            // 
            // cboOficina
            // 
            this.cboOficina.FormattingEnabled = true;
            this.cboOficina.Location = new System.Drawing.Point(599, 11);
            this.cboOficina.Name = "cboOficina";
            this.cboOficina.Size = new System.Drawing.Size(219, 21);
            this.cboOficina.TabIndex = 9;
            this.cboOficina.SelectedIndexChanged += new System.EventHandler(this.cboOficina_SelectedIndexChanged);
            // 
            // cboEstablecimiento
            // 
            this.cboEstablecimiento.FormattingEnabled = true;
            this.cboEstablecimiento.Location = new System.Drawing.Point(60, 33);
            this.cboEstablecimiento.Name = "cboEstablecimiento";
            this.cboEstablecimiento.Size = new System.Drawing.Size(219, 21);
            this.cboEstablecimiento.TabIndex = 10;
            this.cboEstablecimiento.SelectedIndexChanged += new System.EventHandler(this.cboEstablecimiento_SelectedIndexChanged);
            // 
            // dtgOfertasCre
            // 
            this.dtgOfertasCre.AllowUserToAddRows = false;
            this.dtgOfertasCre.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgOfertasCre.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgOfertasCre.Location = new System.Drawing.Point(7, 66);
            this.dtgOfertasCre.Name = "dtgOfertasCre";
            this.dtgOfertasCre.Size = new System.Drawing.Size(877, 307);
            this.dtgOfertasCre.TabIndex = 11;
            this.dtgOfertasCre.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgOfertasCre_CellClick);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(824, 446);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 12;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(285, 37);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Asesor: ";
            // 
            // cboAsesor
            // 
            this.cboAsesor.FormattingEnabled = true;
            this.cboAsesor.Location = new System.Drawing.Point(326, 34);
            this.cboAsesor.Name = "cboAsesor";
            this.cboAsesor.Size = new System.Drawing.Size(219, 21);
            this.cboAsesor.TabIndex = 16;
            this.cboAsesor.SelectedIndexChanged += new System.EventHandler(this.cboAsesor_SelectedIndexChanged);
            // 
            // btnBuscarOfertas
            // 
            this.btnBuscarOfertas.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBuscarOfertas.BackgroundImage")));
            this.btnBuscarOfertas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBuscarOfertas.Location = new System.Drawing.Point(824, 10);
            this.btnBuscarOfertas.Name = "btnBuscarOfertas";
            this.btnBuscarOfertas.Size = new System.Drawing.Size(60, 50);
            this.btnBuscarOfertas.TabIndex = 17;
            this.btnBuscarOfertas.Text = "&Buscar";
            this.btnBuscarOfertas.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBuscarOfertas.UseVisualStyleBackColor = true;
            this.btnBuscarOfertas.Click += new System.EventHandler(this.btnBuscarOfertas_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.Yellow;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(114, 18);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(40, 13);
            this.textBox1.TabIndex = 18;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.LawnGreen;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(259, 18);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(40, 13);
            this.textBox2.TabIndex = 19;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(157, 18);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(84, 13);
            this.lblBase1.TabIndex = 20;
            this.lblBase1.Text = "En Ventanilla.";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(302, 18);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(95, 13);
            this.lblBase2.TabIndex = 21;
            this.lblBase2.Text = "Desembolsado.";
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.SystemColors.HighlightText;
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Enabled = false;
            this.textBox3.Location = new System.Drawing.Point(7, 18);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(40, 13);
            this.textBox3.TabIndex = 22;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(50, 18);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(47, 13);
            this.lblBase3.TabIndex = 23;
            this.lblBase3.Text = "Oferta.";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblBase10);
            this.groupBox1.Controls.Add(this.textBox4);
            this.groupBox1.Controls.Add(this.lblBase3);
            this.groupBox1.Controls.Add(this.lblBase1);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.lblBase2);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Location = new System.Drawing.Point(7, 457);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(716, 39);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Leyenda";
            // 
            // lblBase10
            // 
            this.lblBase10.AutoSize = true;
            this.lblBase10.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase10.ForeColor = System.Drawing.Color.Navy;
            this.lblBase10.Location = new System.Drawing.Point(458, 18);
            this.lblBase10.Name = "lblBase10";
            this.lblBase10.Size = new System.Drawing.Size(71, 13);
            this.lblBase10.TabIndex = 25;
            this.lblBase10.Text = "Bloqueado.";
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.Color.LightSalmon;
            this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox4.Enabled = false;
            this.textBox4.Location = new System.Drawing.Point(415, 18);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(40, 13);
            this.textBox4.TabIndex = 24;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblDireccion);
            this.groupBox2.Controls.Add(this.lblRContacto);
            this.groupBox2.Controls.Add(this.lblTContacto);
            this.groupBox2.Controls.Add(this.lblCorreo);
            this.groupBox2.Controls.Add(this.lblTelefono);
            this.groupBox2.Controls.Add(this.lblNombre);
            this.groupBox2.Controls.Add(this.lblBase9);
            this.groupBox2.Controls.Add(this.lblBase8);
            this.groupBox2.Controls.Add(this.lblBase7);
            this.groupBox2.Controls.Add(this.lblBase6);
            this.groupBox2.Controls.Add(this.lblBase5);
            this.groupBox2.Controls.Add(this.lblBase4);
            this.groupBox2.Location = new System.Drawing.Point(7, 379);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(716, 72);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Gestión de Contacto";
            // 
            // lblDireccion
            // 
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblDireccion.ForeColor = System.Drawing.Color.Navy;
            this.lblDireccion.Location = new System.Drawing.Point(66, 56);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(222, 13);
            this.lblDireccion.TabIndex = 11;
            this.lblDireccion.Text = "lblBase15--------------------------------";
            // 
            // lblRContacto
            // 
            this.lblRContacto.AutoSize = true;
            this.lblRContacto.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblRContacto.ForeColor = System.Drawing.Color.Navy;
            this.lblRContacto.Location = new System.Drawing.Point(389, 56);
            this.lblRContacto.Name = "lblRContacto";
            this.lblRContacto.Size = new System.Drawing.Size(62, 13);
            this.lblRContacto.TabIndex = 10;
            this.lblRContacto.Text = "lblBase14";
            // 
            // lblTContacto
            // 
            this.lblTContacto.AutoSize = true;
            this.lblTContacto.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblTContacto.ForeColor = System.Drawing.Color.Navy;
            this.lblTContacto.Location = new System.Drawing.Point(389, 37);
            this.lblTContacto.Name = "lblTContacto";
            this.lblTContacto.Size = new System.Drawing.Size(62, 13);
            this.lblTContacto.TabIndex = 9;
            this.lblTContacto.Text = "lblBase13";
            // 
            // lblCorreo
            // 
            this.lblCorreo.AutoSize = true;
            this.lblCorreo.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblCorreo.ForeColor = System.Drawing.Color.Navy;
            this.lblCorreo.Location = new System.Drawing.Point(66, 37);
            this.lblCorreo.Name = "lblCorreo";
            this.lblCorreo.Size = new System.Drawing.Size(222, 13);
            this.lblCorreo.TabIndex = 8;
            this.lblCorreo.Text = "lblBase12--------------------------------";
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblTelefono.ForeColor = System.Drawing.Color.Navy;
            this.lblTelefono.Location = new System.Drawing.Point(389, 18);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(62, 13);
            this.lblTelefono.TabIndex = 7;
            this.lblTelefono.Text = "lblBase11";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblNombre.ForeColor = System.Drawing.Color.Navy;
            this.lblNombre.Location = new System.Drawing.Point(66, 19);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(222, 13);
            this.lblNombre.TabIndex = 6;
            this.lblNombre.Text = "lblBase10--------------------------------";
            // 
            // lblBase9
            // 
            this.lblBase9.AutoSize = true;
            this.lblBase9.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase9.ForeColor = System.Drawing.Color.Navy;
            this.lblBase9.Location = new System.Drawing.Point(6, 56);
            this.lblBase9.Name = "lblBase9";
            this.lblBase9.Size = new System.Drawing.Size(69, 13);
            this.lblBase9.TabIndex = 5;
            this.lblBase9.Text = "Dirección: ";
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(299, 56);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(96, 13);
            this.lblBase8.TabIndex = 4;
            this.lblBase8.Text = "Rsp. Contacto: ";
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(299, 37);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(92, 13);
            this.lblBase7.TabIndex = 3;
            this.lblBase7.Text = "Tip. Contacto: ";
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(6, 37);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(56, 13);
            this.lblBase6.TabIndex = 2;
            this.lblBase6.Text = "Correo: ";
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(299, 18);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(60, 13);
            this.lblBase5.TabIndex = 1;
            this.lblBase5.Text = "Teléfono:";
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(6, 18);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(61, 13);
            this.lblBase4.TabIndex = 0;
            this.lblBase4.Text = "Nombre: ";
            // 
            // txtCliente
            // 
            this.txtCliente.Location = new System.Drawing.Point(599, 35);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(219, 20);
            this.txtCliente.TabIndex = 26;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(552, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 27;
            this.label5.Text = "Cliente: ";
            // 
            // btnBuscarCliente
            // 
            this.btnBuscarCliente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscarCliente.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBuscarCliente.BackgroundImage")));
            this.btnBuscarCliente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBuscarCliente.Location = new System.Drawing.Point(796, 34);
            this.btnBuscarCliente.Name = "btnBuscarCliente";
            this.btnBuscarCliente.Size = new System.Drawing.Size(23, 22);
            this.btnBuscarCliente.TabIndex = 70;
            this.btnBuscarCliente.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBuscarCliente.UseVisualStyleBackColor = true;
            this.btnBuscarCliente.Click += new System.EventHandler(this.btnBuscarCliente_Click);
            // 
            // btnBloquear
            // 
            this.btnBloquear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBloquear.Image = global::CRE.Presentacion.Properties.Resources.BloqDesbloq;
            this.btnBloquear.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnBloquear.Location = new System.Drawing.Point(758, 446);
            this.btnBloquear.Name = "btnBloquear";
            this.btnBloquear.Size = new System.Drawing.Size(60, 50);
            this.btnBloquear.TabIndex = 71;
            this.btnBloquear.Text = "Gest.  de Bloqueos";
            this.btnBloquear.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBloquear.UseVisualStyleBackColor = true;
            this.btnBloquear.Click += new System.EventHandler(this.btnBloquear_Click);
            // 
            // frmClientesConCampaña
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(890, 523);
            this.Controls.Add(this.btnBloquear);
            this.Controls.Add(this.btnBuscarCliente);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtCliente);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnBuscarOfertas);
            this.Controls.Add(this.cboAsesor);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.dtgOfertasCre);
            this.Controls.Add(this.cboEstablecimiento);
            this.Controls.Add(this.cboOficina);
            this.Controls.Add(this.cboRegion);
            this.Controls.Add(this.cboCampania);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmClientesConCampaña";
            this.Text = "Clientes con Campaña";
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.cboCampania, 0);
            this.Controls.SetChildIndex(this.cboRegion, 0);
            this.Controls.SetChildIndex(this.cboOficina, 0);
            this.Controls.SetChildIndex(this.cboEstablecimiento, 0);
            this.Controls.SetChildIndex(this.dtgOfertasCre, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.cboAsesor, 0);
            this.Controls.SetChildIndex(this.btnBuscarOfertas, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.txtCliente, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.btnBuscarCliente, 0);
            this.Controls.SetChildIndex(this.btnBloquear, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgOfertasCre)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private GEN.ControlesBase.cboBase cboCampania;
        private GEN.ControlesBase.cboBase cboRegion;
        private GEN.ControlesBase.cboBase cboOficina;
        private GEN.ControlesBase.cboBase cboEstablecimiento;
        private System.Windows.Forms.DataGridView dtgOfertasCre;
        private GEN.BotonesBase.btnSalir btnSalir;
        private System.Windows.Forms.Label label6;
        private GEN.ControlesBase.cboBase cboAsesor;
        private GEN.BotonesBase.btnBusqueda btnBuscarOfertas;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase2;
        private System.Windows.Forms.TextBox textBox3;
        private GEN.ControlesBase.lblBase lblBase3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private GEN.ControlesBase.lblBase lblDireccion;
        private GEN.ControlesBase.lblBase lblRContacto;
        private GEN.ControlesBase.lblBase lblTContacto;
        private GEN.ControlesBase.lblBase lblCorreo;
        private GEN.ControlesBase.lblBase lblTelefono;
        private GEN.ControlesBase.lblBase lblNombre;
        private GEN.ControlesBase.lblBase lblBase9;
        private GEN.ControlesBase.lblBase lblBase8;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.txtBase txtCliente;
        private System.Windows.Forms.Label label5;
        private GEN.BotonesBase.btnMiniBusqueda btnBuscarCliente;
        private GEN.BotonesBase.btnBlanco btnBloquear;
        private GEN.ControlesBase.lblBase lblBase10;
        private System.Windows.Forms.TextBox textBox4;
    }
}