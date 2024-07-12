namespace DEP.Presentacion
{
    partial class frmActualizaDatosOpe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmActualizaDatosOpe));
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.cboTipoValorado = new GEN.ControlesBase.cboTipoValoradoFiltro(this.components);
            this.cboAgencia = new GEN.ControlesBase.cboAgencia(this.components);
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.dtgValoradosPend = new GEN.ControlesBase.dtgBase(this.components);
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.txtTipoPersona = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.txtFechaDocumento = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.txtTipCuenta = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.txtProducto = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase9 = new GEN.ControlesBase.lblBase();
            this.cboMoneda = new GEN.ControlesBase.cboMoneda(this.components);
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.grbBase3 = new GEN.ControlesBase.grbBase(this.components);
            this.dtpFechaEmi = new GEN.ControlesBase.dtpCorto(this.components);
            this.txtSerie = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase27 = new GEN.ControlesBase.lblBase();
            this.lblTipDoc = new GEN.ControlesBase.lblBase();
            this.txtNroDocu = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase45 = new GEN.ControlesBase.lblBase();
            this.btnEditar = new GEN.BotonesBase.btnEditar();
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.txtNroOpe = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.txtTipoOpe = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase10 = new GEN.ControlesBase.lblBase();
            this.txtFecOpe = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase11 = new GEN.ControlesBase.lblBase();
            this.grbBase1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgValoradosPend)).BeginInit();
            this.grbBase3.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.lblBase5);
            this.grbBase1.Controls.Add(this.cboTipoValorado);
            this.grbBase1.Controls.Add(this.cboAgencia);
            this.grbBase1.Controls.Add(this.lblBase6);
            this.grbBase1.ForeColor = System.Drawing.Color.Navy;
            this.grbBase1.Location = new System.Drawing.Point(6, 8);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(806, 50);
            this.grbBase1.TabIndex = 102;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Filtros de Búsqueda";
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(62, 18);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(63, 13);
            this.lblBase5.TabIndex = 106;
            this.lblBase5.Text = "Agencias:";
            // 
            // cboTipoValorado
            // 
            this.cboTipoValorado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoValorado.FormattingEnabled = true;
            this.cboTipoValorado.Location = new System.Drawing.Point(566, 15);
            this.cboTipoValorado.Name = "cboTipoValorado";
            this.cboTipoValorado.Size = new System.Drawing.Size(189, 21);
            this.cboTipoValorado.TabIndex = 105;
            // 
            // cboAgencia
            // 
            this.cboAgencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAgencia.FormattingEnabled = true;
            this.cboAgencia.Location = new System.Drawing.Point(142, 15);
            this.cboAgencia.Name = "cboAgencia";
            this.cboAgencia.Size = new System.Drawing.Size(246, 21);
            this.cboAgencia.TabIndex = 102;
            this.cboAgencia.SelectedIndexChanged += new System.EventHandler(this.cboAgencia_SelectedIndexChanged);
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(439, 22);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(108, 13);
            this.lblBase6.TabIndex = 3;
            this.lblBase6.Text = "Tipo de Valorado:";
            // 
            // dtgValoradosPend
            // 
            this.dtgValoradosPend.AllowUserToAddRows = false;
            this.dtgValoradosPend.AllowUserToDeleteRows = false;
            this.dtgValoradosPend.AllowUserToResizeColumns = false;
            this.dtgValoradosPend.AllowUserToResizeRows = false;
            this.dtgValoradosPend.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgValoradosPend.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgValoradosPend.Location = new System.Drawing.Point(6, 91);
            this.dtgValoradosPend.MultiSelect = false;
            this.dtgValoradosPend.Name = "dtgValoradosPend";
            this.dtgValoradosPend.ReadOnly = true;
            this.dtgValoradosPend.RowHeadersVisible = false;
            this.dtgValoradosPend.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgValoradosPend.Size = new System.Drawing.Size(804, 168);
            this.dtgValoradosPend.TabIndex = 104;
            this.dtgValoradosPend.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgValoradosPend_RowEnter);
            // 
            // lblBase7
            // 
            this.lblBase7.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lblBase7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(6, 64);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(804, 26);
            this.lblBase7.TabIndex = 103;
            this.lblBase7.Text = "OPERACIONES PENDIENTES DE ACTUALIZACIÓN";
            this.lblBase7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(10, 288);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(78, 13);
            this.lblBase2.TabIndex = 124;
            this.lblBase2.Text = "Tipo cuenta:";
            // 
            // txtTipoPersona
            // 
            this.txtTipoPersona.Enabled = false;
            this.txtTipoPersona.Location = new System.Drawing.Point(442, 311);
            this.txtTipoPersona.Name = "txtTipoPersona";
            this.txtTipoPersona.ReadOnly = true;
            this.txtTipoPersona.Size = new System.Drawing.Size(369, 20);
            this.txtTipoPersona.TabIndex = 133;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(350, 287);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(56, 13);
            this.lblBase3.TabIndex = 125;
            this.lblBase3.Text = "Moneda:";
            // 
            // txtFechaDocumento
            // 
            this.txtFechaDocumento.Enabled = false;
            this.txtFechaDocumento.Location = new System.Drawing.Point(702, 283);
            this.txtFechaDocumento.MaxLength = 100;
            this.txtFechaDocumento.Name = "txtFechaDocumento";
            this.txtFechaDocumento.ReadOnly = true;
            this.txtFechaDocumento.Size = new System.Drawing.Size(109, 20);
            this.txtFechaDocumento.TabIndex = 132;
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(10, 315);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(62, 13);
            this.lblBase4.TabIndex = 126;
            this.lblBase4.Text = "Producto:";
            // 
            // txtTipCuenta
            // 
            this.txtTipCuenta.Enabled = false;
            this.txtTipCuenta.Location = new System.Drawing.Point(94, 285);
            this.txtTipCuenta.Name = "txtTipCuenta";
            this.txtTipCuenta.ReadOnly = true;
            this.txtTipCuenta.Size = new System.Drawing.Size(248, 20);
            this.txtTipCuenta.TabIndex = 131;
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(350, 315);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(86, 13);
            this.lblBase8.TabIndex = 127;
            this.lblBase8.Text = "Tipo persona:";
            // 
            // txtProducto
            // 
            this.txtProducto.Enabled = false;
            this.txtProducto.Location = new System.Drawing.Point(94, 311);
            this.txtProducto.Name = "txtProducto";
            this.txtProducto.ReadOnly = true;
            this.txtProducto.Size = new System.Drawing.Size(248, 20);
            this.txtProducto.TabIndex = 130;
            // 
            // lblBase9
            // 
            this.lblBase9.AutoSize = true;
            this.lblBase9.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase9.ForeColor = System.Drawing.Color.Navy;
            this.lblBase9.Location = new System.Drawing.Point(594, 287);
            this.lblBase9.Name = "lblBase9";
            this.lblBase9.Size = new System.Drawing.Size(102, 13);
            this.lblBase9.TabIndex = 128;
            this.lblBase9.Text = "Fec. documento:";
            // 
            // cboMoneda
            // 
            this.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMoneda.Enabled = false;
            this.cboMoneda.FormattingEnabled = true;
            this.cboMoneda.Location = new System.Drawing.Point(442, 283);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Size = new System.Drawing.Size(146, 21);
            this.cboMoneda.TabIndex = 129;
            // 
            // grbBase2
            // 
            this.grbBase2.Location = new System.Drawing.Point(6, 265);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(806, 76);
            this.grbBase2.TabIndex = 134;
            this.grbBase2.TabStop = false;
            this.grbBase2.Text = "Datos de la Cuenta";
            // 
            // grbBase3
            // 
            this.grbBase3.Controls.Add(this.dtpFechaEmi);
            this.grbBase3.Controls.Add(this.txtSerie);
            this.grbBase3.Controls.Add(this.lblBase27);
            this.grbBase3.Controls.Add(this.lblTipDoc);
            this.grbBase3.Controls.Add(this.txtNroDocu);
            this.grbBase3.Controls.Add(this.lblBase45);
            this.grbBase3.Location = new System.Drawing.Point(6, 403);
            this.grbBase3.Name = "grbBase3";
            this.grbBase3.Size = new System.Drawing.Size(806, 63);
            this.grbBase3.TabIndex = 135;
            this.grbBase3.TabStop = false;
            this.grbBase3.Text = "Datos a Modificar del Documento";
            // 
            // dtpFechaEmi
            // 
            this.dtpFechaEmi.Enabled = false;
            this.dtpFechaEmi.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaEmi.Location = new System.Drawing.Point(151, 26);
            this.dtpFechaEmi.Name = "dtpFechaEmi";
            this.dtpFechaEmi.Size = new System.Drawing.Size(136, 20);
            this.dtpFechaEmi.TabIndex = 153;
            // 
            // txtSerie
            // 
            this.txtSerie.Enabled = false;
            this.txtSerie.Location = new System.Drawing.Point(641, 28);
            this.txtSerie.MaxLength = 7;
            this.txtSerie.Name = "txtSerie";
            this.txtSerie.Size = new System.Drawing.Size(88, 20);
            this.txtSerie.TabIndex = 152;
            // 
            // lblBase27
            // 
            this.lblBase27.AutoSize = true;
            this.lblBase27.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase27.ForeColor = System.Drawing.Color.Navy;
            this.lblBase27.Location = new System.Drawing.Point(54, 29);
            this.lblBase27.Name = "lblBase27";
            this.lblBase27.Size = new System.Drawing.Size(93, 13);
            this.lblBase27.TabIndex = 156;
            this.lblBase27.Text = "Fecha Emisión:";
            // 
            // lblTipDoc
            // 
            this.lblTipDoc.AutoSize = true;
            this.lblTipDoc.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblTipDoc.ForeColor = System.Drawing.Color.Navy;
            this.lblTipDoc.Location = new System.Drawing.Point(327, 30);
            this.lblTipDoc.Name = "lblTipDoc";
            this.lblTipDoc.Size = new System.Drawing.Size(101, 13);
            this.lblTipDoc.TabIndex = 154;
            this.lblTipDoc.Text = "Nro Documento:";
            // 
            // txtNroDocu
            // 
            this.txtNroDocu.Enabled = false;
            this.txtNroDocu.Location = new System.Drawing.Point(431, 28);
            this.txtNroDocu.MaxLength = 20;
            this.txtNroDocu.Name = "txtNroDocu";
            this.txtNroDocu.Size = new System.Drawing.Size(136, 20);
            this.txtNroDocu.TabIndex = 151;
            // 
            // lblBase45
            // 
            this.lblBase45.AutoSize = true;
            this.lblBase45.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase45.ForeColor = System.Drawing.Color.Navy;
            this.lblBase45.Location = new System.Drawing.Point(596, 31);
            this.lblBase45.Name = "lblBase45";
            this.lblBase45.Size = new System.Drawing.Size(42, 13);
            this.lblBase45.TabIndex = 155;
            this.lblBase45.Text = "Serie:";
            // 
            // btnEditar
            // 
            this.btnEditar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar.BackgroundImage")));
            this.btnEditar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar.Enabled = false;
            this.btnEditar.Location = new System.Drawing.Point(526, 475);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(60, 50);
            this.btnEditar.TabIndex = 136;
            this.btnEditar.Text = "&Editar";
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Enabled = false;
            this.btnGrabar.Location = new System.Drawing.Point(586, 475);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 137;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Enabled = false;
            this.btnCancelar.Location = new System.Drawing.Point(646, 475);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 138;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(748, 475);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 139;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // txtNroOpe
            // 
            this.txtNroOpe.Enabled = false;
            this.txtNroOpe.Location = new System.Drawing.Point(111, 358);
            this.txtNroOpe.MaxLength = 100;
            this.txtNroOpe.Name = "txtNroOpe";
            this.txtNroOpe.ReadOnly = true;
            this.txtNroOpe.Size = new System.Drawing.Size(117, 20);
            this.txtNroOpe.TabIndex = 141;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(10, 360);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(98, 13);
            this.lblBase1.TabIndex = 140;
            this.lblBase1.Text = "Nro. Operación:";
            // 
            // txtTipoOpe
            // 
            this.txtTipoOpe.Enabled = false;
            this.txtTipoOpe.Location = new System.Drawing.Point(334, 358);
            this.txtTipoOpe.MaxLength = 100;
            this.txtTipoOpe.Name = "txtTipoOpe";
            this.txtTipoOpe.ReadOnly = true;
            this.txtTipoOpe.Size = new System.Drawing.Size(261, 20);
            this.txtTipoOpe.TabIndex = 143;
            // 
            // lblBase10
            // 
            this.lblBase10.AutoSize = true;
            this.lblBase10.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase10.ForeColor = System.Drawing.Color.Navy;
            this.lblBase10.Location = new System.Drawing.Point(233, 361);
            this.lblBase10.Name = "lblBase10";
            this.lblBase10.Size = new System.Drawing.Size(98, 13);
            this.lblBase10.TabIndex = 142;
            this.lblBase10.Text = "Tipo Operación:";
            // 
            // txtFecOpe
            // 
            this.txtFecOpe.Enabled = false;
            this.txtFecOpe.Location = new System.Drawing.Point(699, 358);
            this.txtFecOpe.MaxLength = 100;
            this.txtFecOpe.Name = "txtFecOpe";
            this.txtFecOpe.ReadOnly = true;
            this.txtFecOpe.Size = new System.Drawing.Size(109, 20);
            this.txtFecOpe.TabIndex = 145;
            // 
            // lblBase11
            // 
            this.lblBase11.AutoSize = true;
            this.lblBase11.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase11.ForeColor = System.Drawing.Color.Navy;
            this.lblBase11.Location = new System.Drawing.Point(600, 361);
            this.lblBase11.Name = "lblBase11";
            this.lblBase11.Size = new System.Drawing.Size(97, 13);
            this.lblBase11.TabIndex = 144;
            this.lblBase11.Text = "Fec. Operación:";
            // 
            // frmActualizaDatosOpe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 561);
            this.Controls.Add(this.txtFecOpe);
            this.Controls.Add(this.lblBase11);
            this.Controls.Add(this.txtTipoOpe);
            this.Controls.Add(this.lblBase10);
            this.Controls.Add(this.txtNroOpe);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.grbBase3);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.txtTipoPersona);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.txtFechaDocumento);
            this.Controls.Add(this.lblBase4);
            this.Controls.Add(this.txtTipCuenta);
            this.Controls.Add(this.lblBase8);
            this.Controls.Add(this.txtProducto);
            this.Controls.Add(this.lblBase9);
            this.Controls.Add(this.cboMoneda);
            this.Controls.Add(this.dtgValoradosPend);
            this.Controls.Add(this.lblBase7);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.grbBase2);
            this.Name = "frmActualizaDatosOpe";
            this.Text = "Actualizar Datos de  la Operación (INTERBANCARIOS)";
            this.Load += new System.EventHandler(this.frmActualizaDatosOpe_Load);
            this.Controls.SetChildIndex(this.grbBase2, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.lblBase7, 0);
            this.Controls.SetChildIndex(this.dtgValoradosPend, 0);
            this.Controls.SetChildIndex(this.cboMoneda, 0);
            this.Controls.SetChildIndex(this.lblBase9, 0);
            this.Controls.SetChildIndex(this.txtProducto, 0);
            this.Controls.SetChildIndex(this.lblBase8, 0);
            this.Controls.SetChildIndex(this.txtTipCuenta, 0);
            this.Controls.SetChildIndex(this.lblBase4, 0);
            this.Controls.SetChildIndex(this.txtFechaDocumento, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.Controls.SetChildIndex(this.txtTipoPersona, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.grbBase3, 0);
            this.Controls.SetChildIndex(this.btnEditar, 0);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.txtNroOpe, 0);
            this.Controls.SetChildIndex(this.lblBase10, 0);
            this.Controls.SetChildIndex(this.txtTipoOpe, 0);
            this.Controls.SetChildIndex(this.lblBase11, 0);
            this.Controls.SetChildIndex(this.txtFecOpe, 0);
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgValoradosPend)).EndInit();
            this.grbBase3.ResumeLayout(false);
            this.grbBase3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.cboTipoValoradoFiltro cboTipoValorado;
        private GEN.ControlesBase.cboAgencia cboAgencia;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.dtgBase dtgValoradosPend;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.txtBase txtTipoPersona;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.txtBase txtFechaDocumento;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.txtBase txtTipCuenta;
        private GEN.ControlesBase.lblBase lblBase8;
        private GEN.ControlesBase.txtBase txtProducto;
        private GEN.ControlesBase.lblBase lblBase9;
        private GEN.ControlesBase.cboMoneda cboMoneda;
        private GEN.ControlesBase.grbBase grbBase2;
        private GEN.ControlesBase.grbBase grbBase3;
        private GEN.BotonesBase.btnEditar btnEditar;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.BotonesBase.btnSalir btnSalir;
        public GEN.ControlesBase.dtpCorto dtpFechaEmi;
        private GEN.ControlesBase.txtBase txtSerie;
        private GEN.ControlesBase.lblBase lblBase27;
        private GEN.ControlesBase.lblBase lblTipDoc;
        private GEN.ControlesBase.txtBase txtNroDocu;
        private GEN.ControlesBase.lblBase lblBase45;
        private GEN.ControlesBase.txtBase txtNroOpe;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.txtBase txtTipoOpe;
        private GEN.ControlesBase.lblBase lblBase10;
        private GEN.ControlesBase.txtBase txtFecOpe;
        private GEN.ControlesBase.lblBase lblBase11;
    }
}