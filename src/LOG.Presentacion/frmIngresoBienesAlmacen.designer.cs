namespace LOG.Presentacion
{
    partial class frmIngresoBienesAlmacen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIngresoBienesAlmacen));
            this.btnNuevo = new GEN.BotonesBase.btnNuevo();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.grbDetalleActivos = new GEN.ControlesBase.grbBase(this.components);
            this.btnQuitDetActivos = new GEN.BotonesBase.btnMiniQuitar();
            this.btnAddDetActivos = new GEN.BotonesBase.btnMiniAgregar();
            this.dtgDetActivos = new GEN.ControlesBase.dtgBase(this.components);
            this.grbBienes = new GEN.ControlesBase.grbBase(this.components);
            this.txtIgv = new GEN.ControlesBase.txtNumRea(this.components);
            this.chcIgv = new GEN.ControlesBase.chcBase(this.components);
            this.txtSubTotal = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase14 = new GEN.ControlesBase.lblBase();
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.txtConvertido = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.txtTotalNE = new GEN.ControlesBase.txtNumRea(this.components);
            this.btnMiniQuitar = new GEN.BotonesBase.btnMiniQuitar();
            this.btnMiniAgregar = new GEN.BotonesBase.btnMiniAgregar();
            this.dtgDetalleNotaEntrada = new GEN.ControlesBase.dtgBase(this.components);
            this.grbBusca = new GEN.ControlesBase.grbBase(this.components);
            this.cboTipoIngresoNotEnt = new GEN.ControlesBase.cboTipoIngresoNotEnt(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.grbCpg = new GEN.ControlesBase.grbBase(this.components);
            this.dtpFechaCpg = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.txtTotalCpg = new GEN.ControlesBase.txtNumRea(this.components);
            this.txtTipCambio = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase12 = new GEN.ControlesBase.lblBase();
            this.cboMonedaCpg = new GEN.ControlesBase.cboMoneda(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.cboTipoComprobantePago = new GEN.ControlesBase.cboTipoComprobantePago(this.components);
            this.chcCajaChica = new GEN.ControlesBase.chcBase(this.components);
            this.btnBusCpg = new GEN.BotonesBase.btnMiniBusq(this.components);
            this.lblBase16 = new GEN.ControlesBase.lblBase();
            this.txtNumCpg = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase13 = new GEN.ControlesBase.lblBase();
            this.grbDatEntrada = new GEN.ControlesBase.grbBase(this.components);
            this.btnBusqOC = new GEN.BotonesBase.btnMiniBusq(this.components);
            this.txtNumOC = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.lblBase10 = new GEN.ControlesBase.lblBase();
            this.btnBusProveedor = new GEN.BotonesBase.btnMiniBusq(this.components);
            this.txtProveedor = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase9 = new GEN.ControlesBase.lblBase();
            this.cboAlmacen = new GEN.ControlesBase.cboAlmacen(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.cboAgencias = new GEN.ControlesBase.cboAgencias(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.btnParcialOC = new System.Windows.Forms.Button();
            this.grbDetalleActivos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDetActivos)).BeginInit();
            this.grbBienes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDetalleNotaEntrada)).BeginInit();
            this.grbBusca.SuspendLayout();
            this.grbCpg.SuspendLayout();
            this.grbDatEntrada.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo.BackgroundImage")));
            this.btnNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevo.Location = new System.Drawing.Point(604, 10);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(60, 50);
            this.btnNuevo.TabIndex = 57;
            this.btnNuevo.Text = "&Nuevo";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Enabled = false;
            this.btnCancelar.Location = new System.Drawing.Point(542, 614);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 60;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Enabled = false;
            this.btnGrabar.Location = new System.Drawing.Point(480, 614);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 59;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(621, 614);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 56;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // grbDetalleActivos
            // 
            this.grbDetalleActivos.Controls.Add(this.btnQuitDetActivos);
            this.grbDetalleActivos.Controls.Add(this.btnAddDetActivos);
            this.grbDetalleActivos.Controls.Add(this.dtgDetActivos);
            this.grbDetalleActivos.Location = new System.Drawing.Point(8, 463);
            this.grbDetalleActivos.Name = "grbDetalleActivos";
            this.grbDetalleActivos.Size = new System.Drawing.Size(673, 150);
            this.grbDetalleActivos.TabIndex = 64;
            this.grbDetalleActivos.TabStop = false;
            this.grbDetalleActivos.Text = "Detalle de Activos";
            // 
            // btnQuitDetActivos
            // 
            this.btnQuitDetActivos.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnQuitDetActivos.BackgroundImage")));
            this.btnQuitDetActivos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnQuitDetActivos.Location = new System.Drawing.Point(628, 57);
            this.btnQuitDetActivos.Name = "btnQuitDetActivos";
            this.btnQuitDetActivos.Size = new System.Drawing.Size(36, 28);
            this.btnQuitDetActivos.TabIndex = 2;
            this.btnQuitDetActivos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnQuitDetActivos.UseVisualStyleBackColor = true;
            this.btnQuitDetActivos.Click += new System.EventHandler(this.btnQuitDetActivos_Click);
            // 
            // btnAddDetActivos
            // 
            this.btnAddDetActivos.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAddDetActivos.BackgroundImage")));
            this.btnAddDetActivos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAddDetActivos.Location = new System.Drawing.Point(628, 23);
            this.btnAddDetActivos.Name = "btnAddDetActivos";
            this.btnAddDetActivos.Size = new System.Drawing.Size(36, 28);
            this.btnAddDetActivos.TabIndex = 1;
            this.btnAddDetActivos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAddDetActivos.UseVisualStyleBackColor = true;
            this.btnAddDetActivos.Click += new System.EventHandler(this.btnAddDetActivos_Click);
            // 
            // dtgDetActivos
            // 
            this.dtgDetActivos.AllowUserToAddRows = false;
            this.dtgDetActivos.AllowUserToDeleteRows = false;
            this.dtgDetActivos.AllowUserToResizeColumns = false;
            this.dtgDetActivos.AllowUserToResizeRows = false;
            this.dtgDetActivos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgDetActivos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDetActivos.Location = new System.Drawing.Point(6, 23);
            this.dtgDetActivos.MultiSelect = false;
            this.dtgDetActivos.Name = "dtgDetActivos";
            this.dtgDetActivos.ReadOnly = true;
            this.dtgDetActivos.RowHeadersVisible = false;
            this.dtgDetActivos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgDetActivos.Size = new System.Drawing.Size(616, 120);
            this.dtgDetActivos.TabIndex = 0;
            // 
            // grbBienes
            // 
            this.grbBienes.Controls.Add(this.txtIgv);
            this.grbBienes.Controls.Add(this.chcIgv);
            this.grbBienes.Controls.Add(this.txtSubTotal);
            this.grbBienes.Controls.Add(this.lblBase14);
            this.grbBienes.Controls.Add(this.lblBase6);
            this.grbBienes.Controls.Add(this.txtConvertido);
            this.grbBienes.Controls.Add(this.lblBase5);
            this.grbBienes.Controls.Add(this.txtTotalNE);
            this.grbBienes.Controls.Add(this.btnMiniQuitar);
            this.grbBienes.Controls.Add(this.btnMiniAgregar);
            this.grbBienes.Controls.Add(this.dtgDetalleNotaEntrada);
            this.grbBienes.Location = new System.Drawing.Point(8, 225);
            this.grbBienes.Name = "grbBienes";
            this.grbBienes.Size = new System.Drawing.Size(673, 232);
            this.grbBienes.TabIndex = 63;
            this.grbBienes.TabStop = false;
            this.grbBienes.Text = "Bienes por Ingresar";
            // 
            // txtIgv
            // 
            this.txtIgv.Enabled = false;
            this.txtIgv.FormatoDecimal = true;
            this.txtIgv.Location = new System.Drawing.Point(507, 163);
            this.txtIgv.Name = "txtIgv";
            this.txtIgv.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtIgv.nNumDecimales = 2;
            this.txtIgv.nvalor = 0D;
            this.txtIgv.Size = new System.Drawing.Size(122, 20);
            this.txtIgv.TabIndex = 14;
            this.txtIgv.Text = "0.00";
            this.txtIgv.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // chcIgv
            // 
            this.chcIgv.AutoSize = true;
            this.chcIgv.Enabled = false;
            this.chcIgv.ForeColor = System.Drawing.Color.Navy;
            this.chcIgv.Location = new System.Drawing.Point(399, 165);
            this.chcIgv.Name = "chcIgv";
            this.chcIgv.Size = new System.Drawing.Size(101, 17);
            this.chcIgv.TabIndex = 13;
            this.chcIgv.Text = "Incluir  IGV 18%";
            this.chcIgv.UseVisualStyleBackColor = true;
            this.chcIgv.CheckedChanged += new System.EventHandler(this.chcIgv_CheckedChanged);
            // 
            // txtSubTotal
            // 
            this.txtSubTotal.Enabled = false;
            this.txtSubTotal.FormatoDecimal = true;
            this.txtSubTotal.Location = new System.Drawing.Point(507, 140);
            this.txtSubTotal.Name = "txtSubTotal";
            this.txtSubTotal.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtSubTotal.nNumDecimales = 2;
            this.txtSubTotal.nvalor = 0D;
            this.txtSubTotal.Size = new System.Drawing.Size(122, 20);
            this.txtSubTotal.TabIndex = 12;
            this.txtSubTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblBase14
            // 
            this.lblBase14.AutoSize = true;
            this.lblBase14.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase14.ForeColor = System.Drawing.Color.Navy;
            this.lblBase14.Location = new System.Drawing.Point(438, 143);
            this.lblBase14.Name = "lblBase14";
            this.lblBase14.Size = new System.Drawing.Size(65, 13);
            this.lblBase14.TabIndex = 11;
            this.lblBase14.Text = "Sub Total:";
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(401, 210);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(106, 13);
            this.lblBase6.TabIndex = 10;
            this.lblBase6.Text = "Total Convertido:";
            // 
            // txtConvertido
            // 
            this.txtConvertido.Enabled = false;
            this.txtConvertido.FormatoDecimal = false;
            this.txtConvertido.Location = new System.Drawing.Point(507, 207);
            this.txtConvertido.Name = "txtConvertido";
            this.txtConvertido.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtConvertido.nNumDecimales = 4;
            this.txtConvertido.nvalor = 0D;
            this.txtConvertido.Size = new System.Drawing.Size(122, 20);
            this.txtConvertido.TabIndex = 9;
            this.txtConvertido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(468, 188);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(39, 13);
            this.lblBase5.TabIndex = 8;
            this.lblBase5.Text = "Total:";
            // 
            // txtTotalNE
            // 
            this.txtTotalNE.Enabled = false;
            this.txtTotalNE.FormatoDecimal = false;
            this.txtTotalNE.Location = new System.Drawing.Point(507, 185);
            this.txtTotalNE.Name = "txtTotalNE";
            this.txtTotalNE.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTotalNE.nNumDecimales = 4;
            this.txtTotalNE.nvalor = 0D;
            this.txtTotalNE.Size = new System.Drawing.Size(122, 20);
            this.txtTotalNE.TabIndex = 7;
            this.txtTotalNE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnMiniQuitar
            // 
            this.btnMiniQuitar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniQuitar.BackgroundImage")));
            this.btnMiniQuitar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniQuitar.Location = new System.Drawing.Point(628, 52);
            this.btnMiniQuitar.Name = "btnMiniQuitar";
            this.btnMiniQuitar.Size = new System.Drawing.Size(36, 28);
            this.btnMiniQuitar.TabIndex = 5;
            this.btnMiniQuitar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniQuitar.UseVisualStyleBackColor = true;
            this.btnMiniQuitar.Click += new System.EventHandler(this.btnMiniQuitar_Click);
            // 
            // btnMiniAgregar
            // 
            this.btnMiniAgregar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniAgregar.BackgroundImage")));
            this.btnMiniAgregar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniAgregar.Location = new System.Drawing.Point(628, 18);
            this.btnMiniAgregar.Name = "btnMiniAgregar";
            this.btnMiniAgregar.Size = new System.Drawing.Size(36, 28);
            this.btnMiniAgregar.TabIndex = 4;
            this.btnMiniAgregar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniAgregar.UseVisualStyleBackColor = true;
            this.btnMiniAgregar.Click += new System.EventHandler(this.btnMiniAgregar_Click);
            // 
            // dtgDetalleNotaEntrada
            // 
            this.dtgDetalleNotaEntrada.AllowUserToAddRows = false;
            this.dtgDetalleNotaEntrada.AllowUserToDeleteRows = false;
            this.dtgDetalleNotaEntrada.AllowUserToResizeColumns = false;
            this.dtgDetalleNotaEntrada.AllowUserToResizeRows = false;
            this.dtgDetalleNotaEntrada.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgDetalleNotaEntrada.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDetalleNotaEntrada.Location = new System.Drawing.Point(14, 18);
            this.dtgDetalleNotaEntrada.MultiSelect = false;
            this.dtgDetalleNotaEntrada.Name = "dtgDetalleNotaEntrada";
            this.dtgDetalleNotaEntrada.ReadOnly = true;
            this.dtgDetalleNotaEntrada.RowHeadersVisible = false;
            this.dtgDetalleNotaEntrada.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dtgDetalleNotaEntrada.Size = new System.Drawing.Size(608, 120);
            this.dtgDetalleNotaEntrada.TabIndex = 1;
            this.dtgDetalleNotaEntrada.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dtgDetalleNotaEntrada_CellValidating);
            this.dtgDetalleNotaEntrada.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgDetalleNotaEntrada_CellValueChanged);
            this.dtgDetalleNotaEntrada.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtgDetalleNotaEntrada_EditingControlShowing);
            this.dtgDetalleNotaEntrada.SelectionChanged += new System.EventHandler(this.dtgDetalleNotaEntrada_SelectionChanged);
            // 
            // grbBusca
            // 
            this.grbBusca.Controls.Add(this.cboTipoIngresoNotEnt);
            this.grbBusca.Controls.Add(this.lblBase1);
            this.grbBusca.Controls.Add(this.btnNuevo);
            this.grbBusca.Location = new System.Drawing.Point(8, 1);
            this.grbBusca.Name = "grbBusca";
            this.grbBusca.Size = new System.Drawing.Size(673, 62);
            this.grbBusca.TabIndex = 61;
            this.grbBusca.TabStop = false;
            this.grbBusca.Text = "Búsqueda";
            // 
            // cboTipoIngresoNotEnt
            // 
            this.cboTipoIngresoNotEnt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoIngresoNotEnt.FormattingEnabled = true;
            this.cboTipoIngresoNotEnt.Location = new System.Drawing.Point(256, 23);
            this.cboTipoIngresoNotEnt.Name = "cboTipoIngresoNotEnt";
            this.cboTipoIngresoNotEnt.Size = new System.Drawing.Size(332, 21);
            this.cboTipoIngresoNotEnt.TabIndex = 2;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(85, 26);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(165, 13);
            this.lblBase1.TabIndex = 11;
            this.lblBase1.Text = "Tipo de Ingreso a almacén:";
            // 
            // grbCpg
            // 
            this.grbCpg.Controls.Add(this.dtpFechaCpg);
            this.grbCpg.Controls.Add(this.lblBase8);
            this.grbCpg.Controls.Add(this.lblBase7);
            this.grbCpg.Controls.Add(this.txtTotalCpg);
            this.grbCpg.Controls.Add(this.txtTipCambio);
            this.grbCpg.Controls.Add(this.lblBase12);
            this.grbCpg.Controls.Add(this.cboMonedaCpg);
            this.grbCpg.Controls.Add(this.lblBase3);
            this.grbCpg.Controls.Add(this.cboTipoComprobantePago);
            this.grbCpg.Controls.Add(this.chcCajaChica);
            this.grbCpg.Controls.Add(this.btnBusCpg);
            this.grbCpg.Controls.Add(this.lblBase16);
            this.grbCpg.Controls.Add(this.txtNumCpg);
            this.grbCpg.Controls.Add(this.lblBase13);
            this.grbCpg.Location = new System.Drawing.Point(8, 131);
            this.grbCpg.Name = "grbCpg";
            this.grbCpg.Size = new System.Drawing.Size(673, 93);
            this.grbCpg.TabIndex = 66;
            this.grbCpg.TabStop = false;
            this.grbCpg.Text = "Comprobante de Pago";
            // 
            // dtpFechaCpg
            // 
            this.dtpFechaCpg.Enabled = false;
            this.dtpFechaCpg.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaCpg.Location = new System.Drawing.Point(90, 64);
            this.dtpFechaCpg.Name = "dtpFechaCpg";
            this.dtpFechaCpg.Size = new System.Drawing.Size(117, 20);
            this.dtpFechaCpg.TabIndex = 45;
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(13, 67);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(45, 13);
            this.lblBase8.TabIndex = 44;
            this.lblBase8.Text = "Fecha:";
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(375, 67);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(121, 13);
            this.lblBase7.TabIndex = 42;
            this.lblBase7.Text = "Total Comprobante:";
            // 
            // txtTotalCpg
            // 
            this.txtTotalCpg.Enabled = false;
            this.txtTotalCpg.FormatoDecimal = false;
            this.txtTotalCpg.Location = new System.Drawing.Point(496, 64);
            this.txtTotalCpg.Name = "txtTotalCpg";
            this.txtTotalCpg.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTotalCpg.nNumDecimales = 4;
            this.txtTotalCpg.nvalor = 0D;
            this.txtTotalCpg.Size = new System.Drawing.Size(113, 20);
            this.txtTotalCpg.TabIndex = 41;
            // 
            // txtTipCambio
            // 
            this.txtTipCambio.Enabled = false;
            this.txtTipCambio.FormatoDecimal = false;
            this.txtTipCambio.Location = new System.Drawing.Point(496, 40);
            this.txtTipCambio.Name = "txtTipCambio";
            this.txtTipCambio.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTipCambio.nNumDecimales = 4;
            this.txtTipCambio.nvalor = 0D;
            this.txtTipCambio.Size = new System.Drawing.Size(74, 20);
            this.txtTipCambio.TabIndex = 40;
            // 
            // lblBase12
            // 
            this.lblBase12.AutoSize = true;
            this.lblBase12.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase12.ForeColor = System.Drawing.Color.Navy;
            this.lblBase12.Location = new System.Drawing.Point(375, 43);
            this.lblBase12.Name = "lblBase12";
            this.lblBase12.Size = new System.Drawing.Size(84, 13);
            this.lblBase12.TabIndex = 39;
            this.lblBase12.Text = "Tipo Cambio:";
            // 
            // cboMonedaCpg
            // 
            this.cboMonedaCpg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMonedaCpg.Enabled = false;
            this.cboMonedaCpg.FormattingEnabled = true;
            this.cboMonedaCpg.Location = new System.Drawing.Point(497, 15);
            this.cboMonedaCpg.Name = "cboMonedaCpg";
            this.cboMonedaCpg.Size = new System.Drawing.Size(168, 21);
            this.cboMonedaCpg.TabIndex = 38;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(376, 19);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(56, 13);
            this.lblBase3.TabIndex = 37;
            this.lblBase3.Text = "Moneda:";
            // 
            // cboTipoComprobantePago
            // 
            this.cboTipoComprobantePago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoComprobantePago.Enabled = false;
            this.cboTipoComprobantePago.FormattingEnabled = true;
            this.cboTipoComprobantePago.Location = new System.Drawing.Point(90, 40);
            this.cboTipoComprobantePago.Name = "cboTipoComprobantePago";
            this.cboTipoComprobantePago.Size = new System.Drawing.Size(228, 21);
            this.cboTipoComprobantePago.TabIndex = 36;
            // 
            // chcCajaChica
            // 
            this.chcCajaChica.AutoSize = true;
            this.chcCajaChica.Location = new System.Drawing.Point(253, 17);
            this.chcCajaChica.Name = "chcCajaChica";
            this.chcCajaChica.Size = new System.Drawing.Size(83, 17);
            this.chcCajaChica.TabIndex = 35;
            this.chcCajaChica.Text = "Caja Chica?";
            this.chcCajaChica.UseVisualStyleBackColor = true;
            // 
            // btnBusCpg
            // 
            this.btnBusCpg.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBusCpg.BackgroundImage")));
            this.btnBusCpg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBusCpg.Location = new System.Drawing.Point(212, 11);
            this.btnBusCpg.Name = "btnBusCpg";
            this.btnBusCpg.Size = new System.Drawing.Size(36, 28);
            this.btnBusCpg.TabIndex = 34;
            this.btnBusCpg.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBusCpg.UseVisualStyleBackColor = true;
            this.btnBusCpg.Click += new System.EventHandler(this.btnBusCpg_Click);
            // 
            // lblBase16
            // 
            this.lblBase16.AutoSize = true;
            this.lblBase16.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase16.ForeColor = System.Drawing.Color.Navy;
            this.lblBase16.Location = new System.Drawing.Point(13, 44);
            this.lblBase16.Name = "lblBase16";
            this.lblBase16.Size = new System.Drawing.Size(81, 13);
            this.lblBase16.TabIndex = 2;
            this.lblBase16.Text = "Tipo de Cpg:";
            // 
            // txtNumCpg
            // 
            this.txtNumCpg.Enabled = false;
            this.txtNumCpg.Location = new System.Drawing.Point(90, 15);
            this.txtNumCpg.Name = "txtNumCpg";
            this.txtNumCpg.Size = new System.Drawing.Size(117, 20);
            this.txtNumCpg.TabIndex = 1;
            // 
            // lblBase13
            // 
            this.lblBase13.AutoSize = true;
            this.lblBase13.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase13.ForeColor = System.Drawing.Color.Navy;
            this.lblBase13.Location = new System.Drawing.Point(13, 19);
            this.lblBase13.Name = "lblBase13";
            this.lblBase13.Size = new System.Drawing.Size(57, 13);
            this.lblBase13.TabIndex = 0;
            this.lblBase13.Text = "Numero:";
            // 
            // grbDatEntrada
            // 
            this.grbDatEntrada.Controls.Add(this.btnParcialOC);
            this.grbDatEntrada.Controls.Add(this.btnBusqOC);
            this.grbDatEntrada.Controls.Add(this.txtNumOC);
            this.grbDatEntrada.Controls.Add(this.lblBase10);
            this.grbDatEntrada.Controls.Add(this.btnBusProveedor);
            this.grbDatEntrada.Controls.Add(this.txtProveedor);
            this.grbDatEntrada.Controls.Add(this.lblBase9);
            this.grbDatEntrada.Controls.Add(this.cboAlmacen);
            this.grbDatEntrada.Controls.Add(this.lblBase2);
            this.grbDatEntrada.Controls.Add(this.cboAgencias);
            this.grbDatEntrada.Controls.Add(this.lblBase4);
            this.grbDatEntrada.Location = new System.Drawing.Point(8, 65);
            this.grbDatEntrada.Name = "grbDatEntrada";
            this.grbDatEntrada.Size = new System.Drawing.Size(673, 64);
            this.grbDatEntrada.TabIndex = 65;
            this.grbDatEntrada.TabStop = false;
            // 
            // btnBusqOC
            // 
            this.btnBusqOC.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBusqOC.BackgroundImage")));
            this.btnBusqOC.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBusqOC.Location = new System.Drawing.Point(566, 34);
            this.btnBusqOC.Name = "btnBusqOC";
            this.btnBusqOC.Size = new System.Drawing.Size(36, 28);
            this.btnBusqOC.TabIndex = 39;
            this.btnBusqOC.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBusqOC.UseVisualStyleBackColor = true;
            this.btnBusqOC.Click += new System.EventHandler(this.btnBusqOC_Click);
            // 
            // txtNumOC
            // 
            this.txtNumOC.Location = new System.Drawing.Point(445, 38);
            this.txtNumOC.MaxLength = 9;
            this.txtNumOC.Name = "txtNumOC";
            this.txtNumOC.Size = new System.Drawing.Size(115, 20);
            this.txtNumOC.TabIndex = 37;
            this.txtNumOC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumOC_KeyPress);
            // 
            // lblBase10
            // 
            this.lblBase10.AutoSize = true;
            this.lblBase10.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase10.ForeColor = System.Drawing.Color.Navy;
            this.lblBase10.Location = new System.Drawing.Point(376, 42);
            this.lblBase10.Name = "lblBase10";
            this.lblBase10.Size = new System.Drawing.Size(72, 13);
            this.lblBase10.TabIndex = 38;
            this.lblBase10.Text = "Nro de OC:";
            // 
            // btnBusProveedor
            // 
            this.btnBusProveedor.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBusProveedor.BackgroundImage")));
            this.btnBusProveedor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBusProveedor.Location = new System.Drawing.Point(294, 34);
            this.btnBusProveedor.Name = "btnBusProveedor";
            this.btnBusProveedor.Size = new System.Drawing.Size(36, 28);
            this.btnBusProveedor.TabIndex = 36;
            this.btnBusProveedor.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBusProveedor.UseVisualStyleBackColor = true;
            this.btnBusProveedor.Click += new System.EventHandler(this.btnBusProveedor_Click);
            // 
            // txtProveedor
            // 
            this.txtProveedor.Enabled = false;
            this.txtProveedor.Location = new System.Drawing.Point(73, 38);
            this.txtProveedor.Name = "txtProveedor";
            this.txtProveedor.Size = new System.Drawing.Size(215, 20);
            this.txtProveedor.TabIndex = 35;
            // 
            // lblBase9
            // 
            this.lblBase9.AutoSize = true;
            this.lblBase9.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase9.ForeColor = System.Drawing.Color.Navy;
            this.lblBase9.Location = new System.Drawing.Point(5, 42);
            this.lblBase9.Name = "lblBase9";
            this.lblBase9.Size = new System.Drawing.Size(71, 13);
            this.lblBase9.TabIndex = 34;
            this.lblBase9.Text = "Proveedor:";
            // 
            // cboAlmacen
            // 
            this.cboAlmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAlmacen.FormattingEnabled = true;
            this.cboAlmacen.Location = new System.Drawing.Point(445, 11);
            this.cboAlmacen.Name = "cboAlmacen";
            this.cboAlmacen.Size = new System.Drawing.Size(219, 21);
            this.cboAlmacen.TabIndex = 3;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(376, 15);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(61, 13);
            this.lblBase2.TabIndex = 2;
            this.lblBase2.Text = "Almacén:";
            // 
            // cboAgencias
            // 
            this.cboAgencias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAgencias.FormattingEnabled = true;
            this.cboAgencias.Location = new System.Drawing.Point(73, 11);
            this.cboAgencias.Name = "cboAgencias";
            this.cboAgencias.Size = new System.Drawing.Size(215, 21);
            this.cboAgencias.TabIndex = 1;
            this.cboAgencias.SelectedIndexChanged += new System.EventHandler(this.cboAgencia_SelectedIndexChanged);
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(5, 15);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(57, 13);
            this.lblBase4.TabIndex = 0;
            this.lblBase4.Text = "Agencia:";
            // 
            // btnParcialOC
            // 
            this.btnParcialOC.Location = new System.Drawing.Point(604, 34);
            this.btnParcialOC.Name = "btnParcialOC";
            this.btnParcialOC.Size = new System.Drawing.Size(60, 28);
            this.btnParcialOC.TabIndex = 40;
            this.btnParcialOC.Text = "Parcial";
            this.btnParcialOC.UseVisualStyleBackColor = true;
            this.btnParcialOC.Click += new System.EventHandler(this.btnParcialOC_Click);
            // 
            // frmIngresoBienesAlmacen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 688);
            this.Controls.Add(this.grbCpg);
            this.Controls.Add(this.grbDatEntrada);
            this.Controls.Add(this.grbDetalleActivos);
            this.Controls.Add(this.grbBienes);
            this.Controls.Add(this.grbBusca);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.btnSalir1);
            this.Name = "frmIngresoBienesAlmacen";
            this.Text = "Ingreso de bienes a almacén";
            this.Load += new System.EventHandler(this.Form_Load);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.grbBusca, 0);
            this.Controls.SetChildIndex(this.grbBienes, 0);
            this.Controls.SetChildIndex(this.grbDetalleActivos, 0);
            this.Controls.SetChildIndex(this.grbDatEntrada, 0);
            this.Controls.SetChildIndex(this.grbCpg, 0);
            this.grbDetalleActivos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgDetActivos)).EndInit();
            this.grbBienes.ResumeLayout(false);
            this.grbBienes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDetalleNotaEntrada)).EndInit();
            this.grbBusca.ResumeLayout(false);
            this.grbBusca.PerformLayout();
            this.grbCpg.ResumeLayout(false);
            this.grbCpg.PerformLayout();
            this.grbDatEntrada.ResumeLayout(false);
            this.grbDatEntrada.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnNuevo btnNuevo;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.ControlesBase.grbBase grbDetalleActivos;
        private GEN.BotonesBase.btnMiniQuitar btnQuitDetActivos;
        private GEN.BotonesBase.btnMiniAgregar btnAddDetActivos;
        private GEN.ControlesBase.dtgBase dtgDetActivos;
        private GEN.ControlesBase.grbBase grbBienes;
        private GEN.ControlesBase.dtgBase dtgDetalleNotaEntrada;
        private GEN.ControlesBase.grbBase grbBusca;
        private GEN.ControlesBase.cboTipoIngresoNotEnt cboTipoIngresoNotEnt;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.grbBase grbCpg;
        private GEN.ControlesBase.txtNumRea txtTipCambio;
        private GEN.ControlesBase.lblBase lblBase12;
        private GEN.ControlesBase.cboMoneda cboMonedaCpg;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.cboTipoComprobantePago cboTipoComprobantePago;
        private GEN.ControlesBase.chcBase chcCajaChica;
        private GEN.BotonesBase.btnMiniBusq btnBusCpg;
        private GEN.ControlesBase.lblBase lblBase16;
        private GEN.ControlesBase.txtBase txtNumCpg;
        private GEN.ControlesBase.lblBase lblBase13;
        private GEN.ControlesBase.grbBase grbDatEntrada;
        private GEN.ControlesBase.cboAlmacen cboAlmacen;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.cboAgencias cboAgencias;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.BotonesBase.btnMiniQuitar btnMiniQuitar;
        private GEN.BotonesBase.btnMiniAgregar btnMiniAgregar;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.txtNumRea txtConvertido;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.txtNumRea txtTotalNE;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.txtNumRea txtTotalCpg;
        private GEN.ControlesBase.dtpCorto dtpFechaCpg;
        private GEN.ControlesBase.lblBase lblBase8;
        private GEN.BotonesBase.btnMiniBusq btnBusProveedor;
        private GEN.ControlesBase.txtBase txtProveedor;
        private GEN.ControlesBase.lblBase lblBase9;
        private GEN.BotonesBase.btnMiniBusq btnBusqOC;
        private GEN.ControlesBase.txtCBNumerosEnteros txtNumOC;
        private GEN.ControlesBase.lblBase lblBase10;
        private GEN.ControlesBase.txtNumRea txtIgv;
        private GEN.ControlesBase.chcBase chcIgv;
        private GEN.ControlesBase.txtNumRea txtSubTotal;
        private GEN.ControlesBase.lblBase lblBase14;
        private System.Windows.Forms.Button btnParcialOC;

    }
}

