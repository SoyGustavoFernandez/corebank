namespace CAJ.Presentacion
{
    partial class frmRegistroComprobantes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegistroComprobantes));
            this.lblTipoComprobante = new GEN.ControlesBase.lblBase();
            this.lblSerie = new GEN.ControlesBase.lblBase();
            this.lblCodigo = new GEN.ControlesBase.lblBase();
            this.lblFechaEmision = new GEN.ControlesBase.lblBase();
            this.lblFechaPago = new GEN.ControlesBase.lblBase();
            this.dtpFechaEmision = new GEN.ControlesBase.dtpCorto(this.components);
            this.dtpFechaPago = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblMoneda = new GEN.ControlesBase.lblBase();
            this.conBusCliente = new GEN.ControlesBase.ConBusCliRuc();
            this.txtTotal = new GEN.ControlesBase.txtNumRea(this.components);
            this.txtIGV = new GEN.ControlesBase.txtNumRea(this.components);
            this.grbDetalleCompr = new GEN.ControlesBase.grbBase(this.components);
            this.txtTot4taCateg = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.txtNetoPagar = new GEN.ControlesBase.txtNumRea(this.components);
            this.txtDescuentos = new GEN.ControlesBase.txtNumRea(this.components);
            this.txtTotPag = new GEN.ControlesBase.txtNumRea(this.components);
            this.txtTotOtros = new GEN.ControlesBase.txtNumRea(this.components);
            this.dtgDetalleComprobante = new GEN.ControlesBase.dtgBase(this.components);
            this.btnQuitarDetalle = new GEN.BotonesBase.btnMiniQuitar();
            this.btnAgregarDetalle = new GEN.BotonesBase.btnMiniAgregar();
            this.txtValorCompra = new GEN.ControlesBase.txtNumRea(this.components);
            this.txtDetraccion = new GEN.ControlesBase.txtNumRea(this.components);
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.dtgOtrosDesctosCpg = new GEN.ControlesBase.dtgBase(this.components);
            this.lblFechaProvision = new GEN.ControlesBase.lblBase();
            this.dtpFechaProvision = new GEN.ControlesBase.dtpCorto(this.components);
            this.grbDatosCompr = new GEN.ControlesBase.grbBase(this.components);
            this.lblFecVenc = new GEN.ControlesBase.lblBase();
            this.dtpFecVenc = new GEN.ControlesBase.dtpCorto(this.components);
            this.txtSerie = new GEN.ControlesBase.txtCBLetra(this.components);
            this.txtCambio = new GEN.ControlesBase.txtNumRea(this.components);
            this.txtNumero = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.lblCambio = new GEN.ControlesBase.lblBase();
            this.cboMoneda = new GEN.ControlesBase.cboMoneda(this.components);
            this.cboTipoComprobantePago = new GEN.ControlesBase.cboTipoComprobantePago(this.components);
            this.lblNumero = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.txtCodigo = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.cboTipoPago = new GEN.ControlesBase.cboBase(this.components);
            this.lblTipoPago = new GEN.ControlesBase.lblBase();
            this.lblTipoOperacion = new GEN.ControlesBase.lblBase();
            this.lblPorcDetraccion = new GEN.ControlesBase.lblBase();
            this.txtPorcDetraccion = new GEN.ControlesBase.txtNumRea(this.components);
            this.grbDetraccion = new GEN.ControlesBase.grbBase(this.components);
            this.txtCIIU = new GEN.ControlesBase.txtBase(this.components);
            this.cboTipoOperacion = new GEN.ControlesBase.cboBase(this.components);
            this.rbtnSinDetraccion = new GEN.ControlesBase.rbtnBase(this.components);
            this.rbtnConDetraccion = new GEN.ControlesBase.rbtnBase(this.components);
            this.lblCIIU = new GEN.ControlesBase.lblBase();
            this.cboBienServicio = new GEN.ControlesBase.cboBase(this.components);
            this.lblBienServicio = new GEN.ControlesBase.lblBase();
            this.grbPago = new GEN.ControlesBase.grbBase(this.components);
            this.chcProvisionar = new GEN.ControlesBase.chcBase(this.components);
            this.grbIgv = new GEN.ControlesBase.grbBase(this.components);
            this.txtIgvCalculo = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblIgvCalculo = new GEN.ControlesBase.lblBase();
            this.cboDestino = new GEN.ControlesBase.cboBase(this.components);
            this.lblDestino = new GEN.ControlesBase.lblBase();
            this.lblGlosa = new GEN.ControlesBase.lblBase();
            this.txtGlosa = new GEN.ControlesBase.txtBase(this.components);
            this.grbDatCompr = new GEN.ControlesBase.grbBase(this.components);
            this.chcImpRenta = new GEN.ControlesBase.chcBase(this.components);
            this.chcCuartaCateg = new GEN.ControlesBase.chcBase(this.components);
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.btnEditar = new GEN.BotonesBase.btnEditar();
            this.btnNuevo = new GEN.BotonesBase.btnNuevo();
            this.btnAnular = new GEN.BotonesBase.btnAnular();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.cboCajaChica = new GEN.ControlesBase.cboBase(this.components);
            this.cboAgencias1 = new GEN.ControlesBase.cboAgencias(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.txtNroCajChica = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.grbBase3 = new GEN.ControlesBase.grbBase(this.components);
            this.btnBusqCodRef = new GEN.BotonesBase.btnMiniBusq(this.components);
            this.txtCodRef = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.lblCodRef = new GEN.ControlesBase.lblBase();
            this.btnBuscar = new GEN.BotonesBase.btnMiniBusq(this.components);
            this.btnImprimir1 = new GEN.BotonesBase.btnImprimir();
            this.grbDetalleCompr.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDetalleComprobante)).BeginInit();
            this.grbBase2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgOtrosDesctosCpg)).BeginInit();
            this.grbDatosCompr.SuspendLayout();
            this.grbDetraccion.SuspendLayout();
            this.grbPago.SuspendLayout();
            this.grbIgv.SuspendLayout();
            this.grbDatCompr.SuspendLayout();
            this.grbBase1.SuspendLayout();
            this.grbBase3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTipoComprobante
            // 
            this.lblTipoComprobante.AutoSize = true;
            this.lblTipoComprobante.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblTipoComprobante.ForeColor = System.Drawing.Color.Navy;
            this.lblTipoComprobante.Location = new System.Drawing.Point(10, 16);
            this.lblTipoComprobante.Name = "lblTipoComprobante";
            this.lblTipoComprobante.Size = new System.Drawing.Size(118, 13);
            this.lblTipoComprobante.TabIndex = 0;
            this.lblTipoComprobante.Text = "Tipo Comprobante:";
            // 
            // lblSerie
            // 
            this.lblSerie.AutoSize = true;
            this.lblSerie.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblSerie.ForeColor = System.Drawing.Color.Navy;
            this.lblSerie.Location = new System.Drawing.Point(424, 16);
            this.lblSerie.Name = "lblSerie";
            this.lblSerie.Size = new System.Drawing.Size(42, 13);
            this.lblSerie.TabIndex = 8;
            this.lblSerie.Text = "Serie:";
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblCodigo.ForeColor = System.Drawing.Color.Navy;
            this.lblCodigo.Location = new System.Drawing.Point(6, 24);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(52, 13);
            this.lblCodigo.TabIndex = 13;
            this.lblCodigo.Text = "Código:";
            // 
            // lblFechaEmision
            // 
            this.lblFechaEmision.AutoSize = true;
            this.lblFechaEmision.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblFechaEmision.ForeColor = System.Drawing.Color.Navy;
            this.lblFechaEmision.Location = new System.Drawing.Point(10, 42);
            this.lblFechaEmision.Name = "lblFechaEmision";
            this.lblFechaEmision.Size = new System.Drawing.Size(93, 13);
            this.lblFechaEmision.TabIndex = 2;
            this.lblFechaEmision.Text = "Fecha Emisión:";
            // 
            // lblFechaPago
            // 
            this.lblFechaPago.AutoSize = true;
            this.lblFechaPago.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblFechaPago.ForeColor = System.Drawing.Color.Navy;
            this.lblFechaPago.Location = new System.Drawing.Point(218, 17);
            this.lblFechaPago.Name = "lblFechaPago";
            this.lblFechaPago.Size = new System.Drawing.Size(77, 13);
            this.lblFechaPago.TabIndex = 10;
            this.lblFechaPago.Text = "Fecha Pago:";
            // 
            // dtpFechaEmision
            // 
            this.dtpFechaEmision.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaEmision.Location = new System.Drawing.Point(127, 38);
            this.dtpFechaEmision.Name = "dtpFechaEmision";
            this.dtpFechaEmision.Size = new System.Drawing.Size(119, 20);
            this.dtpFechaEmision.TabIndex = 4;
            this.dtpFechaEmision.ValueChanged += new System.EventHandler(this.dtpFechaEmision_ValueChanged);
            this.dtpFechaEmision.Leave += new System.EventHandler(this.dtpFechaEmision_Leave);
            // 
            // dtpFechaPago
            // 
            this.dtpFechaPago.Enabled = false;
            this.dtpFechaPago.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaPago.Location = new System.Drawing.Point(298, 13);
            this.dtpFechaPago.Name = "dtpFechaPago";
            this.dtpFechaPago.Size = new System.Drawing.Size(98, 20);
            this.dtpFechaPago.TabIndex = 9;
            // 
            // lblMoneda
            // 
            this.lblMoneda.AutoSize = true;
            this.lblMoneda.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblMoneda.ForeColor = System.Drawing.Color.Navy;
            this.lblMoneda.Location = new System.Drawing.Point(393, 66);
            this.lblMoneda.Name = "lblMoneda";
            this.lblMoneda.Size = new System.Drawing.Size(56, 13);
            this.lblMoneda.TabIndex = 4;
            this.lblMoneda.Text = "Moneda:";
            // 
            // conBusCliente
            // 
            this.conBusCliente.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.conBusCliente.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.conBusCliente.idCli = 0;
            this.conBusCliente.Location = new System.Drawing.Point(8, 173);
            this.conBusCliente.Margin = new System.Windows.Forms.Padding(4);
            this.conBusCliente.Name = "conBusCliente";
            this.conBusCliente.Size = new System.Drawing.Size(561, 117);
            this.conBusCliente.TabIndex = 8;
            // 
            // txtTotal
            // 
            this.txtTotal.Enabled = false;
            this.txtTotal.FormatoDecimal = false;
            this.txtTotal.Location = new System.Drawing.Point(487, 163);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTotal.nNumDecimales = 4;
            this.txtTotal.nvalor = 0D;
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(66, 20);
            this.txtTotal.TabIndex = 26;
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtIGV
            // 
            this.txtIGV.Enabled = false;
            this.txtIGV.FormatoDecimal = false;
            this.txtIGV.Location = new System.Drawing.Point(355, 163);
            this.txtIGV.Name = "txtIGV";
            this.txtIGV.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtIGV.nNumDecimales = 2;
            this.txtIGV.nvalor = 0D;
            this.txtIGV.ReadOnly = true;
            this.txtIGV.Size = new System.Drawing.Size(66, 20);
            this.txtIGV.TabIndex = 27;
            this.txtIGV.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // grbDetalleCompr
            // 
            this.grbDetalleCompr.Controls.Add(this.txtTot4taCateg);
            this.grbDetalleCompr.Controls.Add(this.lblBase2);
            this.grbDetalleCompr.Controls.Add(this.lblBase1);
            this.grbDetalleCompr.Controls.Add(this.txtNetoPagar);
            this.grbDetalleCompr.Controls.Add(this.txtDescuentos);
            this.grbDetalleCompr.Controls.Add(this.txtTotPag);
            this.grbDetalleCompr.Controls.Add(this.txtTotOtros);
            this.grbDetalleCompr.Controls.Add(this.dtgDetalleComprobante);
            this.grbDetalleCompr.Controls.Add(this.btnQuitarDetalle);
            this.grbDetalleCompr.Controls.Add(this.btnAgregarDetalle);
            this.grbDetalleCompr.Controls.Add(this.txtValorCompra);
            this.grbDetalleCompr.Controls.Add(this.txtDetraccion);
            this.grbDetalleCompr.Controls.Add(this.txtIGV);
            this.grbDetalleCompr.Controls.Add(this.txtTotal);
            this.grbDetalleCompr.Location = new System.Drawing.Point(8, 433);
            this.grbDetalleCompr.Name = "grbDetalleCompr";
            this.grbDetalleCompr.Size = new System.Drawing.Size(802, 234);
            this.grbDetalleCompr.TabIndex = 7;
            this.grbDetalleCompr.TabStop = false;
            this.grbDetalleCompr.Text = "Detalle del Comprobante";
            this.grbDetalleCompr.Enter += new System.EventHandler(this.grbDetalleCompr_Enter);
            // 
            // txtTot4taCateg
            // 
            this.txtTot4taCateg.Enabled = false;
            this.txtTot4taCateg.FormatoDecimal = false;
            this.txtTot4taCateg.Location = new System.Drawing.Point(553, 163);
            this.txtTot4taCateg.Name = "txtTot4taCateg";
            this.txtTot4taCateg.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTot4taCateg.nNumDecimales = 4;
            this.txtTot4taCateg.nvalor = 0D;
            this.txtTot4taCateg.ReadOnly = true;
            this.txtTot4taCateg.Size = new System.Drawing.Size(66, 20);
            this.txtTot4taCateg.TabIndex = 58;
            this.txtTot4taCateg.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(504, 213);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(155, 13);
            this.lblBase2.TabIndex = 56;
            this.lblBase2.Text = "IMPORTE NETO A PAGAR:";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(567, 189);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(92, 13);
            this.lblBase1.TabIndex = 55;
            this.lblBase1.Text = "DESCUENTOS:";
            // 
            // txtNetoPagar
            // 
            this.txtNetoPagar.Enabled = false;
            this.txtNetoPagar.FormatoDecimal = false;
            this.txtNetoPagar.Location = new System.Drawing.Point(685, 209);
            this.txtNetoPagar.Name = "txtNetoPagar";
            this.txtNetoPagar.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtNetoPagar.nNumDecimales = 4;
            this.txtNetoPagar.nvalor = 0D;
            this.txtNetoPagar.ReadOnly = true;
            this.txtNetoPagar.Size = new System.Drawing.Size(65, 20);
            this.txtNetoPagar.TabIndex = 54;
            this.txtNetoPagar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtDescuentos
            // 
            this.txtDescuentos.Enabled = false;
            this.txtDescuentos.FormatoDecimal = false;
            this.txtDescuentos.Location = new System.Drawing.Point(685, 185);
            this.txtDescuentos.Name = "txtDescuentos";
            this.txtDescuentos.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtDescuentos.nNumDecimales = 4;
            this.txtDescuentos.nvalor = 0D;
            this.txtDescuentos.ReadOnly = true;
            this.txtDescuentos.Size = new System.Drawing.Size(65, 20);
            this.txtDescuentos.TabIndex = 53;
            this.txtDescuentos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTotPag
            // 
            this.txtTotPag.Enabled = false;
            this.txtTotPag.FormatoDecimal = false;
            this.txtTotPag.Location = new System.Drawing.Point(685, 163);
            this.txtTotPag.Name = "txtTotPag";
            this.txtTotPag.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTotPag.nNumDecimales = 4;
            this.txtTotPag.nvalor = 0D;
            this.txtTotPag.ReadOnly = true;
            this.txtTotPag.Size = new System.Drawing.Size(66, 20);
            this.txtTotPag.TabIndex = 52;
            this.txtTotPag.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTotOtros
            // 
            this.txtTotOtros.Enabled = false;
            this.txtTotOtros.FormatoDecimal = false;
            this.txtTotOtros.Location = new System.Drawing.Point(421, 163);
            this.txtTotOtros.Name = "txtTotOtros";
            this.txtTotOtros.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTotOtros.nNumDecimales = 4;
            this.txtTotOtros.nvalor = 0D;
            this.txtTotOtros.ReadOnly = true;
            this.txtTotOtros.Size = new System.Drawing.Size(66, 20);
            this.txtTotOtros.TabIndex = 51;
            this.txtTotOtros.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // dtgDetalleComprobante
            // 
            this.dtgDetalleComprobante.AllowUserToAddRows = false;
            this.dtgDetalleComprobante.AllowUserToDeleteRows = false;
            this.dtgDetalleComprobante.AllowUserToResizeColumns = false;
            this.dtgDetalleComprobante.AllowUserToResizeRows = false;
            this.dtgDetalleComprobante.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgDetalleComprobante.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDetalleComprobante.Location = new System.Drawing.Point(13, 19);
            this.dtgDetalleComprobante.MultiSelect = false;
            this.dtgDetalleComprobante.Name = "dtgDetalleComprobante";
            this.dtgDetalleComprobante.ReadOnly = true;
            this.dtgDetalleComprobante.RowHeadersVisible = false;
            this.dtgDetalleComprobante.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgDetalleComprobante.Size = new System.Drawing.Size(737, 139);
            this.dtgDetalleComprobante.TabIndex = 44;
            this.dtgDetalleComprobante.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgDetalleComprobante_CellClick);
            this.dtgDetalleComprobante.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgDetalleComprobante_CellValueChanged);
            // 
            // btnQuitarDetalle
            // 
            this.btnQuitarDetalle.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnQuitarDetalle.BackgroundImage")));
            this.btnQuitarDetalle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnQuitarDetalle.Location = new System.Drawing.Point(756, 53);
            this.btnQuitarDetalle.Name = "btnQuitarDetalle";
            this.btnQuitarDetalle.Size = new System.Drawing.Size(36, 28);
            this.btnQuitarDetalle.TabIndex = 19;
            this.btnQuitarDetalle.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnQuitarDetalle.UseVisualStyleBackColor = true;
            this.btnQuitarDetalle.Click += new System.EventHandler(this.btnQuitarDetalle_Click);
            // 
            // btnAgregarDetalle
            // 
            this.btnAgregarDetalle.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAgregarDetalle.BackgroundImage")));
            this.btnAgregarDetalle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAgregarDetalle.Location = new System.Drawing.Point(756, 19);
            this.btnAgregarDetalle.Name = "btnAgregarDetalle";
            this.btnAgregarDetalle.Size = new System.Drawing.Size(36, 28);
            this.btnAgregarDetalle.TabIndex = 18;
            this.btnAgregarDetalle.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAgregarDetalle.UseVisualStyleBackColor = true;
            this.btnAgregarDetalle.Click += new System.EventHandler(this.btnAgregarDetalle_Click);
            // 
            // txtValorCompra
            // 
            this.txtValorCompra.Enabled = false;
            this.txtValorCompra.FormatoDecimal = false;
            this.txtValorCompra.Location = new System.Drawing.Point(289, 163);
            this.txtValorCompra.Name = "txtValorCompra";
            this.txtValorCompra.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtValorCompra.nNumDecimales = 2;
            this.txtValorCompra.nvalor = 0D;
            this.txtValorCompra.ReadOnly = true;
            this.txtValorCompra.Size = new System.Drawing.Size(66, 20);
            this.txtValorCompra.TabIndex = 39;
            this.txtValorCompra.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtDetraccion
            // 
            this.txtDetraccion.Enabled = false;
            this.txtDetraccion.FormatoDecimal = false;
            this.txtDetraccion.Location = new System.Drawing.Point(619, 163);
            this.txtDetraccion.Name = "txtDetraccion";
            this.txtDetraccion.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtDetraccion.nNumDecimales = 4;
            this.txtDetraccion.nvalor = 0D;
            this.txtDetraccion.ReadOnly = true;
            this.txtDetraccion.Size = new System.Drawing.Size(66, 20);
            this.txtDetraccion.TabIndex = 37;
            this.txtDetraccion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // grbBase2
            // 
            this.grbBase2.Controls.Add(this.dtgOtrosDesctosCpg);
            this.grbBase2.Location = new System.Drawing.Point(575, 131);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(234, 159);
            this.grbBase2.TabIndex = 3;
            this.grbBase2.TabStop = false;
            this.grbBase2.Text = "Otros Descuentos:";
            // 
            // dtgOtrosDesctosCpg
            // 
            this.dtgOtrosDesctosCpg.AllowUserToAddRows = false;
            this.dtgOtrosDesctosCpg.AllowUserToDeleteRows = false;
            this.dtgOtrosDesctosCpg.AllowUserToResizeColumns = false;
            this.dtgOtrosDesctosCpg.AllowUserToResizeRows = false;
            this.dtgOtrosDesctosCpg.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgOtrosDesctosCpg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgOtrosDesctosCpg.Location = new System.Drawing.Point(6, 15);
            this.dtgOtrosDesctosCpg.MultiSelect = false;
            this.dtgOtrosDesctosCpg.Name = "dtgOtrosDesctosCpg";
            this.dtgOtrosDesctosCpg.ReadOnly = true;
            this.dtgOtrosDesctosCpg.RowHeadersVisible = false;
            this.dtgOtrosDesctosCpg.RowTemplate.Height = 18;
            this.dtgOtrosDesctosCpg.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgOtrosDesctosCpg.Size = new System.Drawing.Size(219, 131);
            this.dtgOtrosDesctosCpg.TabIndex = 36;
            this.dtgOtrosDesctosCpg.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgOtrosDesctosCpg_CellClick);
            this.dtgOtrosDesctosCpg.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgOtrosDesctosCpg_CellValueChanged);
            // 
            // lblFechaProvision
            // 
            this.lblFechaProvision.AutoSize = true;
            this.lblFechaProvision.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblFechaProvision.ForeColor = System.Drawing.Color.Navy;
            this.lblFechaProvision.Location = new System.Drawing.Point(11, 697);
            this.lblFechaProvision.Name = "lblFechaProvision";
            this.lblFechaProvision.Size = new System.Drawing.Size(101, 13);
            this.lblFechaProvision.TabIndex = 9;
            this.lblFechaProvision.Text = "Fecha Provisión:";
            this.lblFechaProvision.Visible = false;
            // 
            // dtpFechaProvision
            // 
            this.dtpFechaProvision.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaProvision.Location = new System.Drawing.Point(110, 694);
            this.dtpFechaProvision.Name = "dtpFechaProvision";
            this.dtpFechaProvision.Size = new System.Drawing.Size(98, 20);
            this.dtpFechaProvision.TabIndex = 10;
            this.dtpFechaProvision.Visible = false;
            // 
            // grbDatosCompr
            // 
            this.grbDatosCompr.Controls.Add(this.lblFecVenc);
            this.grbDatosCompr.Controls.Add(this.dtpFecVenc);
            this.grbDatosCompr.Controls.Add(this.txtSerie);
            this.grbDatosCompr.Controls.Add(this.txtCambio);
            this.grbDatosCompr.Controls.Add(this.txtNumero);
            this.grbDatosCompr.Controls.Add(this.lblCambio);
            this.grbDatosCompr.Controls.Add(this.cboMoneda);
            this.grbDatosCompr.Controls.Add(this.cboTipoComprobantePago);
            this.grbDatosCompr.Controls.Add(this.lblTipoComprobante);
            this.grbDatosCompr.Controls.Add(this.lblFechaEmision);
            this.grbDatosCompr.Controls.Add(this.dtpFechaEmision);
            this.grbDatosCompr.Controls.Add(this.lblMoneda);
            this.grbDatosCompr.Controls.Add(this.lblNumero);
            this.grbDatosCompr.Controls.Add(this.lblSerie);
            this.grbDatosCompr.Location = new System.Drawing.Point(7, 43);
            this.grbDatosCompr.Name = "grbDatosCompr";
            this.grbDatosCompr.Size = new System.Drawing.Size(565, 88);
            this.grbDatosCompr.TabIndex = 0;
            this.grbDatosCompr.TabStop = false;
            // 
            // lblFecVenc
            // 
            this.lblFecVenc.AutoSize = true;
            this.lblFecVenc.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblFecVenc.ForeColor = System.Drawing.Color.Navy;
            this.lblFecVenc.Location = new System.Drawing.Point(10, 66);
            this.lblFecVenc.Name = "lblFecVenc";
            this.lblFecVenc.Size = new System.Drawing.Size(80, 13);
            this.lblFecVenc.TabIndex = 9;
            this.lblFecVenc.Text = "Fecha Venc.:";
            // 
            // dtpFecVenc
            // 
            this.dtpFecVenc.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecVenc.Location = new System.Drawing.Point(127, 63);
            this.dtpFecVenc.Name = "dtpFecVenc";
            this.dtpFecVenc.Size = new System.Drawing.Size(119, 20);
            this.dtpFecVenc.TabIndex = 10;
            // 
            // txtSerie
            // 
            this.txtSerie.Location = new System.Drawing.Point(482, 12);
            this.txtSerie.MaxLength = 4;
            this.txtSerie.Name = "txtSerie";
            this.txtSerie.Size = new System.Drawing.Size(70, 20);
            this.txtSerie.TabIndex = 2;
            this.txtSerie.Leave += new System.EventHandler(this.txtSerie_Leave);
            // 
            // txtCambio
            // 
            this.txtCambio.FormatoDecimal = false;
            this.txtCambio.Location = new System.Drawing.Point(314, 63);
            this.txtCambio.MaxLength = 8;
            this.txtCambio.Name = "txtCambio";
            this.txtCambio.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtCambio.nNumDecimales = 4;
            this.txtCambio.nvalor = 0D;
            this.txtCambio.ReadOnly = true;
            this.txtCambio.Size = new System.Drawing.Size(70, 20);
            this.txtCambio.TabIndex = 6;
            this.txtCambio.Visible = false;
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(482, 38);
            this.txtNumero.MaxLength = 18;
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(70, 20);
            this.txtNumero.TabIndex = 3;
            this.txtNumero.Leave += new System.EventHandler(this.txtNumero_Leave);
            // 
            // lblCambio
            // 
            this.lblCambio.AutoSize = true;
            this.lblCambio.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblCambio.ForeColor = System.Drawing.Color.Navy;
            this.lblCambio.Location = new System.Drawing.Point(258, 66);
            this.lblCambio.Name = "lblCambio";
            this.lblCambio.Size = new System.Drawing.Size(56, 13);
            this.lblCambio.TabIndex = 6;
            this.lblCambio.Text = "Cambio:";
            this.lblCambio.Visible = false;
            // 
            // cboMoneda
            // 
            this.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMoneda.FormattingEnabled = true;
            this.cboMoneda.ItemHeight = 13;
            this.cboMoneda.Location = new System.Drawing.Point(447, 63);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Size = new System.Drawing.Size(105, 21);
            this.cboMoneda.TabIndex = 5;
            this.cboMoneda.SelectedIndexChanged += new System.EventHandler(this.cboMoneda_SelectedIndexChanged);
            // 
            // cboTipoComprobantePago
            // 
            this.cboTipoComprobantePago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoComprobantePago.DropDownWidth = 600;
            this.cboTipoComprobantePago.FormattingEnabled = true;
            this.cboTipoComprobantePago.Location = new System.Drawing.Point(127, 12);
            this.cboTipoComprobantePago.Name = "cboTipoComprobantePago";
            this.cboTipoComprobantePago.Size = new System.Drawing.Size(286, 21);
            this.cboTipoComprobantePago.TabIndex = 1;
            this.cboTipoComprobantePago.SelectedIndexChanged += new System.EventHandler(this.cboTipoComprobantePago_SelectedIndexChanged);
            // 
            // lblNumero
            // 
            this.lblNumero.AutoSize = true;
            this.lblNumero.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblNumero.ForeColor = System.Drawing.Color.Navy;
            this.lblNumero.Location = new System.Drawing.Point(424, 42);
            this.lblNumero.Name = "lblNumero";
            this.lblNumero.Size = new System.Drawing.Size(57, 13);
            this.lblNumero.TabIndex = 8;
            this.lblNumero.Text = "Número:";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(458, 17);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(75, 13);
            this.lblBase3.TabIndex = 49;
            this.lblBase3.Text = "Caja Chica:";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(78, 20);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(103, 20);
            this.txtCodigo.TabIndex = 14;
            this.txtCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigo_KeyPress);
            // 
            // cboTipoPago
            // 
            this.cboTipoPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoPago.FormattingEnabled = true;
            this.cboTipoPago.Location = new System.Drawing.Point(85, 13);
            this.cboTipoPago.Name = "cboTipoPago";
            this.cboTipoPago.Size = new System.Drawing.Size(121, 21);
            this.cboTipoPago.TabIndex = 7;
            // 
            // lblTipoPago
            // 
            this.lblTipoPago.AutoSize = true;
            this.lblTipoPago.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblTipoPago.ForeColor = System.Drawing.Color.Navy;
            this.lblTipoPago.Location = new System.Drawing.Point(15, 17);
            this.lblTipoPago.Name = "lblTipoPago";
            this.lblTipoPago.Size = new System.Drawing.Size(68, 13);
            this.lblTipoPago.TabIndex = 50;
            this.lblTipoPago.Text = "Tipo Pago:";
            // 
            // lblTipoOperacion
            // 
            this.lblTipoOperacion.AutoSize = true;
            this.lblTipoOperacion.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblTipoOperacion.ForeColor = System.Drawing.Color.Navy;
            this.lblTipoOperacion.Location = new System.Drawing.Point(10, 40);
            this.lblTipoOperacion.Name = "lblTipoOperacion";
            this.lblTipoOperacion.Size = new System.Drawing.Size(98, 13);
            this.lblTipoOperacion.TabIndex = 43;
            this.lblTipoOperacion.Text = "Tipo Operación:";
            // 
            // lblPorcDetraccion
            // 
            this.lblPorcDetraccion.AutoSize = true;
            this.lblPorcDetraccion.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblPorcDetraccion.ForeColor = System.Drawing.Color.Navy;
            this.lblPorcDetraccion.Location = new System.Drawing.Point(10, 114);
            this.lblPorcDetraccion.Name = "lblPorcDetraccion";
            this.lblPorcDetraccion.Size = new System.Drawing.Size(89, 13);
            this.lblPorcDetraccion.TabIndex = 44;
            this.lblPorcDetraccion.Text = "% Detracción:";
            // 
            // txtPorcDetraccion
            // 
            this.txtPorcDetraccion.FormatoDecimal = false;
            this.txtPorcDetraccion.Location = new System.Drawing.Point(115, 111);
            this.txtPorcDetraccion.Name = "txtPorcDetraccion";
            this.txtPorcDetraccion.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtPorcDetraccion.nNumDecimales = 4;
            this.txtPorcDetraccion.nvalor = 0D;
            this.txtPorcDetraccion.ReadOnly = true;
            this.txtPorcDetraccion.Size = new System.Drawing.Size(96, 20);
            this.txtPorcDetraccion.TabIndex = 14;
            this.txtPorcDetraccion.TextChanged += new System.EventHandler(this.txtPorcDetraccion_TextChanged);
            // 
            // grbDetraccion
            // 
            this.grbDetraccion.Controls.Add(this.txtCIIU);
            this.grbDetraccion.Controls.Add(this.cboTipoOperacion);
            this.grbDetraccion.Controls.Add(this.rbtnSinDetraccion);
            this.grbDetraccion.Controls.Add(this.rbtnConDetraccion);
            this.grbDetraccion.Controls.Add(this.lblCIIU);
            this.grbDetraccion.Controls.Add(this.cboBienServicio);
            this.grbDetraccion.Controls.Add(this.lblBienServicio);
            this.grbDetraccion.Controls.Add(this.txtPorcDetraccion);
            this.grbDetraccion.Controls.Add(this.lblTipoOperacion);
            this.grbDetraccion.Controls.Add(this.lblPorcDetraccion);
            this.grbDetraccion.Location = new System.Drawing.Point(8, 294);
            this.grbDetraccion.Name = "grbDetraccion";
            this.grbDetraccion.Size = new System.Drawing.Size(347, 133);
            this.grbDetraccion.TabIndex = 5;
            this.grbDetraccion.TabStop = false;
            // 
            // txtCIIU
            // 
            this.txtCIIU.Location = new System.Drawing.Point(115, 87);
            this.txtCIIU.Name = "txtCIIU";
            this.txtCIIU.ReadOnly = true;
            this.txtCIIU.Size = new System.Drawing.Size(96, 20);
            this.txtCIIU.TabIndex = 13;
            // 
            // cboTipoOperacion
            // 
            this.cboTipoOperacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoOperacion.DropDownWidth = 400;
            this.cboTipoOperacion.FormattingEnabled = true;
            this.cboTipoOperacion.Location = new System.Drawing.Point(115, 37);
            this.cboTipoOperacion.Name = "cboTipoOperacion";
            this.cboTipoOperacion.Size = new System.Drawing.Size(226, 21);
            this.cboTipoOperacion.TabIndex = 11;
            this.cboTipoOperacion.SelectedIndexChanged += new System.EventHandler(this.cboTipoOperacion_SelectedIndexChanged);
            // 
            // rbtnSinDetraccion
            // 
            this.rbtnSinDetraccion.AutoSize = true;
            this.rbtnSinDetraccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.rbtnSinDetraccion.ForeColor = System.Drawing.Color.Navy;
            this.rbtnSinDetraccion.Location = new System.Drawing.Point(66, 13);
            this.rbtnSinDetraccion.Name = "rbtnSinDetraccion";
            this.rbtnSinDetraccion.Size = new System.Drawing.Size(95, 17);
            this.rbtnSinDetraccion.TabIndex = 9;
            this.rbtnSinDetraccion.TabStop = true;
            this.rbtnSinDetraccion.Text = "Sin Detracción";
            this.rbtnSinDetraccion.UseVisualStyleBackColor = true;
            this.rbtnSinDetraccion.CheckedChanged += new System.EventHandler(this.rbtnSinDetraccion_CheckedChanged);
            // 
            // rbtnConDetraccion
            // 
            this.rbtnConDetraccion.AutoSize = true;
            this.rbtnConDetraccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.rbtnConDetraccion.ForeColor = System.Drawing.Color.Navy;
            this.rbtnConDetraccion.Location = new System.Drawing.Point(182, 13);
            this.rbtnConDetraccion.Name = "rbtnConDetraccion";
            this.rbtnConDetraccion.Size = new System.Drawing.Size(99, 17);
            this.rbtnConDetraccion.TabIndex = 10;
            this.rbtnConDetraccion.TabStop = true;
            this.rbtnConDetraccion.Text = "Con Detracción";
            this.rbtnConDetraccion.UseVisualStyleBackColor = true;
            this.rbtnConDetraccion.CheckedChanged += new System.EventHandler(this.rbtnConDetraccion_CheckedChanged);
            // 
            // lblCIIU
            // 
            this.lblCIIU.AutoSize = true;
            this.lblCIIU.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblCIIU.ForeColor = System.Drawing.Color.Navy;
            this.lblCIIU.Location = new System.Drawing.Point(10, 90);
            this.lblCIIU.Name = "lblCIIU";
            this.lblCIIU.Size = new System.Drawing.Size(39, 13);
            this.lblCIIU.TabIndex = 48;
            this.lblCIIU.Text = "CIIU:";
            // 
            // cboBienServicio
            // 
            this.cboBienServicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBienServicio.DropDownWidth = 400;
            this.cboBienServicio.FormattingEnabled = true;
            this.cboBienServicio.Location = new System.Drawing.Point(115, 62);
            this.cboBienServicio.Name = "cboBienServicio";
            this.cboBienServicio.Size = new System.Drawing.Size(226, 21);
            this.cboBienServicio.TabIndex = 12;
            this.cboBienServicio.SelectedIndexChanged += new System.EventHandler(this.cboBienServicio_SelectedIndexChanged);
            // 
            // lblBienServicio
            // 
            this.lblBienServicio.AutoSize = true;
            this.lblBienServicio.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBienServicio.ForeColor = System.Drawing.Color.Navy;
            this.lblBienServicio.Location = new System.Drawing.Point(10, 65);
            this.lblBienServicio.Name = "lblBienServicio";
            this.lblBienServicio.Size = new System.Drawing.Size(88, 13);
            this.lblBienServicio.TabIndex = 46;
            this.lblBienServicio.Text = "Bien/Servicio:";
            // 
            // grbPago
            // 
            this.grbPago.Controls.Add(this.cboTipoPago);
            this.grbPago.Controls.Add(this.dtpFechaPago);
            this.grbPago.Controls.Add(this.lblTipoPago);
            this.grbPago.Controls.Add(this.lblFechaPago);
            this.grbPago.Location = new System.Drawing.Point(151, 131);
            this.grbPago.Name = "grbPago";
            this.grbPago.Size = new System.Drawing.Size(421, 37);
            this.grbPago.TabIndex = 2;
            this.grbPago.TabStop = false;
            // 
            // chcProvisionar
            // 
            this.chcProvisionar.AutoSize = true;
            this.chcProvisionar.Enabled = false;
            this.chcProvisionar.Location = new System.Drawing.Point(14, 677);
            this.chcProvisionar.Name = "chcProvisionar";
            this.chcProvisionar.Size = new System.Drawing.Size(87, 17);
            this.chcProvisionar.TabIndex = 8;
            this.chcProvisionar.Text = "Provisionado";
            this.chcProvisionar.UseVisualStyleBackColor = true;
            this.chcProvisionar.CheckedChanged += new System.EventHandler(this.chcProvisionar_CheckedChanged);
            // 
            // grbIgv
            // 
            this.grbIgv.Controls.Add(this.txtIgvCalculo);
            this.grbIgv.Controls.Add(this.lblIgvCalculo);
            this.grbIgv.Location = new System.Drawing.Point(7, 131);
            this.grbIgv.Name = "grbIgv";
            this.grbIgv.Size = new System.Drawing.Size(138, 37);
            this.grbIgv.TabIndex = 1;
            this.grbIgv.TabStop = false;
            // 
            // txtIgvCalculo
            // 
            this.txtIgvCalculo.FormatoDecimal = false;
            this.txtIgvCalculo.Location = new System.Drawing.Point(58, 13);
            this.txtIgvCalculo.Name = "txtIgvCalculo";
            this.txtIgvCalculo.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtIgvCalculo.nNumDecimales = 2;
            this.txtIgvCalculo.nvalor = 0D;
            this.txtIgvCalculo.ReadOnly = true;
            this.txtIgvCalculo.Size = new System.Drawing.Size(67, 20);
            this.txtIgvCalculo.TabIndex = 7;
            this.txtIgvCalculo.TextChanged += new System.EventHandler(this.txtIgvCalculo_TextChanged);
            // 
            // lblIgvCalculo
            // 
            this.lblIgvCalculo.AutoSize = true;
            this.lblIgvCalculo.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblIgvCalculo.ForeColor = System.Drawing.Color.Navy;
            this.lblIgvCalculo.Location = new System.Drawing.Point(7, 16);
            this.lblIgvCalculo.Name = "lblIgvCalculo";
            this.lblIgvCalculo.Size = new System.Drawing.Size(50, 13);
            this.lblIgvCalculo.TabIndex = 0;
            this.lblIgvCalculo.Text = "% IGV:";
            // 
            // cboDestino
            // 
            this.cboDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDestino.DropDownWidth = 280;
            this.cboDestino.FormattingEnabled = true;
            this.cboDestino.Location = new System.Drawing.Point(68, 13);
            this.cboDestino.Name = "cboDestino";
            this.cboDestino.Size = new System.Drawing.Size(238, 21);
            this.cboDestino.TabIndex = 15;
            this.cboDestino.SelectedIndexChanged += new System.EventHandler(this.cboDestino_SelectedIndexChanged);
            // 
            // lblDestino
            // 
            this.lblDestino.AutoSize = true;
            this.lblDestino.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblDestino.ForeColor = System.Drawing.Color.Navy;
            this.lblDestino.Location = new System.Drawing.Point(10, 16);
            this.lblDestino.Name = "lblDestino";
            this.lblDestino.Size = new System.Drawing.Size(55, 13);
            this.lblDestino.TabIndex = 55;
            this.lblDestino.Text = "Destino:";
            // 
            // lblGlosa
            // 
            this.lblGlosa.AutoSize = true;
            this.lblGlosa.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblGlosa.ForeColor = System.Drawing.Color.Navy;
            this.lblGlosa.Location = new System.Drawing.Point(10, 59);
            this.lblGlosa.Name = "lblGlosa";
            this.lblGlosa.Size = new System.Drawing.Size(44, 13);
            this.lblGlosa.TabIndex = 57;
            this.lblGlosa.Text = "Glosa:";
            // 
            // txtGlosa
            // 
            this.txtGlosa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtGlosa.Location = new System.Drawing.Point(70, 59);
            this.txtGlosa.Multiline = true;
            this.txtGlosa.Name = "txtGlosa";
            this.txtGlosa.Size = new System.Drawing.Size(372, 68);
            this.txtGlosa.TabIndex = 17;
            // 
            // grbDatCompr
            // 
            this.grbDatCompr.Controls.Add(this.chcImpRenta);
            this.grbDatCompr.Controls.Add(this.chcCuartaCateg);
            this.grbDatCompr.Controls.Add(this.txtGlosa);
            this.grbDatCompr.Controls.Add(this.lblGlosa);
            this.grbDatCompr.Controls.Add(this.lblDestino);
            this.grbDatCompr.Controls.Add(this.cboDestino);
            this.grbDatCompr.Location = new System.Drawing.Point(361, 294);
            this.grbDatCompr.Name = "grbDatCompr";
            this.grbDatCompr.Size = new System.Drawing.Size(448, 133);
            this.grbDatCompr.TabIndex = 6;
            this.grbDatCompr.TabStop = false;
            // 
            // chcImpRenta
            // 
            this.chcImpRenta.AutoSize = true;
            this.chcImpRenta.ForeColor = System.Drawing.Color.Navy;
            this.chcImpRenta.Location = new System.Drawing.Point(13, 38);
            this.chcImpRenta.Name = "chcImpRenta";
            this.chcImpRenta.Size = new System.Drawing.Size(364, 17);
            this.chcImpRenta.TabIndex = 59;
            this.chcImpRenta.Text = "Pertenece a los incisos E y F del Art. N° 34, Ley de Impuesto a la Renta";
            this.chcImpRenta.UseVisualStyleBackColor = true;
            // 
            // chcCuartaCateg
            // 
            this.chcCuartaCateg.AutoSize = true;
            this.chcCuartaCateg.ForeColor = System.Drawing.Color.Navy;
            this.chcCuartaCateg.Location = new System.Drawing.Point(315, 16);
            this.chcCuartaCateg.Name = "chcCuartaCateg";
            this.chcCuartaCateg.Size = new System.Drawing.Size(125, 17);
            this.chcCuartaCateg.TabIndex = 16;
            this.chcCuartaCateg.Text = "Afecto 4ta Categoría";
            this.chcCuartaCateg.UseVisualStyleBackColor = true;
            this.chcCuartaCateg.CheckedChanged += new System.EventHandler(this.chcCuartaCateg_CheckedChanged);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(749, 672);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 25;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Location = new System.Drawing.Point(609, 672);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 21;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Location = new System.Drawing.Point(549, 672);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 20;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar.BackgroundImage")));
            this.btnEditar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar.Location = new System.Drawing.Point(489, 672);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(60, 50);
            this.btnEditar.TabIndex = 23;
            this.btnEditar.Text = "&Editar";
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo.BackgroundImage")));
            this.btnNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevo.Location = new System.Drawing.Point(429, 672);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(60, 50);
            this.btnNuevo.TabIndex = 22;
            this.btnNuevo.Text = "&Nuevo";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnAnular
            // 
            this.btnAnular.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAnular.BackgroundImage")));
            this.btnAnular.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAnular.Location = new System.Drawing.Point(669, 672);
            this.btnAnular.Name = "btnAnular";
            this.btnAnular.Size = new System.Drawing.Size(60, 50);
            this.btnAnular.TabIndex = 24;
            this.btnAnular.Text = "Anu&lar";
            this.btnAnular.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAnular.UseVisualStyleBackColor = true;
            this.btnAnular.Click += new System.EventHandler(this.btnAnular_Click);
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.cboCajaChica);
            this.grbBase1.Controls.Add(this.cboAgencias1);
            this.grbBase1.Controls.Add(this.lblBase5);
            this.grbBase1.Controls.Add(this.txtNroCajChica);
            this.grbBase1.Controls.Add(this.lblBase4);
            this.grbBase1.Controls.Add(this.lblBase3);
            this.grbBase1.Location = new System.Drawing.Point(7, 3);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(802, 40);
            this.grbBase1.TabIndex = 53;
            this.grbBase1.TabStop = false;
            // 
            // cboCajaChica
            // 
            this.cboCajaChica.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCajaChica.FormattingEnabled = true;
            this.cboCajaChica.Location = new System.Drawing.Point(533, 13);
            this.cboCajaChica.Name = "cboCajaChica";
            this.cboCajaChica.Size = new System.Drawing.Size(239, 21);
            this.cboCajaChica.TabIndex = 2;
            this.cboCajaChica.SelectedIndexChanged += new System.EventHandler(this.cboCajaChica_SelectedIndexChanged);
            // 
            // cboAgencias1
            // 
            this.cboAgencias1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAgencias1.FormattingEnabled = true;
            this.cboAgencias1.Location = new System.Drawing.Point(67, 12);
            this.cboAgencias1.Name = "cboAgencias1";
            this.cboAgencias1.Size = new System.Drawing.Size(190, 21);
            this.cboAgencias1.TabIndex = 1;
            this.cboAgencias1.SelectedIndexChanged += new System.EventHandler(this.cboAgencias1_SelectedIndexChanged);
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(11, 15);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(57, 13);
            this.lblBase5.TabIndex = 53;
            this.lblBase5.Text = "Agencia:";
            // 
            // txtNroCajChica
            // 
            this.txtNroCajChica.Enabled = false;
            this.txtNroCajChica.Location = new System.Drawing.Point(370, 12);
            this.txtNroCajChica.Name = "txtNroCajChica";
            this.txtNroCajChica.Size = new System.Drawing.Size(77, 20);
            this.txtNroCajChica.TabIndex = 3;
            this.txtNroCajChica.Visible = false;
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(279, 16);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(90, 13);
            this.lblBase4.TabIndex = 51;
            this.lblBase4.Text = "Caj. Chica N°:";
            this.lblBase4.Visible = false;
            // 
            // grbBase3
            // 
            this.grbBase3.Controls.Add(this.btnBusqCodRef);
            this.grbBase3.Controls.Add(this.txtCodRef);
            this.grbBase3.Controls.Add(this.lblCodRef);
            this.grbBase3.Controls.Add(this.btnBuscar);
            this.grbBase3.Controls.Add(this.txtCodigo);
            this.grbBase3.Controls.Add(this.lblCodigo);
            this.grbBase3.Location = new System.Drawing.Point(578, 43);
            this.grbBase3.Name = "grbBase3";
            this.grbBase3.Size = new System.Drawing.Size(231, 88);
            this.grbBase3.TabIndex = 54;
            this.grbBase3.TabStop = false;
            // 
            // btnBusqCodRef
            // 
            this.btnBusqCodRef.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBusqCodRef.BackgroundImage")));
            this.btnBusqCodRef.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBusqCodRef.Location = new System.Drawing.Point(186, 47);
            this.btnBusqCodRef.Name = "btnBusqCodRef";
            this.btnBusqCodRef.Size = new System.Drawing.Size(36, 28);
            this.btnBusqCodRef.TabIndex = 21;
            this.btnBusqCodRef.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBusqCodRef.UseVisualStyleBackColor = true;
            this.btnBusqCodRef.Visible = false;
            this.btnBusqCodRef.Click += new System.EventHandler(this.btnBusqCodRef_Click);
            // 
            // txtCodRef
            // 
            this.txtCodRef.Location = new System.Drawing.Point(78, 54);
            this.txtCodRef.Name = "txtCodRef";
            this.txtCodRef.ReadOnly = true;
            this.txtCodRef.Size = new System.Drawing.Size(103, 20);
            this.txtCodRef.TabIndex = 20;
            this.txtCodRef.Visible = false;
            // 
            // lblCodRef
            // 
            this.lblCodRef.AutoSize = true;
            this.lblCodRef.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblCodRef.ForeColor = System.Drawing.Color.Navy;
            this.lblCodRef.Location = new System.Drawing.Point(6, 58);
            this.lblCodRef.Name = "lblCodRef";
            this.lblCodRef.Size = new System.Drawing.Size(65, 13);
            this.lblCodRef.TabIndex = 19;
            this.lblCodRef.Text = "Cod. Ref.:";
            this.lblCodRef.Visible = false;
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBuscar.BackgroundImage")));
            this.btnBuscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBuscar.Location = new System.Drawing.Point(186, 13);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(36, 28);
            this.btnBuscar.TabIndex = 15;
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnImprimir1
            // 
            this.btnImprimir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir1.BackgroundImage")));
            this.btnImprimir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir1.Enabled = false;
            this.btnImprimir1.Location = new System.Drawing.Point(369, 672);
            this.btnImprimir1.Name = "btnImprimir1";
            this.btnImprimir1.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir1.TabIndex = 55;
            this.btnImprimir1.Text = "&Imprimir";
            this.btnImprimir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir1.UseVisualStyleBackColor = true;
            this.btnImprimir1.Visible = false;
            this.btnImprimir1.Click += new System.EventHandler(this.btnImprimir1_Click);
            // 
            // frmRegistroComprobantes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 746);
            this.Controls.Add(this.btnImprimir1);
            this.Controls.Add(this.grbBase3);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.btnAnular);
            this.Controls.Add(this.grbDatCompr);
            this.Controls.Add(this.grbIgv);
            this.Controls.Add(this.chcProvisionar);
            this.Controls.Add(this.dtpFechaProvision);
            this.Controls.Add(this.grbDatosCompr);
            this.Controls.Add(this.lblFechaProvision);
            this.Controls.Add(this.grbBase2);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.grbDetraccion);
            this.Controls.Add(this.grbDetalleCompr);
            this.Controls.Add(this.grbPago);
            this.Controls.Add(this.conBusCliente);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmRegistroComprobantes";
            this.Text = "Registro de Comprobantes";
            this.Load += new System.EventHandler(this.frmRegistroComprobantes_Load);
            this.Controls.SetChildIndex(this.conBusCliente, 0);
            this.Controls.SetChildIndex(this.grbPago, 0);
            this.Controls.SetChildIndex(this.grbDetalleCompr, 0);
            this.Controls.SetChildIndex(this.grbDetraccion, 0);
            this.Controls.SetChildIndex(this.btnNuevo, 0);
            this.Controls.SetChildIndex(this.btnEditar, 0);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.grbBase2, 0);
            this.Controls.SetChildIndex(this.lblFechaProvision, 0);
            this.Controls.SetChildIndex(this.grbDatosCompr, 0);
            this.Controls.SetChildIndex(this.dtpFechaProvision, 0);
            this.Controls.SetChildIndex(this.chcProvisionar, 0);
            this.Controls.SetChildIndex(this.grbIgv, 0);
            this.Controls.SetChildIndex(this.grbDatCompr, 0);
            this.Controls.SetChildIndex(this.btnAnular, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.grbBase3, 0);
            this.Controls.SetChildIndex(this.btnImprimir1, 0);
            this.grbDetalleCompr.ResumeLayout(false);
            this.grbDetalleCompr.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDetalleComprobante)).EndInit();
            this.grbBase2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgOtrosDesctosCpg)).EndInit();
            this.grbDatosCompr.ResumeLayout(false);
            this.grbDatosCompr.PerformLayout();
            this.grbDetraccion.ResumeLayout(false);
            this.grbDetraccion.PerformLayout();
            this.grbPago.ResumeLayout(false);
            this.grbPago.PerformLayout();
            this.grbIgv.ResumeLayout(false);
            this.grbIgv.PerformLayout();
            this.grbDatCompr.ResumeLayout(false);
            this.grbDatCompr.PerformLayout();
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.grbBase3.ResumeLayout(false);
            this.grbBase3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.lblBase lblTipoComprobante;
        private GEN.ControlesBase.lblBase lblSerie;
        private GEN.ControlesBase.lblBase lblCodigo;
        private GEN.ControlesBase.lblBase lblFechaEmision;
        private GEN.ControlesBase.lblBase lblFechaPago;
        private GEN.ControlesBase.dtpCorto dtpFechaEmision;
        private GEN.ControlesBase.dtpCorto dtpFechaPago;
        private GEN.ControlesBase.lblBase lblMoneda;
        private GEN.BotonesBase.btnNuevo btnNuevo;
        private GEN.BotonesBase.btnEditar btnEditar;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.ControlesBase.ConBusCliRuc conBusCliente;
        private GEN.ControlesBase.txtNumRea txtTotal;
        private GEN.ControlesBase.txtNumRea txtIGV;
        private GEN.ControlesBase.grbBase grbDetalleCompr;
        private GEN.ControlesBase.grbBase grbBase2;
        private GEN.ControlesBase.dtgBase dtgOtrosDesctosCpg;
        private GEN.ControlesBase.lblBase lblFechaProvision;
        private GEN.ControlesBase.dtpCorto dtpFechaProvision;
        private GEN.ControlesBase.txtNumRea txtValorCompra;
        private GEN.ControlesBase.txtNumRea txtDetraccion;
        private GEN.ControlesBase.grbBase grbDatosCompr;
        private GEN.ControlesBase.cboTipoComprobantePago cboTipoComprobantePago;
        private GEN.ControlesBase.cboMoneda cboMoneda;
        private GEN.ControlesBase.lblBase lblTipoOperacion;
        private GEN.ControlesBase.lblBase lblPorcDetraccion;
        private GEN.ControlesBase.txtNumRea txtPorcDetraccion;
        private GEN.ControlesBase.grbBase grbDetraccion;
        private GEN.ControlesBase.cboBase cboTipoPago;
        private GEN.ControlesBase.txtCBNumerosEnteros txtNumero;
        private GEN.ControlesBase.lblBase lblTipoPago;
        private GEN.ControlesBase.lblBase lblNumero;
        private GEN.ControlesBase.lblBase lblCIIU;
        private GEN.ControlesBase.cboBase cboBienServicio;
        private GEN.ControlesBase.lblBase lblBienServicio;
        private GEN.ControlesBase.grbBase grbPago;
        private GEN.ControlesBase.lblBase lblCambio;
        private GEN.BotonesBase.btnMiniQuitar btnQuitarDetalle;
        private GEN.BotonesBase.btnMiniAgregar btnAgregarDetalle;
        private GEN.ControlesBase.txtNumRea txtCambio;
        private GEN.ControlesBase.rbtnBase rbtnSinDetraccion;
        private GEN.ControlesBase.rbtnBase rbtnConDetraccion;
        private GEN.ControlesBase.chcBase chcProvisionar;
        private GEN.ControlesBase.cboBase cboTipoOperacion;
        private GEN.ControlesBase.dtgBase dtgDetalleComprobante;
        private GEN.ControlesBase.grbBase grbIgv;
        private GEN.ControlesBase.lblBase lblIgvCalculo;
        private GEN.ControlesBase.txtCBNumerosEnteros txtCodigo;
        private GEN.ControlesBase.txtBase txtCIIU;
        private GEN.ControlesBase.txtNumRea txtIgvCalculo;
        private GEN.ControlesBase.cboBase cboDestino;
        private GEN.ControlesBase.lblBase lblDestino;
        private GEN.ControlesBase.lblBase lblGlosa;
        private GEN.ControlesBase.txtBase txtGlosa;
        private GEN.ControlesBase.grbBase grbDatCompr;
        private GEN.BotonesBase.btnAnular btnAnular;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.txtNumRea txtTotOtros;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.txtNumRea txtNetoPagar;
        private GEN.ControlesBase.txtNumRea txtDescuentos;
        private GEN.ControlesBase.txtNumRea txtTotPag;
        private GEN.ControlesBase.txtNumRea txtTot4taCateg;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.grbBase grbBase3;
        private GEN.BotonesBase.btnMiniBusq btnBuscar;
        private GEN.BotonesBase.btnMiniBusq btnBusqCodRef;
        private GEN.ControlesBase.txtCBNumerosEnteros txtCodRef;
        private GEN.ControlesBase.lblBase lblCodRef;
        private GEN.ControlesBase.chcBase chcCuartaCateg;
        private GEN.ControlesBase.cboAgencias cboAgencias1;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.cboBase cboCajaChica;
        private GEN.ControlesBase.txtCBLetra txtSerie;
        private GEN.ControlesBase.chcBase chcImpRenta;
        private GEN.ControlesBase.lblBase lblFecVenc;
        private GEN.ControlesBase.dtpCorto dtpFecVenc;
        private GEN.BotonesBase.btnImprimir btnImprimir1;
        private GEN.ControlesBase.txtCBNumerosEnteros txtNroCajChica;
        private GEN.ControlesBase.lblBase lblBase4;
    }
}