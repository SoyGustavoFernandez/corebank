namespace DEP.Presentacion
{
    partial class frmBloqCuenta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBloqCuenta));
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.txtProducto = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.cboMoneda = new GEN.ControlesBase.cboMoneda(this.components);
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.txtMonto = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.txtObservacion = new GEN.ControlesBase.txtBase(this.components);
            this.dtgBloqueosCta = new System.Windows.Forms.DataGridView();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.txtMonBloq = new GEN.ControlesBase.txtNumRea(this.components);
            this.cboTipoBloqueo = new GEN.ControlesBase.cboTipoBloqueo(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.cboCaractBloq = new GEN.ControlesBase.cboBase(this.components);
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.dtpFecDoc = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblBase9 = new GEN.ControlesBase.lblBase();
            this.grbBase3 = new GEN.ControlesBase.grbBase(this.components);
            this.txtTotalBloq = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.btnAgregar = new GEN.BotonesBase.btnAgregar();
            this.btnEditar = new GEN.BotonesBase.btnEditar();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.conBusCtaAho = new GEN.ControlesBase.conBusCtaAho();
            this.conBusCol = new GEN.ControlesBase.ConBusCol();
            this.grbBase4 = new GEN.ControlesBase.grbBase(this.components);
            this.rbtExterno = new GEN.ControlesBase.rbtBase(this.components);
            this.rbtInterno = new GEN.ControlesBase.rbtBase(this.components);
            this.txtNombre = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase10 = new GEN.ControlesBase.lblBase();
            this.grbBase5 = new GEN.ControlesBase.grbBase(this.components);
            this.grbBase1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgBloqueosCta)).BeginInit();
            this.grbBase2.SuspendLayout();
            this.grbBase3.SuspendLayout();
            this.grbBase4.SuspendLayout();
            this.grbBase5.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.txtProducto);
            this.grbBase1.Controls.Add(this.lblBase4);
            this.grbBase1.Controls.Add(this.cboMoneda);
            this.grbBase1.Controls.Add(this.lblBase6);
            this.grbBase1.Controls.Add(this.txtMonto);
            this.grbBase1.Controls.Add(this.lblBase7);
            this.grbBase1.Location = new System.Drawing.Point(3, 119);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(741, 55);
            this.grbBase1.TabIndex = 1;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Datos de la Cuenta:";
            // 
            // txtProducto
            // 
            this.txtProducto.Enabled = false;
            this.txtProducto.Location = new System.Drawing.Point(75, 20);
            this.txtProducto.Name = "txtProducto";
            this.txtProducto.Size = new System.Drawing.Size(251, 20);
            this.txtProducto.TabIndex = 0;
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(10, 23);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(62, 13);
            this.lblBase4.TabIndex = 12;
            this.lblBase4.Text = "Producto:";
            // 
            // cboMoneda
            // 
            this.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMoneda.Enabled = false;
            this.cboMoneda.FormattingEnabled = true;
            this.cboMoneda.Location = new System.Drawing.Point(392, 20);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Size = new System.Drawing.Size(142, 21);
            this.cboMoneda.TabIndex = 1;
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(335, 23);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(56, 13);
            this.lblBase6.TabIndex = 1;
            this.lblBase6.Text = "Moneda:";
            // 
            // txtMonto
            // 
            this.txtMonto.BackColor = System.Drawing.SystemColors.Control;
            this.txtMonto.Enabled = false;
            this.txtMonto.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMonto.Location = new System.Drawing.Point(591, 21);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(131, 21);
            this.txtMonto.TabIndex = 2;
            this.txtMonto.Text = "0.00";
            this.txtMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(545, 24);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(46, 13);
            this.lblBase7.TabIndex = 10;
            this.lblBase7.Text = "Monto:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(9, 393);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(99, 13);
            this.lblBase2.TabIndex = 40;
            this.lblBase2.Text = "Motivo Bloqueo:";
            // 
            // txtObservacion
            // 
            this.txtObservacion.Enabled = false;
            this.txtObservacion.Location = new System.Drawing.Point(116, 393);
            this.txtObservacion.Multiline = true;
            this.txtObservacion.Name = "txtObservacion";
            this.txtObservacion.Size = new System.Drawing.Size(609, 48);
            this.txtObservacion.TabIndex = 4;
            // 
            // dtgBloqueosCta
            // 
            this.dtgBloqueosCta.AllowUserToAddRows = false;
            this.dtgBloqueosCta.AllowUserToDeleteRows = false;
            this.dtgBloqueosCta.AllowUserToResizeColumns = false;
            this.dtgBloqueosCta.AllowUserToResizeRows = false;
            this.dtgBloqueosCta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgBloqueosCta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgBloqueosCta.Location = new System.Drawing.Point(7, 451);
            this.dtgBloqueosCta.MultiSelect = false;
            this.dtgBloqueosCta.Name = "dtgBloqueosCta";
            this.dtgBloqueosCta.ReadOnly = true;
            this.dtgBloqueosCta.RowHeadersVisible = false;
            this.dtgBloqueosCta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgBloqueosCta.Size = new System.Drawing.Size(666, 107);
            this.dtgBloqueosCta.TabIndex = 45;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(8, 20);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(117, 13);
            this.lblBase1.TabIndex = 46;
            this.lblBase1.Text = "Motivo de Bloqueo:";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(10, 223);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(46, 13);
            this.lblBase3.TabIndex = 47;
            this.lblBase3.Text = "Monto:";
            // 
            // txtMonBloq
            // 
            this.txtMonBloq.Enabled = false;
            this.txtMonBloq.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMonBloq.FormatoDecimal = true;
            this.txtMonBloq.Location = new System.Drawing.Point(129, 45);
            this.txtMonBloq.Name = "txtMonBloq";
            this.txtMonBloq.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtMonBloq.nNumDecimales = 2;
            this.txtMonBloq.nvalor = 0D;
            this.txtMonBloq.Size = new System.Drawing.Size(127, 20);
            this.txtMonBloq.TabIndex = 2;
            this.txtMonBloq.Text = "0.00";
            this.txtMonBloq.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cboTipoBloqueo
            // 
            this.cboTipoBloqueo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoBloqueo.Enabled = false;
            this.cboTipoBloqueo.FormattingEnabled = true;
            this.cboTipoBloqueo.Location = new System.Drawing.Point(129, 17);
            this.cboTipoBloqueo.Name = "cboTipoBloqueo";
            this.cboTipoBloqueo.Size = new System.Drawing.Size(254, 21);
            this.cboTipoBloqueo.TabIndex = 0;
            this.cboTipoBloqueo.SelectedIndexChanged += new System.EventHandler(this.cboTipoBloqueo_SelectedIndexChanged);
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(393, 19);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(86, 13);
            this.lblBase5.TabIndex = 50;
            this.lblBase5.Text = "Tipo Bloqueo:";
            // 
            // cboCaractBloq
            // 
            this.cboCaractBloq.Enabled = false;
            this.cboCaractBloq.FormattingEnabled = true;
            this.cboCaractBloq.Location = new System.Drawing.Point(483, 16);
            this.cboCaractBloq.Name = "cboCaractBloq";
            this.cboCaractBloq.Size = new System.Drawing.Size(239, 21);
            this.cboCaractBloq.TabIndex = 1;
            this.cboCaractBloq.SelectedIndexChanged += new System.EventHandler(this.cboCaractBloq_SelectedIndexChanged);
            // 
            // grbBase2
            // 
            this.grbBase2.Controls.Add(this.dtpFecDoc);
            this.grbBase2.Controls.Add(this.cboCaractBloq);
            this.grbBase2.Controls.Add(this.lblBase9);
            this.grbBase2.Controls.Add(this.lblBase5);
            this.grbBase2.Controls.Add(this.cboTipoBloqueo);
            this.grbBase2.Controls.Add(this.txtMonBloq);
            this.grbBase2.Controls.Add(this.lblBase1);
            this.grbBase2.Location = new System.Drawing.Point(2, 175);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(742, 78);
            this.grbBase2.TabIndex = 2;
            this.grbBase2.TabStop = false;
            this.grbBase2.Text = "Datos del Bloqueo";
            // 
            // dtpFecDoc
            // 
            this.dtpFecDoc.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecDoc.Location = new System.Drawing.Point(483, 47);
            this.dtpFecDoc.Name = "dtpFecDoc";
            this.dtpFecDoc.Size = new System.Drawing.Size(148, 20);
            this.dtpFecDoc.TabIndex = 3;
            // 
            // lblBase9
            // 
            this.lblBase9.AutoSize = true;
            this.lblBase9.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase9.ForeColor = System.Drawing.Color.Navy;
            this.lblBase9.Location = new System.Drawing.Point(316, 50);
            this.lblBase9.Name = "lblBase9";
            this.lblBase9.Size = new System.Drawing.Size(164, 13);
            this.lblBase9.TabIndex = 54;
            this.lblBase9.Text = "Fecha Documento Bloqueo:";
            // 
            // grbBase3
            // 
            this.grbBase3.Controls.Add(this.txtTotalBloq);
            this.grbBase3.Controls.Add(this.lblBase8);
            this.grbBase3.Location = new System.Drawing.Point(2, 439);
            this.grbBase3.Name = "grbBase3";
            this.grbBase3.Size = new System.Drawing.Size(742, 147);
            this.grbBase3.TabIndex = 53;
            this.grbBase3.TabStop = false;
            // 
            // txtTotalBloq
            // 
            this.txtTotalBloq.Enabled = false;
            this.txtTotalBloq.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalBloq.FormatoDecimal = false;
            this.txtTotalBloq.Location = new System.Drawing.Point(562, 123);
            this.txtTotalBloq.Name = "txtTotalBloq";
            this.txtTotalBloq.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtTotalBloq.nNumDecimales = 4;
            this.txtTotalBloq.nvalor = 0D;
            this.txtTotalBloq.Size = new System.Drawing.Size(106, 20);
            this.txtTotalBloq.TabIndex = 56;
            this.txtTotalBloq.Text = "0.00";
            this.txtTotalBloq.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(413, 125);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(145, 13);
            this.lblBase8.TabIndex = 55;
            this.lblBase8.Text = "Monto Total de Bloqueo:";
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAgregar.BackgroundImage")));
            this.btnAgregar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAgregar.Enabled = false;
            this.btnAgregar.Location = new System.Drawing.Point(678, 457);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(60, 50);
            this.btnAgregar.TabIndex = 5;
            this.btnAgregar.Text = "&Agregar";
            this.btnAgregar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar.BackgroundImage")));
            this.btnEditar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar.Enabled = false;
            this.btnEditar.Location = new System.Drawing.Point(487, 592);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(60, 50);
            this.btnEditar.TabIndex = 6;
            this.btnEditar.Text = "&Editar";
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(676, 592);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 9;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Enabled = false;
            this.btnGrabar.Location = new System.Drawing.Point(550, 592);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 7;
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
            this.btnCancelar.Location = new System.Drawing.Point(613, 592);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 8;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // conBusCtaAho
            // 
            this.conBusCtaAho.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.conBusCtaAho.Location = new System.Drawing.Point(1, 4);
            this.conBusCtaAho.Name = "conBusCtaAho";
            this.conBusCtaAho.Size = new System.Drawing.Size(654, 113);
            this.conBusCtaAho.TabIndex = 0;
            this.conBusCtaAho.ClicBusCta += new System.EventHandler(this.conBusCtaAho_ClicBusCta);
            // 
            // conBusCol
            // 
            this.conBusCol.Location = new System.Drawing.Point(218, 10);
            this.conBusCol.Name = "conBusCol";
            this.conBusCol.Size = new System.Drawing.Size(390, 86);
            this.conBusCol.TabIndex = 0;
            // 
            // grbBase4
            // 
            this.grbBase4.Controls.Add(this.rbtExterno);
            this.grbBase4.Controls.Add(this.rbtInterno);
            this.grbBase4.Location = new System.Drawing.Point(18, 8);
            this.grbBase4.Name = "grbBase4";
            this.grbBase4.Size = new System.Drawing.Size(159, 113);
            this.grbBase4.TabIndex = 56;
            this.grbBase4.TabStop = false;
            this.grbBase4.Text = "Solicitante del Bloqueo";
            // 
            // rbtExterno
            // 
            this.rbtExterno.AutoSize = true;
            this.rbtExterno.Enabled = false;
            this.rbtExterno.ForeColor = System.Drawing.Color.Navy;
            this.rbtExterno.Location = new System.Drawing.Point(26, 72);
            this.rbtExterno.Name = "rbtExterno";
            this.rbtExterno.Size = new System.Drawing.Size(61, 17);
            this.rbtExterno.TabIndex = 1;
            this.rbtExterno.Text = "Externo";
            this.rbtExterno.UseVisualStyleBackColor = true;
            this.rbtExterno.CheckedChanged += new System.EventHandler(this.rbtExterno_CheckedChanged);
            // 
            // rbtInterno
            // 
            this.rbtInterno.AutoSize = true;
            this.rbtInterno.Enabled = false;
            this.rbtInterno.ForeColor = System.Drawing.Color.Navy;
            this.rbtInterno.Location = new System.Drawing.Point(29, 28);
            this.rbtInterno.Name = "rbtInterno";
            this.rbtInterno.Size = new System.Drawing.Size(58, 17);
            this.rbtInterno.TabIndex = 0;
            this.rbtInterno.Text = "Interno";
            this.rbtInterno.UseVisualStyleBackColor = true;
            this.rbtInterno.CheckedChanged += new System.EventHandler(this.rbtInterno_CheckedChanged);
            // 
            // txtNombre
            // 
            this.txtNombre.Enabled = false;
            this.txtNombre.Location = new System.Drawing.Point(290, 102);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(431, 20);
            this.txtNombre.TabIndex = 1;
            // 
            // lblBase10
            // 
            this.lblBase10.AutoSize = true;
            this.lblBase10.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase10.ForeColor = System.Drawing.Color.Navy;
            this.lblBase10.Location = new System.Drawing.Point(216, 105);
            this.lblBase10.Name = "lblBase10";
            this.lblBase10.Size = new System.Drawing.Size(71, 13);
            this.lblBase10.TabIndex = 58;
            this.lblBase10.Text = "Solicitante:";
            // 
            // grbBase5
            // 
            this.grbBase5.Controls.Add(this.lblBase10);
            this.grbBase5.Controls.Add(this.conBusCol);
            this.grbBase5.Controls.Add(this.txtNombre);
            this.grbBase5.Controls.Add(this.grbBase4);
            this.grbBase5.Location = new System.Drawing.Point(2, 255);
            this.grbBase5.Name = "grbBase5";
            this.grbBase5.Size = new System.Drawing.Size(736, 128);
            this.grbBase5.TabIndex = 3;
            this.grbBase5.TabStop = false;
            // 
            // frmBloqCuenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(748, 666);
            this.Controls.Add(this.conBusCtaAho);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.txtObservacion);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.dtgBloqueosCta);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.grbBase2);
            this.Controls.Add(this.grbBase3);
            this.Controls.Add(this.grbBase5);
            this.Name = "frmBloqCuenta";
            this.Text = "Control de Bloqueo de Cuentas";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmBloqueoCuenta_FormClosed);
            this.Load += new System.EventHandler(this.frmBloqCuenta_Load);
            this.Controls.SetChildIndex(this.grbBase5, 0);
            this.Controls.SetChildIndex(this.grbBase3, 0);
            this.Controls.SetChildIndex(this.grbBase2, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.btnEditar, 0);
            this.Controls.SetChildIndex(this.btnAgregar, 0);
            this.Controls.SetChildIndex(this.dtgBloqueosCta, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.txtObservacion, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.Controls.SetChildIndex(this.conBusCtaAho, 0);
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgBloqueosCta)).EndInit();
            this.grbBase2.ResumeLayout(false);
            this.grbBase2.PerformLayout();
            this.grbBase3.ResumeLayout(false);
            this.grbBase3.PerformLayout();
            this.grbBase4.ResumeLayout(false);
            this.grbBase4.PerformLayout();
            this.grbBase5.ResumeLayout(false);
            this.grbBase5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.txtBase txtProducto;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.cboMoneda cboMoneda;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.txtBase txtMonto;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.txtBase txtObservacion;
        private GEN.BotonesBase.btnEditar btnEditar;
        private System.Windows.Forms.DataGridView dtgBloqueosCta;
        private GEN.BotonesBase.btnAgregar btnAgregar;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.txtNumRea txtMonBloq;
        private GEN.ControlesBase.cboTipoBloqueo cboTipoBloqueo;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.cboBase cboCaractBloq;
        private GEN.ControlesBase.grbBase grbBase2;
        private GEN.ControlesBase.grbBase grbBase3;
        private GEN.ControlesBase.conBusCtaAho conBusCtaAho;
        private GEN.ControlesBase.txtNumRea txtTotalBloq;
        private GEN.ControlesBase.lblBase lblBase8;
        private GEN.ControlesBase.lblBase lblBase9;
        public GEN.ControlesBase.dtpCorto dtpFecDoc;
        private GEN.ControlesBase.ConBusCol conBusCol;
        private GEN.ControlesBase.grbBase grbBase4;
        private GEN.ControlesBase.rbtBase rbtExterno;
        private GEN.ControlesBase.rbtBase rbtInterno;
        private GEN.ControlesBase.txtBase txtNombre;
        private GEN.ControlesBase.lblBase lblBase10;
        private GEN.ControlesBase.grbBase grbBase5;

    }
}